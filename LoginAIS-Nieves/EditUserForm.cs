﻿using System;
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
        dbconnect db = new dbconnect(); // Initialize the dbconnect object
        public string LoggedInUsername { get; set; } // Property to hold the logged-in user

        public int UserId { get; private set; }
        public string OriginalUsername { get; private set; }  // Store the original username
        public string PasswordHash { get; private set; } // Store the original password hash

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
            EDITpassword.Text = ""; // Do not show the hashed password
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            // Only update the username if it has changed
            string newUsername = EDITusername.Text.Trim();
            if (newUsername != OriginalUsername)
            {
                // Logic to update the username in the database or wherever necessary
                OriginalUsername = newUsername;
                db.LogAction(LoggedInUsername, "Edit", $"Username changed from '{OriginalUsername}' to '{newUsername}'."); // Log the action
            }

            // If the password field is not empty, hash the new password
            if (!string.IsNullOrWhiteSpace(EDITpassword.Text))
            {
                PasswordHash = HashPassword(EDITpassword.Text);
                db.LogAction(LoggedInUsername, "Edit", "Password updated."); // Log the password change
            }

            // Logic to save changes to the database or wherever necessary
            // This can include saving newUsername and PasswordHash

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
