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

        private const int maxAttempts = 3;  

        
        private Dictionary<string, int> loginAttempts = new Dictionary<string, int>();

 
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbusername.Text;
            string password = tbpassword.Text;
            string accessCode = tbcodelog.Text; 

            DataTable userTable = db.GetUserAttemps(username);

            if (userTable.Rows.Count == 0)
            {
                MessageBox.Show("Username not found!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.LogAction(username, "Login Attempt", "Failed - Username not found");
                return;
            }


            
            DataRow user = userTable.Rows[0];
            int loginAttempts = Convert.ToInt32(user["login_attempts"]);
            string status = user["status"].ToString();
  

            
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

            
            if (AuthenticateUser(username, password, accessCode))
            {
               
                string role = user["role"].ToString();

                
                db.UpdateLoginAttempts(username, 0); 

                db.LogAction(username, "Login Attempt", "Successful");

                if (role == "admin")
                {
                    AdminForm adminForm = new AdminForm(username);
                    adminForm.Show();
                }
                else if (role == "user")
                {
                    MessageBox.Show("Successfully Logged in!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int loggedInUserId = db.GetUserId(username); 
                    HomeForm homePage = new HomeForm(username, loggedInUserId);
                    homePage.Show(); 
                }
                this.Hide();  
            }
            else
            {
                loginAttempts++;

                if (loginAttempts >= maxAttempts)
                {
                    
                    db.UpdateUserStatus(Convert.ToInt32(user["id"]), "Inactive");
                    db.UpdateLoginAttempts(username, loginAttempts);
                    MessageBox.Show("Too many failed login attempts. Your account has been deactivated. Please contact the admin to regain access.", "Account Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    db.LogAction(username, "Login Attempt", "Failed - Account inactive due to too many failed attempts");
                }

                else
                {
                   
                    db.UpdateLoginAttempts(username, loginAttempts);
                    MessageBox.Show($"Invalid Username, Password or Access Code! {maxAttempts - loginAttempts} attempts remaining.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     db.LogAction(username, "Login Attempt", "Failed - Invalid credentials");
                }
            }
        }

        
        private bool AuthenticateUser(string username, string password, string accessCode)
        {
            DataTable dt = db.Login();  

            foreach (DataRow row in dt.Rows)
            {
                string encryptedPassword = EncryptionHelper.HashPassword(password);

                
                if (row["username"].ToString() == username && row["password"].ToString() == encryptedPassword && row["access_code"].ToString() == accessCode)
                {
                    
                    return true;
                }
            }

            
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
                lbcapslock.Text = string.Empty;  
            }
        }

        private void lbregister_Click(object sender, EventArgs e)
        {
           
            RegisterForm registerForm = new RegisterForm();
            this.Hide(); 
            registerForm.ShowDialog(); 
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }

        private void lbtxtfogot_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Please contact the admin to recover your account/password/code. Email address: ExampleAdmin@gmail.com", "Account Recovery", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText("ExampleAdmin@gmail.com");
            MessageBox.Show("Email Address Copied!", "Copy Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}


