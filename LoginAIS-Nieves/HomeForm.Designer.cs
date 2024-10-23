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
            this.SuspendLayout();
            // 
            // lblhomepage
            // 
            this.lblhomepage.AutoSize = true;
            this.lblhomepage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhomepage.Location = new System.Drawing.Point(12, 9);
            this.lblhomepage.Name = "lblhomepage";
            this.lblhomepage.Size = new System.Drawing.Size(165, 31);
            this.lblhomepage.TabIndex = 0;
            this.lblhomepage.Text = "Home Page";
            // 
            // btnlogout
            // 
            this.btnlogout.Location = new System.Drawing.Point(102, 116);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(75, 23);
            this.btnlogout.TabIndex = 2;
            this.btnlogout.Text = "Logout";
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // tbcode
            // 
            this.tbcode.Location = new System.Drawing.Point(56, 72);
            this.tbcode.Name = "tbcode";
            this.tbcode.Size = new System.Drawing.Size(100, 20);
            this.tbcode.TabIndex = 3;
            // 
            // lblcode
            // 
            this.lblcode.AutoSize = true;
            this.lblcode.Location = new System.Drawing.Point(15, 75);
            this.lblcode.Name = "lblcode";
            this.lblcode.Size = new System.Drawing.Size(38, 13);
            this.lblcode.TabIndex = 4;
            this.lblcode.Text = "Code: ";
            // 
            // lbwelcome
            // 
            this.lbwelcome.AutoSize = true;
            this.lbwelcome.Location = new System.Drawing.Point(18, 44);
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
            this.btncopycode.Location = new System.Drawing.Point(162, 71);
            this.btncopycode.Name = "btncopycode";
            this.btncopycode.Size = new System.Drawing.Size(22, 21);
            this.btncopycode.TabIndex = 5;
            this.btncopycode.UseVisualStyleBackColor = true;
            this.btncopycode.Click += new System.EventHandler(this.btncopycode_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(196, 163);
            this.Controls.Add(this.lbwelcome);
            this.Controls.Add(this.btncopycode);
            this.Controls.Add(this.lblcode);
            this.Controls.Add(this.tbcode);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.lblhomepage);
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.Load += new System.EventHandler(this.HomeForm_Load);
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
    }
}