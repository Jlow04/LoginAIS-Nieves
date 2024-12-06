namespace LoginAIS_Nieves
{
    partial class adduserForm
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
            this.lbADDFORM = new System.Windows.Forms.Label();
            this.lbcapslock = new System.Windows.Forms.Label();
            this.lbpassA = new System.Windows.Forms.Label();
            this.lbuserA = new System.Windows.Forms.Label();
            this.ADDpassword = new System.Windows.Forms.TextBox();
            this.ADDusername = new System.Windows.Forms.TextBox();
            this.btnADD = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbADDFORM
            // 
            this.lbADDFORM.AutoSize = true;
            this.lbADDFORM.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbADDFORM.Location = new System.Drawing.Point(52, 29);
            this.lbADDFORM.Name = "lbADDFORM";
            this.lbADDFORM.Size = new System.Drawing.Size(150, 18);
            this.lbADDFORM.TabIndex = 21;
            this.lbADDFORM.Text = "ADMIN ADD USER";
            // 
            // lbcapslock
            // 
            this.lbcapslock.AutoSize = true;
            this.lbcapslock.Location = new System.Drawing.Point(103, 129);
            this.lbcapslock.Name = "lbcapslock";
            this.lbcapslock.Size = new System.Drawing.Size(0, 13);
            this.lbcapslock.TabIndex = 20;
            // 
            // lbpassA
            // 
            this.lbpassA.AutoSize = true;
            this.lbpassA.Location = new System.Drawing.Point(47, 109);
            this.lbpassA.Name = "lbpassA";
            this.lbpassA.Size = new System.Drawing.Size(53, 13);
            this.lbpassA.TabIndex = 19;
            this.lbpassA.Text = "Password";
            // 
            // lbuserA
            // 
            this.lbuserA.AutoSize = true;
            this.lbuserA.Location = new System.Drawing.Point(45, 69);
            this.lbuserA.Name = "lbuserA";
            this.lbuserA.Size = new System.Drawing.Size(55, 13);
            this.lbuserA.TabIndex = 18;
            this.lbuserA.Text = "Username";
            // 
            // ADDpassword
            // 
            this.ADDpassword.Location = new System.Drawing.Point(106, 106);
            this.ADDpassword.Name = "ADDpassword";
            this.ADDpassword.Size = new System.Drawing.Size(100, 20);
            this.ADDpassword.TabIndex = 17;
            // 
            // ADDusername
            // 
            this.ADDusername.Location = new System.Drawing.Point(106, 66);
            this.ADDusername.Name = "ADDusername";
            this.ADDusername.Size = new System.Drawing.Size(100, 20);
            this.ADDusername.TabIndex = 16;
            // 
            // btnADD
            // 
            this.btnADD.Location = new System.Drawing.Point(136, 144);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(75, 23);
            this.btnADD.TabIndex = 15;
            this.btnADD.Text = "Add";
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(48, 144);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 22;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click_1);
            // 
            // adduserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 196);
            this.ControlBox = false;
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.lbADDFORM);
            this.Controls.Add(this.lbcapslock);
            this.Controls.Add(this.lbpassA);
            this.Controls.Add(this.lbuserA);
            this.Controls.Add(this.ADDpassword);
            this.Controls.Add(this.ADDusername);
            this.Controls.Add(this.btnADD);
            this.Name = "adduserForm";
            this.Text = "adduserForm";
            this.Load += new System.EventHandler(this.adduserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbADDFORM;
        private System.Windows.Forms.Label lbcapslock;
        private System.Windows.Forms.Label lbpassA;
        private System.Windows.Forms.Label lbuserA;
        private System.Windows.Forms.TextBox ADDpassword;
        private System.Windows.Forms.TextBox ADDusername;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.Button btncancel;
    }
}