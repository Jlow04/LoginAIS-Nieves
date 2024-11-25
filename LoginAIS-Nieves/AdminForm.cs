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
        
        dbconnect db = new dbconnect(); // Initialize the dbconnect object
        DataTable userTable; // Store the data retrieved from the database
        private string loggedInUsername;
        private int selectedUserId; // Store the selected user ID

        private Timer idleTimer; // Timer to track inactivity
        private int idleTimeLimit; // In milliseconds
        private DateTime lastActivityTime; // Track the last activity time

        // Fixed path for storing backups
        private string backupDirectory = @"C:\Users\hp\Desktop\DBBackups";
        public AdminForm(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            LoadData(); // Load data when the form is initialized

            // Create backup directory if it doesn't exist
            if (!Directory.Exists(backupDirectory))
            {
                Directory.CreateDirectory(backupDirectory);
            }

            LoadBackupFiles();

            // Initialize idle timeout settings
            InitializeIdleTimeout();


            // Set placeholder text for the TextBox
            tbsearch.Text = "Search🔍";
            tbsearch.ForeColor = Color.Gray;

            // Handle the Enter and Leave events to manage the placeholder text
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
            
            // Populate ComboBox with timeout values
            LoadComboBoxValues();

        }

        private void InitializeIdleTimeout()
        {
            // Set default idle time limit based on ComboBox selection
            UpdateIdleTimeLimit();

            // Create and configure the idle timer
            idleTimer = new Timer();
            idleTimer.Interval = 1000; // Check every second
            idleTimer.Tick += IdleTimer_Tick;
            idleTimer.Start();

            // Track user activity through global events
            this.MouseMove += ResetIdleTimer;
            this.KeyPress += ResetIdleTimer;

            // Record the initial last activity time
            lastActivityTime = DateTime.Now;
        }

        private void UpdateIdleTimeLimit()
        {
            try
            {
                // Fetch idle timeout value for the logged-in admin from the database
                int timeoutFromDb = db.GetIdleTimeoutForUser(loggedInUsername);

                // Validate the value from the database
                if (timeoutFromDb > 0)
                {
                    idleTimeLimit = timeoutFromDb; // Set the value from the database
                }
                else
                {
                    idleTimeLimit = 60000; // Default to 1 minute if invalid value retrieved
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to fetch idle timeout from the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                idleTimeLimit = 60000; // Fallback to default value
            }
        }

        private void IdleTimer_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - lastActivityTime).TotalMilliseconds > idleTimeLimit)
            {
                // Perform auto-logout
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
            // Log the auto-logout action
            db.LogAction(loggedInUsername, "Auto Logout", "User was logged out due to inactivity.");

            MessageBox.Show("You have been logged out due to inactivity.", "Auto Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Navigate back to the login form
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
            cbeditIDLE.SelectedIndex = 0; // Default value
        }

        private void LoadData()
        {
            userTable = db.GetUsers();
            DGVusers.DataSource = userTable;
            // Make sure the "status" column exists in your DataTable
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
            LoadData(); // Refresh the data grid view
            
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (DGVusers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGVusers.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string username = selectedRow.Cells["username"].Value.ToString();

                // Confirm delete
                var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    db.DeleteUser(id);
                    LoadData(); // Reload data after delete
                                // Log the delete action
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
            if (DGVusers.SelectedRows.Count > 0)
            {
                // Get selected user details
                DataGridViewRow selectedRow = DGVusers.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string username = selectedRow.Cells["username"].Value.ToString();
                string currentPassword = selectedRow.Cells["password"].Value.ToString();

                // Open the EditUserForm
                using (var editForm = new EditUserForm(id, username, currentPassword))
                {
                    editForm.LoggedInUsername = loggedInUsername; // Pass the logged-in username
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the user with new hashed password
                        db.UpdateUser(editForm.UserId, editForm.OriginalUsername, editForm.PasswordHash);
                        LoadData(); // Reload the updated data
                        db.LogAction(loggedInUsername, "Edit", $"User '{editForm.OriginalUsername}' edited."); // Log the action
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
            // Check if a row is selected
            if (DGVusers.SelectedRows.Count > 0)
            {
                // Get the username of the selected user
                DataGridViewRow selectedRow = DGVusers.SelectedRows[0];
                string username = selectedRow.Cells["username"].Value.ToString();

                // Reset login attempts and lockout status in the database
                db.UpdateLoginAttempts(username, 0);

                // Inform the user
                MessageBox.Show("Login attempts for the user have been reset.", "Reset Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh DataGridView
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
            string searchValue = tbsearch.Text.Trim(); // Get the search value from the textbox

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
                    row.Selected = true;  // Highlight the entire row
                    DGVusers.FirstDisplayedScrollingRowIndex = row.Index; // Scroll to the row if it's not visible
                    userFound = true;

                    // Log the successful search action
                    db.LogAction(loggedInUsername, "Search", $"Searched for user '{searchValue}' - Found.");
                    
                    break;
                }
            }

            if (!userFound)
            {
                MessageBox.Show("Username not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Log the unsuccessful search action
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

                // Toggle status based on current status
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

                // Confirm status change
                var result = MessageBox.Show($"Change status to {newStatus}?", "Confirm Status Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Update status in the database
                    db.UpdateUserStatus(id, newStatus);
                    LoadData(); // Refresh the data grid view
                    db.LogAction(loggedInUsername, "Change Status", $"User '{username}' status changed to {newStatus}."); // Log the action
                }
            }
            else
            {
                MessageBox.Show("Please select a user to change the status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //add new user

            // Open the AddUserForm
            using (var addForm = new adduserForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    // Reload data to reflect the new user
                    LoadData();
                    db.LogAction(loggedInUsername, "Add", $"New user '{addForm.Username}' added."); // Log the action
                }
            }
        }

        private void btnrole_Click(object sender, EventArgs e)
        {
            // it will change role of the selected user in the dgv
            if (DGVusers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGVusers.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string username = selectedRow.Cells["username"].Value.ToString();
                string currentRole = selectedRow.Cells["role"].Value.ToString();
                string newRole = string.Empty;

                // Toggle role based on current role
                if (currentRole == "admin")
                {
                    newRole = "user";
                }
                else if (currentRole == "user")
                {
                    newRole = "admin";
                }

                // Confirm role change
                var result = MessageBox.Show($"Change role to {newRole}?", "Confirm Role Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Update role in the database
                    db.UpdateUserRole(id, newRole);
                    LoadData(); // Refresh the data grid view
                    db.LogAction(loggedInUsername, "Change Role", $"User '{username}' role changed to {newRole}."); // Log the action
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
                // Get the selected user's ID
                DataGridViewRow selectedRow = DGVusers.SelectedRows[0];
                int userId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                // Get the selected idle timeout value
                string selected = cbeditIDLE.SelectedItem.ToString();
                int idleTimeLimit = 0;

                // Convert the selected value to milliseconds
                switch (selected)
                {
                    case "10 sec": idleTimeLimit = 10000; break;
                    case "1 min": idleTimeLimit = 60000; break;
                    case "5 min": idleTimeLimit = 300000; break;
                    case "10 min": idleTimeLimit = 600000; break;
                    default: break;
                }

                // Save the new idle timeout value to the database
                db.SaveIdleTimeout(userId, idleTimeLimit);
                //logaction
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
                    //logaction
                    db.LogAction(loggedInUsername, "Backup", $"Database backup created: {backupFile}");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Backup failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //logaction
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
                    //logaction
                    db.LogAction(loggedInUsername, "Restore", $"Database restored from file: {selectedBackup}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Restore failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //logaction
                db.LogAction(loggedInUsername, "Restore", $"Database restore failed: {ex.Message}");
            }

        


        }
    }
}
