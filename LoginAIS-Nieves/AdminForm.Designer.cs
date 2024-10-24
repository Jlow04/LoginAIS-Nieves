namespace LoginAIS_Nieves
{
    partial class AdminForm
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
            this.DGVusers = new System.Windows.Forms.DataGridView();
            this.btrefresh = new System.Windows.Forms.Button();
            this.btdelete = new System.Windows.Forms.Button();
            this.btedit = new System.Windows.Forms.Button();
            this.lbACP = new System.Windows.Forms.Label();
            this.btresetattempt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbsearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnstatus = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnrole = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVusers)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVusers
            // 
            this.DGVusers.AllowUserToAddRows = false;
            this.DGVusers.AllowUserToDeleteRows = false;
            this.DGVusers.AllowUserToResizeColumns = false;
            this.DGVusers.AllowUserToResizeRows = false;
            this.DGVusers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVusers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVusers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVusers.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DGVusers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGVusers.EnableHeadersVisualStyles = false;
            this.DGVusers.Location = new System.Drawing.Point(21, 50);
            this.DGVusers.MultiSelect = false;
            this.DGVusers.Name = "DGVusers";
            this.DGVusers.ReadOnly = true;
            this.DGVusers.RowHeadersVisible = false;
            this.DGVusers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DGVusers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVusers.ShowCellErrors = false;
            this.DGVusers.ShowCellToolTips = false;
            this.DGVusers.ShowEditingIcon = false;
            this.DGVusers.ShowRowErrors = false;
            this.DGVusers.Size = new System.Drawing.Size(502, 350);
            this.DGVusers.TabIndex = 0;
            // 
            // btrefresh
            // 
            this.btrefresh.Location = new System.Drawing.Point(21, 406);
            this.btrefresh.Name = "btrefresh";
            this.btrefresh.Size = new System.Drawing.Size(59, 23);
            this.btrefresh.TabIndex = 1;
            this.btrefresh.Text = "Refresh";
            this.btrefresh.UseVisualStyleBackColor = true;
            this.btrefresh.Click += new System.EventHandler(this.btrefresh_Click);
            // 
            // btdelete
            // 
            this.btdelete.Location = new System.Drawing.Point(201, 406);
            this.btdelete.Name = "btdelete";
            this.btdelete.Size = new System.Drawing.Size(49, 23);
            this.btdelete.TabIndex = 2;
            this.btdelete.Text = "Delete";
            this.btdelete.UseVisualStyleBackColor = true;
            this.btdelete.Click += new System.EventHandler(this.btdelete_Click);
            // 
            // btedit
            // 
            this.btedit.Location = new System.Drawing.Point(136, 406);
            this.btedit.Name = "btedit";
            this.btedit.Size = new System.Drawing.Size(40, 23);
            this.btedit.TabIndex = 3;
            this.btedit.Text = "Edit";
            this.btedit.UseVisualStyleBackColor = true;
            this.btedit.Click += new System.EventHandler(this.btedit_Click);
            // 
            // lbACP
            // 
            this.lbACP.AutoSize = true;
            this.lbACP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbACP.Location = new System.Drawing.Point(17, 9);
            this.lbACP.Name = "lbACP";
            this.lbACP.Size = new System.Drawing.Size(202, 24);
            this.lbACP.TabIndex = 4;
            this.lbACP.Text = "Admin Control Panel";
            // 
            // btresetattempt
            // 
            this.btresetattempt.Location = new System.Drawing.Point(256, 406);
            this.btresetattempt.Name = "btresetattempt";
            this.btresetattempt.Size = new System.Drawing.Size(54, 23);
            this.btresetattempt.TabIndex = 5;
            this.btresetattempt.Text = "Reset";
            this.btresetattempt.UseVisualStyleBackColor = true;
            this.btresetattempt.Click += new System.EventHandler(this.btresetattempt_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(448, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbsearch
            // 
            this.tbsearch.Location = new System.Drawing.Point(21, 451);
            this.tbsearch.Name = "tbsearch";
            this.tbsearch.Size = new System.Drawing.Size(100, 20);
            this.tbsearch.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(127, 451);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(49, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnstatus
            // 
            this.btnstatus.Location = new System.Drawing.Point(338, 406);
            this.btnstatus.Name = "btnstatus";
            this.btnstatus.Size = new System.Drawing.Size(53, 23);
            this.btnstatus.TabIndex = 9;
            this.btnstatus.Text = "Status";
            this.btnstatus.UseVisualStyleBackColor = true;
            this.btnstatus.Click += new System.EventHandler(this.btnstatus_Click);
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(95, 406);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(35, 23);
            this.btnadd.TabIndex = 10;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnrole
            // 
            this.btnrole.Location = new System.Drawing.Point(397, 406);
            this.btnrole.Name = "btnrole";
            this.btnrole.Size = new System.Drawing.Size(50, 23);
            this.btnrole.TabIndex = 11;
            this.btnrole.Text = "Role";
            this.btnrole.UseVisualStyleBackColor = true;
            this.btnrole.Click += new System.EventHandler(this.btnrole_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 486);
            this.Controls.Add(this.btnrole);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.btnstatus);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbsearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btresetattempt);
            this.Controls.Add(this.lbACP);
            this.Controls.Add(this.btedit);
            this.Controls.Add(this.btdelete);
            this.Controls.Add(this.btrefresh);
            this.Controls.Add(this.DGVusers);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.DGVusers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVusers;
        private System.Windows.Forms.Button btrefresh;
        private System.Windows.Forms.Button btdelete;
        private System.Windows.Forms.Button btedit;
        private System.Windows.Forms.Label lbACP;
        private System.Windows.Forms.Button btresetattempt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbsearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnstatus;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnrole;
    }
}