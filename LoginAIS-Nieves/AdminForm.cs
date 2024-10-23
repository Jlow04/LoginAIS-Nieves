using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public AdminForm()
        {
            InitializeComponent();
            LoadData(); // Load data when the form is initialized
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

                // Confirm delete
                var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    db.DeleteUser(id);
                    LoadData(); // Reload data after delete
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
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update the user with new hashed password
                        db.UpdateUser(editForm.UserId, editForm.Username, editForm.Password);
                        LoadData(); // Reload the updated data
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
                db.UpdateLoginAttempts(username, 0, null);

                // Inform the user
                MessageBox.Show("Login attempts for the user have been reset.", "Reset Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh DataGridView
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a user to reset login attempts.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                    break;
                }
            }

            if (!userFound)
            {
                MessageBox.Show("Username not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnstatus_Click(object sender, EventArgs e)
        {
            if (DGVusers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGVusers.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
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
                }
            }
        }
    }
}
