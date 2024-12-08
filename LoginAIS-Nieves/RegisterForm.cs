using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoginAIS_Nieves
{
    public partial class RegisterForm : Form
    {
        dbconnect db = new dbconnect();
        public RegisterForm()
        {
            InitializeComponent();
            tbpasswordR.Enter += tbpasswordR_Enter;
            tbpasswordR.Leave += tbpasswordR_Leave;

        }

        private void btnregister_Click(object sender, EventArgs e)
        {
           
            string username = tbusernameR.Text;
            string password = tbpasswordR.Text;
            string confirmPassword = tbconfirmpasswordR.Text;

            
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (IsUsernameTaken(username))
            {
                MessageBox.Show("Username is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.LogAction(username, "Register", $"Registration attempt failed: Username '{username}' is already taken."); // Log the action
                return;
            }

            string passwordStrength = CheckPasswordStrength(password);
            if (passwordStrength != "Strong")
            {
                MessageBox.Show("Password is too weak! Please make sure it is strong.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.LogAction(username, "Register", $"Registration attempt failed: Password for '{username}' is weak."); // Log the action
                return;
            }

            
            
            RegisterNewUser(username, password);
            

        }


        private void tbconfirmpasswordR_TextChanged(object sender, EventArgs e)
        {
            if (tbpasswordR.Text != tbconfirmpasswordR.Text)
            {
                lblPasswordMatch.Text = "Passwords do not match";
                lblPasswordMatch.ForeColor = Color.Red;
            }
            else
            {
                lblPasswordMatch.Text = "Passwords match";
                lblPasswordMatch.ForeColor = Color.Green;
            }
        }


        private bool IsUsernameTaken(string username)
        {
            DataTable dt = db.Login();  

            foreach (DataRow row in dt.Rows)
            {
                if (row["username"].ToString() == username)
                {
                    return true;  
                }
            }
            return false;  
        }

        private void RegisterNewUser(string username, string password)
        {
            try
            {
                db.OpenDB();

                
                string encryptedPassword = EncryptionHelper.HashPassword(password);

                
                string sql = "INSERT INTO users (username, password, role) VALUES (@username, @password, 'user')";
                MySqlCommand cmd = new MySqlCommand(sql, db.connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", encryptedPassword);
                cmd.ExecuteNonQuery();

                db.CloseDB();

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.LogAction(username, "Register", $"User '{username}' registered successfully."); 

                
                this.Hide();
                LoginForm login = new LoginForm();
                login.ShowDialog();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isPasswordVisible = false;
        private void btnshownhideR_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                tbpasswordR.UseSystemPasswordChar = true;
                tbconfirmpasswordR.UseSystemPasswordChar = true;

            }
            else
            {
                tbpasswordR.UseSystemPasswordChar = false;
                tbconfirmpasswordR.UseSystemPasswordChar = false;

            }
            isPasswordVisible = !isPasswordVisible;
        }

        private void tbpasswordR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                lbcapslockR.Text = "CapsLock is ON";
                lbcapslockR.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lbcapslockR.Text = string.Empty; 
            }
        }

        
        private string CheckPasswordStrength(string password)
        {
            int score = 0;

           
            if (password.Length >= 8) score++;

            
            if (Regex.IsMatch(password, @"[a-z]") && Regex.IsMatch(password, @"[A-Z]")) score++;

           
            if (Regex.IsMatch(password, @"\d")) score++;

           
            if (Regex.IsMatch(password, @"!@#\$%\^&\*\(\)_\+\-=\[\]{};':\\|,.<>\/?" ) ) score++;

            
            if (score == 3) return "Strong";
            if (score == 2) return "Medium";
            return "Weak";
        }

        
        private void tbpasswordR_TextChanged(object sender, EventArgs e)
        {
            string password = tbpasswordR.Text;
            string strength = CheckPasswordStrength(password);

            lblPasswordStrength.Text = $"Password Strength: {strength}";

            
            if (strength == "Strong")
            {
                lblPasswordStrength.ForeColor = System.Drawing.Color.Green;
            }
            else if (strength == "Medium")
            {
                lblPasswordStrength.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                lblPasswordStrength.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btcancelR_Click(object sender, EventArgs e)
        {
            LoginForm loginF = new LoginForm();
            this.Hide();
            loginF.ShowDialog();

        }
        
        private void btncopyreg_Click(object sender, EventArgs e)
        {   
        }

        private void btngeneratecode_Click(object sender, EventArgs e)
        {
 
        }

        private void tbpasswordR_Click(object sender, EventArgs e)
        {
           
        }

        private void tbpasswordR_Enter(object sender, EventArgs e)
        {
            
            lbpasswordstr.Text = "A strong password is:At least 8 characters,\na combination of uppercase letters,\nlowercase letters, numbers, and symbols.";
            lbpasswordstr.ForeColor = System.Drawing.Color.Black;
        }

        private void tbpasswordR_Leave(object sender, EventArgs e)
        {
            
            lbpasswordstr.Text = string.Empty;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
