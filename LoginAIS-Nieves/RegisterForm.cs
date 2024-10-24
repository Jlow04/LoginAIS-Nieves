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
            // Get the username and password from the textboxes
            string username = tbusernameR.Text;
            string password = tbpasswordR.Text;
            string confirmPassword = tbconfirmpasswordR.Text;

            // Validate that the fields are not empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if username already exists
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

            
            // Register the user using the provided method
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
            DataTable dt = db.Login();  // Fetch users from the database

            foreach (DataRow row in dt.Rows)
            {
                if (row["username"].ToString() == username)
                {
                    return true;  // Username is already taken
                }
            }
            return false;  // Username is available
        }

        private void RegisterNewUser(string username, string password)
        {
            try
            {
                db.OpenDB();

                // Encrypt the password before saving
                string encryptedPassword = EncryptionHelper.HashPassword(password);

                // Default role is 'user' for newly registered users
                string sql = "INSERT INTO users (username, password, role) VALUES (@username, @password, 'user')";
                MySqlCommand cmd = new MySqlCommand(sql, db.connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", encryptedPassword);
                cmd.ExecuteNonQuery();

                db.CloseDB();

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.LogAction(username, "Register", $"User '{username}' registered successfully."); // Log successful registration

                // Close the registration form and go back to the login form
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
                lbcapslockR.Text = string.Empty;  // Clear the label if CapsLock is off
            }
        }

        // Password strength checker logic
        private string CheckPasswordStrength(string password)
        {
            int score = 0;

            // If password is 8 characters or more
            if (password.Length >= 8) score++;

            // If password contains both upper and lower case characters
            if (Regex.IsMatch(password, @"[a-z]") && Regex.IsMatch(password, @"[A-Z]")) score++;

            // If it contains numbers
            if (Regex.IsMatch(password, @"\d")) score++;

            // If it contains special characters
            if (Regex.IsMatch(password, @"!@#\$%\^&\*\(\)_\+\-=\[\]{};':\\|,.<>\/?" ) ) score++;

            // Determine strength based on score
            if (score == 3) return "Strong";
            if (score == 2) return "Medium";
            return "Weak";
        }

        // Real-time password strength display
        private void tbpasswordR_TextChanged(object sender, EventArgs e)
        {
            string password = tbpasswordR.Text;
            string strength = CheckPasswordStrength(password);

            lblPasswordStrength.Text = $"Password Strength: {strength}";

            // Color feedback
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
            // Display the password strength message when the textbox is in use.
            lbpasswordstr.Text = "A strong password is:At least 8 characters,\na combination of uppercase letters,\nlowercase letters, numbers, and symbols.";
            lbpasswordstr.ForeColor = System.Drawing.Color.Black;
        }

        private void tbpasswordR_Leave(object sender, EventArgs e)
        {
            // Hide the message when the user leaves the textbox.
            lbpasswordstr.Text = string.Empty;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
