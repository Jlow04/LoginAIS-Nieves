namespace LoginAIS_Nieves
{
    partial class EditUserForm
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
            this.lbcapslock = new System.Windows.Forms.Label();
            this.lbpassE = new System.Windows.Forms.Label();
            this.lbuserE = new System.Windows.Forms.Label();
            this.EDITpassword = new System.Windows.Forms.TextBox();
            this.EDITusername = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.lblog = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbcapslock
            // 
            this.lbcapslock.AutoSize = true;
            this.lbcapslock.Location = new System.Drawing.Point(63, 109);
            this.lbcapslock.Name = "lbcapslock";
            this.lbcapslock.Size = new System.Drawing.Size(0, 13);
            this.lbcapslock.TabIndex = 13;
            // 
            // lbpassE
            // 
            this.lbpassE.AutoSize = true;
            this.lbpassE.Location = new System.Drawing.Point(7, 89);
            this.lbpassE.Name = "lbpassE";
            this.lbpassE.Size = new System.Drawing.Size(53, 13);
            this.lbpassE.TabIndex = 12;
            this.lbpassE.Text = "Password";
            // 
            // lbuserE
            // 
            this.lbuserE.AutoSize = true;
            this.lbuserE.Location = new System.Drawing.Point(5, 49);
            this.lbuserE.Name = "lbuserE";
            this.lbuserE.Size = new System.Drawing.Size(55, 13);
            this.lbuserE.TabIndex = 11;
            this.lbuserE.Text = "Username";
            // 
            // EDITpassword
            // 
            this.EDITpassword.Location = new System.Drawing.Point(66, 86);
            this.EDITpassword.Name = "EDITpassword";
            this.EDITpassword.Size = new System.Drawing.Size(100, 20);
            this.EDITpassword.TabIndex = 10;
            // 
            // EDITusername
            // 
            this.EDITusername.Location = new System.Drawing.Point(66, 46);
            this.EDITusername.Name = "EDITusername";
            this.EDITusername.Size = new System.Drawing.Size(100, 20);
            this.EDITusername.TabIndex = 9;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(66, 125);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 8;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // lblog
            // 
            this.lblog.AutoSize = true;
            this.lblog.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblog.Location = new System.Drawing.Point(12, 9);
            this.lblog.Name = "lblog";
            this.lblog.Size = new System.Drawing.Size(143, 18);
            this.lblog.TabIndex = 14;
            this.lblog.Text = "ADMIN EDIT FORM";
            // 
            // EditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 178);
            this.Controls.Add(this.lblog);
            this.Controls.Add(this.lbcapslock);
            this.Controls.Add(this.lbpassE);
            this.Controls.Add(this.lbuserE);
            this.Controls.Add(this.EDITpassword);
            this.Controls.Add(this.EDITusername);
            this.Controls.Add(this.btnsave);
            this.Name = "EditUserForm";
            this.Text = "EditUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbcapslock;
        private System.Windows.Forms.Label lbpassE;
        private System.Windows.Forms.Label lbuserE;
        private System.Windows.Forms.TextBox EDITpassword;
        private System.Windows.Forms.TextBox EDITusername;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label lblog;
    }
}