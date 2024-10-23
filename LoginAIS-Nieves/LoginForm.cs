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

        // Dictionary to store lockout expiration time per user
        private Dictionary<string, DateTime> lockoutEndTime = new Dictionary<string, DateTime>();

        // Timer to check lockout expiration (optional)
        private Timer lockoutTimer;

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
                return;
            }


            // Get login attempt and lockout information
            DataRow user = userTable.Rows[0];
            int loginAttempts = Convert.ToInt32(user["login_attempts"]);
            DateTime? lockoutUntil = user.IsNull("lockout_until") ? (DateTime?)null : Convert.ToDateTime(user["lockout_until"]);
            string status = user["status"].ToString();

            // Check if the account is locked
            if (lockoutUntil.HasValue && lockoutUntil > DateTime.Now)
            {
                MessageBox.Show($"Account is locked until {lockoutUntil}. Please try again later.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check the user's status
            if (status == "Pending")
            {
                MessageBox.Show("Your account is pending approval by the admin.", "Account Pending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (status == "Inactive")
            {
                MessageBox.Show("Your account is inactive. Please contact the admin.", "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Authenticate the user (including access code check)
            if (AuthenticateUser(username, password, accessCode))
            {
                // Fetch the user's role from the database
                string role = user["role"].ToString();

                // Successful login: Reset login attempts and lockout information
                db.UpdateLoginAttempts(username, loginAttempts, null); // Reset attempts and lockout time

                if (role == "admin")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else if (role == "user")
                {
                    MessageBox.Show("Successfully Logged in!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HomeForm homePage = new HomeForm(username);
                    homePage.Show(); // Show the HomePage form for regular users
                }
                this.Hide();  // Hide the login form
            }
            else
            {
                // Handle failed login attempts
                loginAttempts++;

                if (loginAttempts >= maxAttempts)
                {
                    // Lock the account for 1 minute
                    DateTime lockoutUntilTime = DateTime.Now.AddMinutes(1);
                    db.UpdateLoginAttempts(username, loginAttempts, lockoutUntilTime);

                    MessageBox.Show($"Too many failed login attempts. Your account is locked for 1 minute.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Update login attempts without locking the account
                    db.UpdateLoginAttempts(username, loginAttempts, null);
                    MessageBox.Show($"Invalid Username, Password or Access Code! {maxAttempts - loginAttempts} attempts remaining.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

            // Method to authenticate user with username, password, and access code
            private bool AuthenticateUser(string username, string password, string accessCode)
        {
            DataTable dt = db.Login();  // Fetch users from the database

            if (username == "admin" && password == "admin")
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["username"].ToString() == username && row["password"].ToString() == password && row["access_code"].ToString() == accessCode)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    string encryptedPassword = EncryptionHelper.HashPassword(password);

                    // Check if the username, hashed password, and access code match
                    if (row["username"].ToString() == username && row["password"].ToString() == encryptedPassword && row["access_code"].ToString() == accessCode)
                    {
                        return true;
                    }
                }

                return false;
            }

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

      

       


       
        
    }
}


