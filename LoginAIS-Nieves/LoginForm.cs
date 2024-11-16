using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAIS_Nieves
{
    public partial class LoginForm : Form
    {
        dbconnect db = new dbconnect();

        private const int maxAttempts = 3;  // Maximum allowed login attempts

        // Dictionary to store failed login attempts per user
        private Dictionary<string, int> loginAttempts = new Dictionary<string, int>();

 
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbusername.Text;
            string password = tbpassword.Text;
            string accessCode = tbcodelog.Text; // Access code input from user

            DataTable userTable = db.GetUserAttemps(username);

            if (userTable.Rows.Count == 0)
            {
                MessageBox.Show("Username not found!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.LogAction(username, "Login Attempt", "Failed - Username not found");
                return;
            }


            // Get login attempt
            DataRow user = userTable.Rows[0];
            int loginAttempts = Convert.ToInt32(user["login_attempts"]);
            string status = user["status"].ToString();
  

            // Check the user's status
            if (status == "Pending")
            {
                MessageBox.Show("Your account is pending approval by the admin.", "Account Pending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.LogAction(username, "Login Attempt", "Failed - Account pending approval");
                return;
            }
            else if (status == "Inactive")
            {
                MessageBox.Show("Your account is inactive. Please contact the admin.", "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.LogAction(username, "Login Attempt", "Failed - Account inactive");
                return;
            }

            // Authenticate the user (including access code check)
            if (AuthenticateUser(username, password, accessCode))
            {
                // Fetch the user's role from the database
                string role = user["role"].ToString();

                // Successful login: Reset login attempts and lockout information
                db.UpdateLoginAttempts(username, 0); // Reset attempts 

                db.LogAction(username, "Login Attempt", "Successful");

                if (role == "admin")
                {
                    AdminForm adminForm = new AdminForm(username);
                    adminForm.Show();
                }
                else if (role == "user")
                {
                    MessageBox.Show("Successfully Logged in!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int loggedInUserId = db.GetUserId(username); // Adjust based on your login method
                    HomeForm homePage = new HomeForm(username, loggedInUserId);
                    homePage.Show(); // Show the HomePage form for regular users
                }
                this.Hide();  // Hide the login form
            }
            else
            {
                loginAttempts++;

                if (loginAttempts >= maxAttempts)
                {
                    // Mark the account as inactive
                    db.UpdateUserStatus(Convert.ToInt32(user["id"]), "Inactive");
                    db.UpdateLoginAttempts(username, loginAttempts);
                    MessageBox.Show("Too many failed login attempts. Your account has been deactivated. Please contact the admin to regain access.", "Account Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    db.LogAction(username, "Login Attempt", "Failed - Account inactive due to too many failed attempts");
                }

                else
                {
                    // Update login attempts without deactivating the account
                    db.UpdateLoginAttempts(username, loginAttempts);
                    MessageBox.Show($"Invalid Username, Password or Access Code! {maxAttempts - loginAttempts} attempts remaining.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     db.LogAction(username, "Login Attempt", "Failed - Invalid credentials");
                }
            }
        }

        // Method to authenticate user with username, password, and access code
        private bool AuthenticateUser(string username, string password, string accessCode)
        {
            DataTable dt = db.Login();  // Fetch users from the database

            foreach (DataRow row in dt.Rows)
            {
                string encryptedPassword = EncryptionHelper.HashPassword(password);

                // Check if the username, hashed password, and access code match
                if (row["username"].ToString() == username && row["password"].ToString() == encryptedPassword && row["access_code"].ToString() == accessCode)
                {
                    // Successful authentication
                    return true;
                }
            }

            // If no match is found, return false
            return false;
        }

        private bool isPasswordVisible = false;

        private void btnshownhide_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                tbpassword.UseSystemPasswordChar = true;  
                
            }
            else
            {
                tbpassword.UseSystemPasswordChar = false;
                
            }
            isPasswordVisible = !isPasswordVisible;
        }

        private void tbpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                lbcapslock.Text = "CapsLock is ON";
                lbcapslock.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lbcapslock.Text = string.Empty;  // Clear the label if CapsLock is off
            }
        }

        private void lbregister_Click(object sender, EventArgs e)
        {
            // Open the RegisterForm
            RegisterForm registerForm = new RegisterForm();
            this.Hide(); 
            registerForm.ShowDialog(); // Show the register form as a dialog
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Ensure the application exits when the form is closed
        }

        private void lbtxtfogot_Click(object sender, EventArgs e)
        {
            //msgbox forgot password contact admin. email address: ExampleAdmin@gmail.com
            MessageBox.Show("Please contact the admin to recover your account/password/code. Email address: ExampleAdmin@gmail.com", "Account Recovery", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText("ExampleAdmin@gmail.com");
            MessageBox.Show("Email Address Copied!", "Copy Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}


