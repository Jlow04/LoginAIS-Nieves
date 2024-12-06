using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoginAIS_Nieves
{
    public partial class AdminForm : Form
    {
        
        dbconnect db = new dbconnect();
        DataTable userTable;
        DataTable logsTable;
        private string loggedInUsername;
        private int selectedUserId; 

        private Timer idleTimer;
        private int idleTimeLimit;
        private DateTime lastActivityTime; 

        //pathfile for storing backups
        private string backupDirectory = @"C:\Users\hp\Desktop\DBBackups";
        public AdminForm(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            LoadData();
            panellogs.Visible = false;

            if (!Directory.Exists(backupDirectory))
            {
                Directory.CreateDirectory(backupDirectory);
            }

            LoadBackupFiles();

            LoadComboBoxValues();
            InitializeIdleTimeout();


            
            tbsearch.Text = "Search🔍";
            tbsearch.ForeColor = Color.Gray;

            
            tbsearch.Enter += (s, e) =>
            {
                if (tbsearch.Text == "Search🔍")
                {
                    tbsearch.Text = "";
                    tbsearch.ForeColor = Color.Black;
                }
            };

            tbsearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tbsearch.Text))
                {
                    tbsearch.Text = "Search🔍";
                    tbsearch.ForeColor = Color.Gray;
                }
            };
            
            
            

        }

        private void InitializeIdleTimeout()
        {
            
            UpdateIdleTimeLimit();

            
            idleTimer = new Timer();
            idleTimer.Interval = 1000; 
            idleTimer.Tick += IdleTimer_Tick;
            idleTimer.Start();

            
            this.MouseMove += ResetIdleTimer;
            this.KeyPress += ResetIdleTimer;
            this.Click += ResetIdleTimer;
            

            lastActivityTime = DateTime.Now;
        }

        private void UpdateIdleTimeLimit()
        {
            try
            {
                
                int timeoutFromDb = db.GetIdleTimeoutForUser(loggedInUsername);

                
                if (timeoutFromDb > 0)
                {
                    idleTimeLimit = timeoutFromDb; 
                }
                else
                {
                    idleTimeLimit = 600000; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to fetch idle timeout from the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                idleTimeLimit = 600000;
            }
        }

        private void IdleTimer_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - lastActivityTime).TotalMilliseconds > idleTimeLimit)
            {
                
                idleTimer.Stop();
                AutoLogout();
            }
        }

        private void ResetIdleTimer(object sender, EventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        private void AutoLogout()
        {
            idleTimer.Stop();
            
            db.LogAction(loggedInUsername, "Auto Logout", "User was logged out due to inactivity.");

            MessageBox.Show("You have been logged out due to inactivity.", "Auto Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            LoginForm loginForm = new LoginForm();
            this.Close();
            loginForm.Show();
        }

        
        private void LoadComboBoxValues()
        {
            cbeditIDLE.Items.Clear();
            cbeditIDLE.Items.Add("10 sec");
            cbeditIDLE.Items.Add("1 min");
            cbeditIDLE.Items.Add("5 min");
            cbeditIDLE.Items.Add("10 min");
            cbeditIDLE.SelectedIndex = 0; 
        }

        private void LoadData()
        {
            userTable = db.GetUsers();
            DGVusers.DataSource = userTable;

            logsTable = db.Getlogs();
            dgvlogs.DataSource = logsTable;

            if (DGVusers.Columns["status"] != null)
            {
                DGVusers.Columns["status"].HeaderText = "Status";
            }
            else
            {
                MessageBox.Show("The 'status' column is not found.", "Column Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btrefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (DGVusers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGVusers.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string username = selectedRow.Cells["username"].Value.ToString();

                
                var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    db.DeleteUser(id);
                    LoadData(); 
                                
                    db.LogAction(loggedInUsername, "Delete", $"User '{username}' deleted.");
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btedit_Click(object sender, EventArgs e)
        {
            idleTimer.Stop();

            if (DGVusers.SelectedRows.Count > 0)
            {
                
                DataGridViewRow selectedRow = DGVusers.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string username = selectedRow.Cells["username"].Value.ToString();
                string currentPassword = selectedRow.Cells["password"].Value.ToString();

               
                using (var editForm = new EditUserForm(id, username, currentPassword))
                {
                    editForm.LoggedInUsername = loggedInUsername; 
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                       
                        db.UpdateUser(editForm.UserId, editForm.OriginalUsername, editForm.PasswordHash);
                        LoadData(); 
                        db.LogAction(loggedInUsername, "Edit", $"User '{editForm.OriginalUsername}' edited."); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btresetattempt_Click(object sender, EventArgs e)
        {
           
            if (DGVusers.SelectedRows.Count > 0)
            {
               
                DataGridViewRow selectedRow = DGVusers.SelectedRows[0];
                string username = selectedRow.Cells["username"].Value.ToString();

                
                db.UpdateLoginAttempts(username, 0);

               
                MessageBox.Show("Login attempts for the user have been reset.", "Reset Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                LoadData();
                db.LogAction(loggedInUsername, "Reset Attempts", $"Login attempts reset for user '{username}'."); // Log the action
            }
            else
            {
                MessageBox.Show("Please select a user to reset login attempts.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            idleTimer.Stop();
            LoginForm loginF = new LoginForm();
            this.Close();
            loginF.ShowDialog();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            idleTimer.Stop();
            string searchValue = tbsearch.Text.Trim();

            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Please enter a username to search.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool userFound = false;

            foreach (DataGridViewRow row in DGVusers.Rows)
            {
                if (row.Cells["username"].Value != null && row.Cells["username"].Value.ToString().Equals(searchValue, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;  
                    DGVusers.FirstDisplayedScrollingRowIndex = row.Index; 
                    userFound = true;

                    
                    db.LogAction(loggedInUsername, "Search", $"Searched for user '{searchValue}' - Found.");
                    
                    break;
                }
            }

            if (!userFound)
            {
                MessageBox.Show("Username not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                db.LogAction(loggedInUsername, "Search", $"Searched for user '{searchValue}' - Not Found.");
            }

        }

        private void btnstatus_Click(object sender, EventArgs e)
        {
            if (DGVusers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGVusers.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string username = selectedRow.Cells["username"].Value.ToString();
                string currentStatus = selectedRow.Cells["status"].Value.ToString();
                string newStatus = string.Empty;

                
                if (currentStatus == "Pending")
                {
                    newStatus = "Active";
                }
                else if (currentStatus == "Active")
                {
                    newStatus = "Inactive";
                }
                else if (currentStatus == "Inactive")
                {
                    newStatus = "Active";
                }

               
                var result = MessageBox.Show($"Change status to {newStatus}?", "Confirm Status Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    
                    db.UpdateUserStatus(id, newStatus);
                    LoadData(); 
                    db.LogAction(loggedInUsername, "Change Status", $"User '{username}' status changed to {newStatus}."); 
                }
            }
            else
            {
                MessageBox.Show("Please select a user to change the status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            idleTimer.Stop();
            using (var addForm = new adduserForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    idleTimer.Stop();
                    LoadData();
                    db.LogAction(loggedInUsername, "Add", $"New user '{addForm.Username}' added."); 
                }
            }
        }

        private void btnrole_Click(object sender, EventArgs e)
        {
           
            if (DGVusers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGVusers.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string username = selectedRow.Cells["username"].Value.ToString();
                string currentRole = selectedRow.Cells["role"].Value.ToString();
                string newRole = string.Empty;

                
                if (currentRole == "admin")
                {
                    newRole = "user";
                }
                else if (currentRole == "user")
                {
                    newRole = "admin";
                }

               
                var result = MessageBox.Show($"Change role to {newRole}?", "Confirm Role Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                   
                    db.UpdateUserRole(id, newRole);
                    LoadData(); 
                    db.LogAction(loggedInUsername, "Change Role", $"User '{username}' role changed to {newRole}."); 
                }
            }
            else
            {
                MessageBox.Show("Please select a user to change the role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbeditIDLE_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (DGVusers.SelectedRows.Count > 0)
            {
                
                DataGridViewRow selectedRow = DGVusers.SelectedRows[0];
                int userId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                
                string selected = cbeditIDLE.SelectedItem.ToString();
                int idleTimeLimit = 0;

                
                switch (selected)
                {
                    case "10 sec": idleTimeLimit = 10000; break;
                    case "1 min": idleTimeLimit = 60000; break;
                    case "5 min": idleTimeLimit = 300000; break;
                    case "10 min": idleTimeLimit = 600000; break;
                    default: break;
                }

                
                db.SaveIdleTimeout(userId, idleTimeLimit);
               
                db.LogAction(loggedInUsername, "Change Idle Timeout", $"User '{selectedRow.Cells["username"].Value.ToString()}' idle timeout changed to {selected}.");

            }
            
            LoadData();
        } 
    
        private void LoadBackupFiles()
        {
            cbBackupFiles.Items.Clear();
            string[] files = Directory.GetFiles(backupDirectory, "*.sql");
            foreach (string file in files)
            {
                cbBackupFiles.Items.Add(Path.GetFileName(file));
            }

            btnRestore.Enabled = cbBackupFiles.Items.Count > 0;
        }

        private void btnBackup_Click_1(object sender, EventArgs e)
        {
            try
            {
                string backupFile = Path.Combine(backupDirectory, $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql");

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    db.OpenDBBR();
                    cmd.Connection = db.connection;
                    

                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        mb.ExportToFile(backupFile);
                    }

                    db.CloseDBBR();
                    MessageBox.Show($"Backup successful! File: {backupFile}", "Backup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBackupFiles();
                    
                    db.LogAction(loggedInUsername, "Backup", $"Database backup created: {backupFile}");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Backup failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                db.LogAction(loggedInUsername, "Backup", $"Database backup failed: {ex.Message}");
            }
        }

  

        private void btnRestore_Click_1(object sender, EventArgs e)
        {
            if (cbBackupFiles.SelectedItem == null)
            {
                MessageBox.Show("Please select a backup file to restore.", "No Backup Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedBackup = Path.Combine(backupDirectory, cbBackupFiles.SelectedItem.ToString());

            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    db.OpenDBBR();
                    cmd.Connection = db.connection;
                    
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        mb.ImportFromFile(selectedBackup);
                    }

                    db.CloseDBBR();
                    MessageBox.Show($"Restore successful from file: {selectedBackup}", "Restore Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    
                    db.LogAction(loggedInUsername, "Restore", $"Database restored from file: {selectedBackup}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Restore failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                db.LogAction(loggedInUsername, "Restore", $"Database restore failed: {ex.Message}");
            }

        


        }

        private void btnaudits_Click(object sender, EventArgs e)
        {
            //first click send forward the panel, second click send back the panel
            if (panellogs.Visible == true)
            {
                panellogs.Visible = false;
            }
            else
            {
                panellogs.Visible = true;
            }


        }
    }
}
