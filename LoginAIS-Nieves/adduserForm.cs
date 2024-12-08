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

namespace LoginAIS_Nieves
{
    public partial class adduserForm : Form
    {
        
        dbconnect db = new dbconnect();
        AdminForm adForm = new AdminForm("user");
       
        public string Username { get; private set; } 

        public adduserForm()
        {
            InitializeComponent();
        }

        private void adduserForm_Load(object sender, EventArgs e)
        {

        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            string username = ADDusername.Text.Trim();
            string password = ADDpassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsUsernameTaken(username))
            {
                MessageBox.Show("Username already exists. Please choose a different one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string passwordStrength = CheckPasswordStrength(password);
            if (passwordStrength != "Strong")
            {
                MessageBox.Show("Password is too weak! Please provide a strong password.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegisterNewUser(username, password);
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private bool IsUsernameTaken(string username)
        {
            DataTable dt = db.Login(); 

            foreach (DataRow row in dt.Rows)
            {
                if (row["username"].ToString().Equals(username, StringComparison.OrdinalIgnoreCase))
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

                string sql = "INSERT INTO users (username, password, role, status) VALUES (@username, @password, 'user', 'Pending')";
                MySqlCommand cmd = new MySqlCommand(sql, db.connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", encryptedPassword);
                cmd.ExecuteNonQuery();

                db.CloseDB();
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CheckPasswordStrength(string password)
        {
            int score = 0;

            
            if (password.Length >= 8) score++;

            
            if (Regex.IsMatch(password, @"[a-z]") && Regex.IsMatch(password, @"[A-Z]")) score++;

           
            if (Regex.IsMatch(password, @"\d")) score++;

            
            if (Regex.IsMatch(password, @"!@#\$%\^&\*\(\)_\+\-=\[\]{};':\\|,.<>\/?")) score++;

            
            if (score == 3) return "Strong";
            if (score == 2) return "Medium";
            return "Weak";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btncancel_Click_1(object sender, EventArgs e)
        {
           
            this.Hide();
            
        }
    }
}
