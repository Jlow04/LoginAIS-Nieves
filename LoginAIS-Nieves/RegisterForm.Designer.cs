namespace LoginAIS_Nieves
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbreg = new System.Windows.Forms.Label();
            this.lbpassR = new System.Windows.Forms.Label();
            this.lbuserR = new System.Windows.Forms.Label();
            this.tbpasswordR = new System.Windows.Forms.TextBox();
            this.tbusernameR = new System.Windows.Forms.TextBox();
            this.btnregister = new System.Windows.Forms.Button();
            this.btcancelR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbconfromR = new System.Windows.Forms.Label();
            this.tbconfirmpasswordR = new System.Windows.Forms.TextBox();
            this.lblcode = new System.Windows.Forms.Label();
            this.lbcapslockR = new System.Windows.Forms.Label();
            this.lblPasswordStrength = new System.Windows.Forms.Label();
            this.btnshownhideR = new System.Windows.Forms.Button();
            this.lbpasswordstr = new System.Windows.Forms.Label();
            this.lblPasswordMatch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbreg
            // 
            this.lbreg.AutoSize = true;
            this.lbreg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbreg.Location = new System.Drawing.Point(71, 47);
            this.lbreg.Name = "lbreg";
            this.lbreg.Size = new System.Drawing.Size(143, 25);
            this.lbreg.TabIndex = 13;
            this.lbreg.Text = "Register IAS";
            // 
            // lbpassR
            // 
            this.lbpassR.AutoSize = true;
            this.lbpassR.Location = new System.Drawing.Point(60, 152);
            this.lbpassR.Name = "lbpassR";
            this.lbpassR.Size = new System.Drawing.Size(53, 13);
            this.lbpassR.TabIndex = 12;
            this.lbpassR.Text = "Password";
            // 
            // lbuserR
            // 
            this.lbuserR.AutoSize = true;
            this.lbuserR.Location = new System.Drawing.Point(58, 112);
            this.lbuserR.Name = "lbuserR";
            this.lbuserR.Size = new System.Drawing.Size(55, 13);
            this.lbuserR.TabIndex = 11;
            this.lbuserR.Text = "Username";
            // 
            // tbpasswordR
            // 
            this.tbpasswordR.Location = new System.Drawing.Point(119, 149);
            this.tbpasswordR.Name = "tbpasswordR";
            this.tbpasswordR.Size = new System.Drawing.Size(100, 20);
            this.tbpasswordR.TabIndex = 10;
            this.tbpasswordR.UseSystemPasswordChar = true;
            this.tbpasswordR.Click += new System.EventHandler(this.tbpasswordR_Click);
            this.tbpasswordR.TextChanged += new System.EventHandler(this.tbpasswordR_TextChanged);
            // 
            // tbusernameR
            // 
            this.tbusernameR.Location = new System.Drawing.Point(119, 109);
            this.tbusernameR.Name = "tbusernameR";
            this.tbusernameR.Size = new System.Drawing.Size(100, 20);
            this.tbusernameR.TabIndex = 9;
            // 
            // btnregister
            // 
            this.btnregister.Location = new System.Drawing.Point(70, 278);
            this.btnregister.Name = "btnregister";
            this.btnregister.Size = new System.Drawing.Size(75, 23);
            this.btnregister.TabIndex = 8;
            this.btnregister.Text = "Register";
            this.btnregister.UseVisualStyleBackColor = true;
            this.btnregister.Click += new System.EventHandler(this.btnregister_Click);
            // 
            // btcancelR
            // 
            this.btcancelR.Location = new System.Drawing.Point(164, 278);
            this.btcancelR.Name = "btcancelR";
            this.btcancelR.Size = new System.Drawing.Size(75, 23);
            this.btcancelR.TabIndex = 16;
            this.btcancelR.Text = "Cancel";
            this.btcancelR.UseVisualStyleBackColor = true;
            this.btcancelR.Click += new System.EventHandler(this.btcancelR_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 20;
            // 
            // lbconfromR
            // 
            this.lbconfromR.AutoSize = true;
            this.lbconfromR.Location = new System.Drawing.Point(22, 188);
            this.lbconfromR.Name = "lbconfromR";
            this.lbconfromR.Size = new System.Drawing.Size(91, 13);
            this.lbconfromR.TabIndex = 19;
            this.lbconfromR.Text = "Confirm Password";
            // 
            // tbconfirmpasswordR
            // 
            this.tbconfirmpasswordR.Location = new System.Drawing.Point(119, 185);
            this.tbconfirmpasswordR.Name = "tbconfirmpasswordR";
            this.tbconfirmpasswordR.Size = new System.Drawing.Size(100, 20);
            this.tbconfirmpasswordR.TabIndex = 18;
            this.tbconfirmpasswordR.UseSystemPasswordChar = true;
            // 
            // lblcode
            // 
            this.lblcode.AutoSize = true;
            this.lblcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcode.Location = new System.Drawing.Point(42, 321);
            this.lblcode.Name = "lblcode";
            this.lblcode.Size = new System.Drawing.Size(223, 13);
            this.lblcode.TabIndex = 22;
            this.lblcode.Text = "Reminder new users don\'t need code to login.";
            // 
            // lbcapslockR
            // 
            this.lbcapslockR.AutoSize = true;
            this.lbcapslockR.Location = new System.Drawing.Point(93, 210);
            this.lbcapslockR.Name = "lbcapslockR";
            this.lbcapslockR.Size = new System.Drawing.Size(0, 13);
            this.lbcapslockR.TabIndex = 15;
            // 
            // lblPasswordStrength
            // 
            this.lblPasswordStrength.AutoSize = true;
            this.lblPasswordStrength.Location = new System.Drawing.Point(93, 210);
            this.lblPasswordStrength.Name = "lblPasswordStrength";
            this.lblPasswordStrength.Size = new System.Drawing.Size(0, 13);
            this.lblPasswordStrength.TabIndex = 17;
            // 
            // btnshownhideR
            // 
            this.btnshownhideR.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnshownhideR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnshownhideR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnshownhideR.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnshownhideR.Image = global::LoginAIS_Nieves.Properties.Resources.view1;
            this.btnshownhideR.Location = new System.Drawing.Point(225, 165);
            this.btnshownhideR.Name = "btnshownhideR";
            this.btnshownhideR.Size = new System.Drawing.Size(26, 20);
            this.btnshownhideR.TabIndex = 14;
            this.btnshownhideR.UseVisualStyleBackColor = false;
            this.btnshownhideR.Click += new System.EventHandler(this.btnshownhideR_Click);
            // 
            // lbpasswordstr
            // 
            this.lbpasswordstr.AutoSize = true;
            this.lbpasswordstr.Location = new System.Drawing.Point(73, 210);
            this.lbpasswordstr.Name = "lbpasswordstr";
            this.lbpasswordstr.Size = new System.Drawing.Size(0, 13);
            this.lbpasswordstr.TabIndex = 23;
            // 
            // lblPasswordMatch
            // 
            this.lblPasswordMatch.AutoSize = true;
            this.lblPasswordMatch.Location = new System.Drawing.Point(119, 171);
            this.lblPasswordMatch.Name = "lblPasswordMatch";
            this.lblPasswordMatch.Size = new System.Drawing.Size(0, 13);
            this.lblPasswordMatch.TabIndex = 24;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(309, 343);
            this.Controls.Add(this.lblPasswordMatch);
            this.Controls.Add(this.lbpasswordstr);
            this.Controls.Add(this.lblcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbconfromR);
            this.Controls.Add(this.tbconfirmpasswordR);
            this.Controls.Add(this.lblPasswordStrength);
            this.Controls.Add(this.btcancelR);
            this.Controls.Add(this.lbcapslockR);
            this.Controls.Add(this.btnshownhideR);
            this.Controls.Add(this.lbreg);
            this.Controls.Add(this.lbpassR);
            this.Controls.Add(this.lbuserR);
            this.Controls.Add(this.tbpasswordR);
            this.Controls.Add(this.tbusernameR);
            this.Controls.Add(this.btnregister);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnshownhideR;
        private System.Windows.Forms.Label lbreg;
        private System.Windows.Forms.Label lbpassR;
        private System.Windows.Forms.Label lbuserR;
        private System.Windows.Forms.TextBox tbpasswordR;
        private System.Windows.Forms.TextBox tbusernameR;
        private System.Windows.Forms.Button btnregister;
        private System.Windows.Forms.Button btcancelR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbconfromR;
        private System.Windows.Forms.TextBox tbconfirmpasswordR;
        private System.Windows.Forms.Label lblcode;
        private System.Windows.Forms.Label lbcapslockR;
        private System.Windows.Forms.Label lblPasswordStrength;
        private System.Windows.Forms.Label lbpasswordstr;
        private System.Windows.Forms.Label lblPasswordMatch;
    }
}