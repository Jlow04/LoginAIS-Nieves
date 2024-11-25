using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private Timer idleTimer;
        private int userId; // Set this to the logged-in user's ID
        private int idleTimeLimit;
        private DateTime lastActivity;

        public HomeForm(string user, int userId)
        {
            InitializeComponent();
            username = user;
            GenerateNewAccessCode();

            this.userId = userId; // Set the user ID here
            // Initialize ComboBox options
            CBIDLE.Items.AddRange(new object[] { "10 sec", "1 min", "5 min", "10 min" });
            CBIDLE.SelectedIndexChanged += ComboBoxTimeout_SelectedIndexChanged;


            // Load user-specific idle timeout setting
            idleTimeLimit = db.LoadIdleTimeoutSetting(userId);
            SetComboBoxSelectionFromTimeout(idleTimeLimit);

            // Set up the idle timer
            idleTimer = new Timer();
            idleTimer.Interval = 1000; // Check every second
            idleTimer.Tick += IdleTimer_Tick;
            ResetIdleTimer();
            idleTimer.Start();

            // Track user activity
            this.MouseMove += MainForm_MouseMove;
            this.KeyPress += MainForm_KeyPress;
        }

        private void ComboBoxTimeout_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = CBIDLE.SelectedItem.ToString();
            switch (selected)
            {
                case "10 sec": idleTimeLimit = 10000; break;
                case "1 min": idleTimeLimit = 60000; break;
                case "5 min": idleTimeLimit = 300000; break;
                case "10 min": idleTimeLimit = 600000; break;
            }

            // Save the new setting to the database
            db.SaveIdleTimeoutSetting(userId, idleTimeLimit);
            ResetIdleTimer();
            //logaction
            db.LogAction(username, "Change Idle Timeout", $"User '{username}' changed the idle timeout to {selected}.");

        }

        private void IdleTimer_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - lastActivity).TotalMilliseconds >= idleTimeLimit)
            {
                AutoLogout();
            }
        }

        private void AutoLogout()
        {
            idleTimer.Stop();
            MessageBox.Show($"You have been logged out due to inactivity. Here is the new code:'{newAccessCode}'");

            Clipboard.SetText(newAccessCode);
            MessageBox.Show("New Access Code Copied!", "Copy Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Code to log out user and redirect to login form
            LoginForm loginForm = new LoginForm();
            this.Close();
            loginForm.Show();
            
            //logaction
            db.LogAction(username, "Auto Logout", $"User '{username}' was automatically logged out due to inactivity.");
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            ResetIdleTimer();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            ResetIdleTimer();
        }

        private void ResetIdleTimer()
        {
            lastActivity = DateTime.Now;
        }

        private void SetComboBoxSelectionFromTimeout(int timeout)
        {
            switch (timeout)
            {
                case 10000: CBIDLE.SelectedItem = "10 sec"; break;
                case 60000: CBIDLE.SelectedItem = "1 min"; break;
                case 300000: CBIDLE.SelectedItem = "5 min"; break;
                case 600000: CBIDLE.SelectedItem = "10 min"; break;
            }
        }
    


        private void GenerateNewAccessCode()
        {
            newAccessCode = GenerateAccessCode();
            tbcode.Text = newAccessCode;
            db.UpdateAccessCode(username, newAccessCode); // Update in database
            db.LogAction(username, "Generate New Access Code", $"User '{username}' generated a new access code: {newAccessCode}.");
        }
        private string GenerateAccessCode()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 9999).ToString(); // Generates a 4-digit random number

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            idleTimer.Stop();
            if (Clipboard.GetText() != newAccessCode)
            {
                MessageBox.Show("Please copy the new access code before logging out.", "Copy Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Log the action
                db.LogAction(username, "Logout", $"User '{username}' logged out.");
                LoginForm loginForm = new LoginForm();
                this.Close();
                loginForm.Show();

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
