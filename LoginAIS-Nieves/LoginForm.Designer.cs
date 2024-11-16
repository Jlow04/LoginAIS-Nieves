namespace LoginAIS_Nieves
{
    partial class LoginForm
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbusername = new System.Windows.Forms.TextBox();
            this.tbpassword = new System.Windows.Forms.TextBox();
            this.lbuser = new System.Windows.Forms.Label();
            this.lbpass = new System.Windows.Forms.Label();
            this.lblog = new System.Windows.Forms.Label();
            this.lbcapslock = new System.Windows.Forms.Label();
            this.lbregister = new System.Windows.Forms.Label();
            this.lbinforeg = new System.Windows.Forms.Label();
            this.btnshownhide = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbcodelog = new System.Windows.Forms.Label();
            this.tbcodelog = new System.Windows.Forms.TextBox();
            this.lbtxtfogot = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(130, 204);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbusername
            // 
            this.tbusername.Location = new System.Drawing.Point(130, 88);
            this.tbusername.Name = "tbusername";
            this.tbusername.Size = new System.Drawing.Size(100, 20);
            this.tbusername.TabIndex = 1;
            // 
            // tbpassword
            // 
            this.tbpassword.Location = new System.Drawing.Point(130, 128);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.Size = new System.Drawing.Size(100, 20);
            this.tbpassword.TabIndex = 2;
            this.tbpassword.UseSystemPasswordChar = true;
            // 
            // lbuser
            // 
            this.lbuser.AutoSize = true;
            this.lbuser.Location = new System.Drawing.Point(69, 91);
            this.lbuser.Name = "lbuser";
            this.lbuser.Size = new System.Drawing.Size(55, 13);
            this.lbuser.TabIndex = 3;
            this.lbuser.Text = "Username";
            // 
            // lbpass
            // 
            this.lbpass.AutoSize = true;
            this.lbpass.Location = new System.Drawing.Point(71, 131);
            this.lbpass.Name = "lbpass";
            this.lbpass.Size = new System.Drawing.Size(53, 13);
            this.lbpass.TabIndex = 4;
            this.lbpass.Text = "Password";
            // 
            // lblog
            // 
            this.lblog.AutoSize = true;
            this.lblog.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblog.Location = new System.Drawing.Point(88, 27);
            this.lblog.Name = "lblog";
            this.lblog.Size = new System.Drawing.Size(113, 25);
            this.lblog.TabIndex = 5;
            this.lblog.Text = "Login IAS";
            // 
            // lbcapslock
            // 
            this.lbcapslock.AutoSize = true;
            this.lbcapslock.Location = new System.Drawing.Point(127, 151);
            this.lbcapslock.Name = "lbcapslock";
            this.lbcapslock.Size = new System.Drawing.Size(0, 13);
            this.lbcapslock.TabIndex = 7;
            // 
            // lbregister
            // 
            this.lbregister.AutoSize = true;
            this.lbregister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbregister.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbregister.Location = new System.Drawing.Point(162, 245);
            this.lbregister.Name = "lbregister";
            this.lbregister.Size = new System.Drawing.Size(43, 13);
            this.lbregister.TabIndex = 8;
            this.lbregister.Text = "Sign up";
            this.lbregister.Click += new System.EventHandler(this.lbregister_Click);
            // 
            // lbinforeg
            // 
            this.lbinforeg.AutoSize = true;
            this.lbinforeg.Location = new System.Drawing.Point(93, 245);
            this.lbinforeg.Name = "lbinforeg";
            this.lbinforeg.Size = new System.Drawing.Size(70, 13);
            this.lbinforeg.TabIndex = 9;
            this.lbinforeg.Text = "No Account?";
            // 
            // btnshownhide
            // 
            this.btnshownhide.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnshownhide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnshownhide.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnshownhide.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnshownhide.Image = global::LoginAIS_Nieves.Properties.Resources.view1;
            this.btnshownhide.Location = new System.Drawing.Point(236, 128);
            this.btnshownhide.Name = "btnshownhide";
            this.btnshownhide.Size = new System.Drawing.Size(26, 20);
            this.btnshownhide.TabIndex = 6;
            this.btnshownhide.UseVisualStyleBackColor = false;
            this.btnshownhide.Click += new System.EventHandler(this.btnshownhide_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 12;
            // 
            // lbcodelog
            // 
            this.lbcodelog.AutoSize = true;
            this.lbcodelog.Location = new System.Drawing.Point(54, 168);
            this.lbcodelog.Name = "lbcodelog";
            this.lbcodelog.Size = new System.Drawing.Size(70, 13);
            this.lbcodelog.TabIndex = 11;
            this.lbcodelog.Text = "Access Code";
            // 
            // tbcodelog
            // 
            this.tbcodelog.Location = new System.Drawing.Point(130, 165);
            this.tbcodelog.Name = "tbcodelog";
            this.tbcodelog.Size = new System.Drawing.Size(100, 20);
            this.tbcodelog.TabIndex = 10;
            // 
            // lbtxtfogot
            // 
            this.lbtxtfogot.AutoSize = true;
            this.lbtxtfogot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbtxtfogot.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbtxtfogot.Location = new System.Drawing.Point(93, 272);
            this.lbtxtfogot.Name = "lbtxtfogot";
            this.lbtxtfogot.Size = new System.Drawing.Size(120, 13);
            this.lbtxtfogot.TabIndex = 13;
            this.lbtxtfogot.Text = "Forgot password/code?";
            this.lbtxtfogot.Click += new System.EventHandler(this.lbtxtfogot_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(309, 307);
            this.Controls.Add(this.lbtxtfogot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbcodelog);
            this.Controls.Add(this.tbcodelog);
            this.Controls.Add(this.lbinforeg);
            this.Controls.Add(this.lbregister);
            this.Controls.Add(this.lbcapslock);
            this.Controls.Add(this.btnshownhide);
            this.Controls.Add(this.lblog);
            this.Controls.Add(this.lbpass);
            this.Controls.Add(this.lbuser);
            this.Controls.Add(this.tbpassword);
            this.Controls.Add(this.tbusername);
            this.Controls.Add(this.btnLogin);
            this.Name = "LoginForm";
            this.Text = "Login Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbusername;
        private System.Windows.Forms.TextBox tbpassword;
        private System.Windows.Forms.Label lbuser;
        private System.Windows.Forms.Label lbpass;
        private System.Windows.Forms.Label lblog;
        private System.Windows.Forms.Button btnshownhide;
        private System.Windows.Forms.Label lbcapslock;
        private System.Windows.Forms.Label lbregister;
        private System.Windows.Forms.Label lbinforeg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbcodelog;
        private System.Windows.Forms.TextBox tbcodelog;
        private System.Windows.Forms.Label lbtxtfogot;
    }
}

