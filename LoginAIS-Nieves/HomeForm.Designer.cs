namespace LoginAIS_Nieves
{
    partial class HomeForm
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
            this.lblhomepage = new System.Windows.Forms.Label();
            this.btnlogout = new System.Windows.Forms.Button();
            this.tbcode = new System.Windows.Forms.TextBox();
            this.lblcode = new System.Windows.Forms.Label();
            this.lbwelcome = new System.Windows.Forms.Label();
            this.btncopycode = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CBIDLE = new System.Windows.Forms.ToolStripComboBox();
            this.panelCODE = new System.Windows.Forms.Panel();
            this.lbcodeacc = new System.Windows.Forms.Label();
            this.panelSIDEBAR = new System.Windows.Forms.Panel();
            this.panelMAIN = new System.Windows.Forms.Panel();
            this.btnMAIN = new System.Windows.Forms.Button();
            this.btnCODE = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelCODE.SuspendLayout();
            this.panelSIDEBAR.SuspendLayout();
            this.panelMAIN.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblhomepage
            // 
            this.lblhomepage.AutoSize = true;
            this.lblhomepage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhomepage.Location = new System.Drawing.Point(8, 21);
            this.lblhomepage.Name = "lblhomepage";
            this.lblhomepage.Size = new System.Drawing.Size(226, 31);
            this.lblhomepage.TabIndex = 0;
            this.lblhomepage.Text = "Main Dashboard";
            // 
            // btnlogout
            // 
            this.btnlogout.Location = new System.Drawing.Point(286, 2);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(56, 23);
            this.btnlogout.TabIndex = 2;
            this.btnlogout.Text = "Logout";
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // tbcode
            // 
            this.tbcode.Location = new System.Drawing.Point(84, 71);
            this.tbcode.Name = "tbcode";
            this.tbcode.Size = new System.Drawing.Size(100, 20);
            this.tbcode.TabIndex = 3;
            // 
            // lblcode
            // 
            this.lblcode.AutoSize = true;
            this.lblcode.Location = new System.Drawing.Point(43, 74);
            this.lblcode.Name = "lblcode";
            this.lblcode.Size = new System.Drawing.Size(38, 13);
            this.lblcode.TabIndex = 4;
            this.lblcode.Text = "Code: ";
            // 
            // lbwelcome
            // 
            this.lbwelcome.AutoSize = true;
            this.lbwelcome.Location = new System.Drawing.Point(11, 62);
            this.lbwelcome.Name = "lbwelcome";
            this.lbwelcome.Size = new System.Drawing.Size(0, 13);
            this.lbwelcome.TabIndex = 6;
            // 
            // btncopycode
            // 
            this.btncopycode.BackgroundImage = global::LoginAIS_Nieves.Properties.Resources.copy;
            this.btncopycode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btncopycode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncopycode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btncopycode.Location = new System.Drawing.Point(190, 70);
            this.btncopycode.Name = "btncopycode";
            this.btncopycode.Size = new System.Drawing.Size(22, 21);
            this.btncopycode.TabIndex = 5;
            this.btncopycode.UseVisualStyleBackColor = true;
            this.btncopycode.Click += new System.EventHandler(this.btncopycode_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(352, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CBIDLE});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // CBIDLE
            // 
            this.CBIDLE.Name = "CBIDLE";
            this.CBIDLE.Size = new System.Drawing.Size(121, 23);
            this.CBIDLE.Text = "AutoLogout";
            // 
            // panelCODE
            // 
            this.panelCODE.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelCODE.Controls.Add(this.lbcodeacc);
            this.panelCODE.Controls.Add(this.tbcode);
            this.panelCODE.Controls.Add(this.btncopycode);
            this.panelCODE.Controls.Add(this.lblcode);
            this.panelCODE.Location = new System.Drawing.Point(61, 27);
            this.panelCODE.Name = "panelCODE";
            this.panelCODE.Size = new System.Drawing.Size(295, 414);
            this.panelCODE.TabIndex = 9;
            // 
            // lbcodeacc
            // 
            this.lbcodeacc.AutoSize = true;
            this.lbcodeacc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcodeacc.Location = new System.Drawing.Point(12, 18);
            this.lbcodeacc.Name = "lbcodeacc";
            this.lbcodeacc.Size = new System.Drawing.Size(175, 25);
            this.lbcodeacc.TabIndex = 6;
            this.lbcodeacc.Text = "ACCESS CODE";
            // 
            // panelSIDEBAR
            // 
            this.panelSIDEBAR.BackColor = System.Drawing.Color.SteelBlue;
            this.panelSIDEBAR.Controls.Add(this.btnCODE);
            this.panelSIDEBAR.Controls.Add(this.btnMAIN);
            this.panelSIDEBAR.Location = new System.Drawing.Point(0, 28);
            this.panelSIDEBAR.Name = "panelSIDEBAR";
            this.panelSIDEBAR.Size = new System.Drawing.Size(54, 413);
            this.panelSIDEBAR.TabIndex = 10;
            // 
            // panelMAIN
            // 
            this.panelMAIN.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelMAIN.Controls.Add(this.lblhomepage);
            this.panelMAIN.Controls.Add(this.lbwelcome);
            this.panelMAIN.Location = new System.Drawing.Point(60, 27);
            this.panelMAIN.Name = "panelMAIN";
            this.panelMAIN.Size = new System.Drawing.Size(301, 414);
            this.panelMAIN.TabIndex = 11;
            // 
            // btnMAIN
            // 
            this.btnMAIN.Location = new System.Drawing.Point(3, 9);
            this.btnMAIN.Name = "btnMAIN";
            this.btnMAIN.Size = new System.Drawing.Size(48, 47);
            this.btnMAIN.TabIndex = 0;
            this.btnMAIN.Text = "MAIN";
            this.btnMAIN.UseVisualStyleBackColor = true;
            this.btnMAIN.Click += new System.EventHandler(this.btnMAIN_Click);
            // 
            // btnCODE
            // 
            this.btnCODE.Location = new System.Drawing.Point(3, 62);
            this.btnCODE.Name = "btnCODE";
            this.btnCODE.Size = new System.Drawing.Size(48, 47);
            this.btnCODE.TabIndex = 7;
            this.btnCODE.Text = "CODE";
            this.btnCODE.UseVisualStyleBackColor = true;
            this.btnCODE.Click += new System.EventHandler(this.btnCODE_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(352, 434);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.panelSIDEBAR);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelMAIN);
            this.Controls.Add(this.panelCODE);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelCODE.ResumeLayout(false);
            this.panelCODE.PerformLayout();
            this.panelSIDEBAR.ResumeLayout(false);
            this.panelMAIN.ResumeLayout(false);
            this.panelMAIN.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblhomepage;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.TextBox tbcode;
        private System.Windows.Forms.Label lblcode;
        private System.Windows.Forms.Button btncopycode;
        private System.Windows.Forms.Label lbwelcome;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox CBIDLE;
        private System.Windows.Forms.Panel panelCODE;
        private System.Windows.Forms.Label lbcodeacc;
        private System.Windows.Forms.Panel panelSIDEBAR;
        private System.Windows.Forms.Panel panelMAIN;
        private System.Windows.Forms.Button btnCODE;
        private System.Windows.Forms.Button btnMAIN;
    }
}