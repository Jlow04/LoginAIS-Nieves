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
        public int UserId { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public EditUserForm()
        {
            InitializeComponent();
        }

        public EditUserForm(int userId, string username, string password)
        {
            InitializeComponent();
            UserId = userId;
            Username = username;
            Password = password;
            EDITusername.Text = username;
            EDITpassword.Text = password;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Username = EDITusername.Text;

            // Encrypt the password before saving
            Password = HashPassword(EDITpassword.Text);

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
                    builder.Append(b.ToString("x2")); // Convert byte to hex string
                }
                return builder.ToString();
            }
        }
    }
}
