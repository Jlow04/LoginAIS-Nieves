using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAIS_Nieves
{

    public partial class EditUserForm : Form

    {
        dbconnect db = new dbconnect(); 
        public string LoggedInUsername { get; set; } 

        public int UserId { get; private set; }
        public string OriginalUsername { get; private set; }  
        public string PasswordHash { get; private set; } 

        public EditUserForm()
        {
            InitializeComponent();
        }

        public EditUserForm(int userId, string username, string passwordHash)
        {
            InitializeComponent();
            UserId = userId;
            OriginalUsername = username;
            PasswordHash = passwordHash;
            EDITusername.Text = username;
            EDITpassword.Text = ""; 
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            
            string newUsername = EDITusername.Text.Trim();
            if (newUsername != OriginalUsername)
            {
                
                OriginalUsername = newUsername;
                db.LogAction(LoggedInUsername, "Edit", $"Username changed from '{OriginalUsername}' to '{newUsername}'."); // Log the action
            }

           
            if (!string.IsNullOrWhiteSpace(EDITpassword.Text))
            {
                PasswordHash = HashPassword(EDITpassword.Text);
                db.LogAction(LoggedInUsername, "Edit", "Password updated."); 
            }

           
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); 
                }
                return builder.ToString();
            }
        }
    }
}
