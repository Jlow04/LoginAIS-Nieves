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
    public partial class HomeForm : Form
    {
        private dbconnect db = new dbconnect();
        private string username;
        private string newAccessCode;

        public HomeForm(string user)
        {
            InitializeComponent();
            username = user;
            GenerateNewAccessCode();
        }
        private void GenerateNewAccessCode()
        {
            newAccessCode = GenerateAccessCode();
            tbcode.Text = newAccessCode;
            db.UpdateAccessCode(username, newAccessCode); // Update in database
        }
        private string GenerateAccessCode()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 9999).ToString(); // Generates a 4-digit random number
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetText() != newAccessCode)
            {
                MessageBox.Show("Please copy the new access code before logging out.", "Copy Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void btncopycode_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(newAccessCode);
            MessageBox.Show("New Access Code Copied!", "Copy Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            lbwelcome.Text = $"Welcome {username} to Home Page!";
        }

        private void btnnewcode_Click(object sender, EventArgs e)
        {

        }
    }
}
