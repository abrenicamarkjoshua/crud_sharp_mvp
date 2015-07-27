namespace crud_csharp_mvp {
    partial class mainForm {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadAllUsers_datagridview = new System.Windows.Forms.Button();
            this.btnSearchUsernameDataGridView = new System.Windows.Forms.Button();
            this.txtSearchUsernameDataGridView = new System.Windows.Forms.TextBox();
            this.btn_dgridview_edit = new System.Windows.Forms.Button();
            this.datagridview_userResult = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoadAllUsers_listview = new System.Windows.Forms.Button();
            this.btnSearchUsernameListView = new System.Windows.Forms.Button();
            this.txtSearchUsernameListView = new System.Windows.Forms.TextBox();
            this.listview_userResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnListViewEdit = new System.Windows.Forms.Button();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.btnDeleteItemInDgridview = new System.Windows.Forms.Button();
            this.btnDeleteItemInListView = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_userResult)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteItemInDgridview);
            this.groupBox1.Controls.Add(this.btnLoadAllUsers_datagridview);
            this.groupBox1.Controls.Add(this.btnSearchUsernameDataGridView);
            this.groupBox1.Controls.Add(this.txtSearchUsernameDataGridView);
            this.groupBox1.Controls.Add(this.btn_dgridview_edit);
            this.groupBox1.Controls.Add(this.datagridview_userResult);
            this.groupBox1.Location = new System.Drawing.Point(43, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 370);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DataGridview";
            // 
            // btnLoadAllUsers_datagridview
            // 
            this.btnLoadAllUsers_datagridview.Location = new System.Drawing.Point(33, 29);
            this.btnLoadAllUsers_datagridview.Name = "btnLoadAllUsers_datagridview";
            this.btnLoadAllUsers_datagridview.Size = new System.Drawing.Size(99, 23);
            this.btnLoadAllUsers_datagridview.TabIndex = 5;
            this.btnLoadAllUsers_datagridview.Text = "loadAllUsers";
            this.btnLoadAllUsers_datagridview.UseVisualStyleBackColor = true;
            // 
            // btnSearchUsernameDataGridView
            // 
            this.btnSearchUsernameDataGridView.Location = new System.Drawing.Point(223, 56);
            this.btnSearchUsernameDataGridView.Name = "btnSearchUsernameDataGridView";
            this.btnSearchUsernameDataGridView.Size = new System.Drawing.Size(99, 39);
            this.btnSearchUsernameDataGridView.TabIndex = 3;
            this.btnSearchUsernameDataGridView.Text = "search by username";
            this.btnSearchUsernameDataGridView.UseVisualStyleBackColor = true;
            // 
            // txtSearchUsernameDataGridView
            // 
            this.txtSearchUsernameDataGridView.Location = new System.Drawing.Point(33, 58);
            this.txtSearchUsernameDataGridView.Name = "txtSearchUsernameDataGridView";
            this.txtSearchUsernameDataGridView.Size = new System.Drawing.Size(184, 20);
            this.txtSearchUsernameDataGridView.TabIndex = 2;
            // 
            // btn_dgridview_edit
            // 
            this.btn_dgridview_edit.Location = new System.Drawing.Point(6, 329);
            this.btn_dgridview_edit.Name = "btn_dgridview_edit";
            this.btn_dgridview_edit.Size = new System.Drawing.Size(99, 23);
            this.btn_dgridview_edit.TabIndex = 1;
            this.btn_dgridview_edit.Text = "edit";
            this.btn_dgridview_edit.UseVisualStyleBackColor = true;
            // 
            // datagridview_userResult
            // 
            this.datagridview_userResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_userResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datagridview_userResult.Location = new System.Drawing.Point(6, 122);
            this.datagridview_userResult.Name = "datagridview_userResult";
            this.datagridview_userResult.ReadOnly = true;
            this.datagridview_userResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridview_userResult.Size = new System.Drawing.Size(317, 178);
            this.datagridview_userResult.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteItemInListView);
            this.groupBox2.Controls.Add(this.btnLoadAllUsers_listview);
            this.groupBox2.Controls.Add(this.btnSearchUsernameListView);
            this.groupBox2.Controls.Add(this.txtSearchUsernameListView);
            this.groupBox2.Controls.Add(this.listview_userResult);
            this.groupBox2.Controls.Add(this.btnListViewEdit);
            this.groupBox2.Location = new System.Drawing.Point(409, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 370);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ListView";
            // 
            // btnLoadAllUsers_listview
            // 
            this.btnLoadAllUsers_listview.Location = new System.Drawing.Point(37, 29);
            this.btnLoadAllUsers_listview.Name = "btnLoadAllUsers_listview";
            this.btnLoadAllUsers_listview.Size = new System.Drawing.Size(99, 23);
            this.btnLoadAllUsers_listview.TabIndex = 6;
            this.btnLoadAllUsers_listview.Text = "loadAllUsers";
            this.btnLoadAllUsers_listview.UseVisualStyleBackColor = true;
            // 
            // btnSearchUsernameListView
            // 
            this.btnSearchUsernameListView.Location = new System.Drawing.Point(227, 56);
            this.btnSearchUsernameListView.Name = "btnSearchUsernameListView";
            this.btnSearchUsernameListView.Size = new System.Drawing.Size(99, 39);
            this.btnSearchUsernameListView.TabIndex = 5;
            this.btnSearchUsernameListView.Text = "search by username";
            this.btnSearchUsernameListView.UseVisualStyleBackColor = true;
            // 
            // txtSearchUsernameListView
            // 
            this.txtSearchUsernameListView.Location = new System.Drawing.Point(37, 58);
            this.txtSearchUsernameListView.Name = "txtSearchUsernameListView";
            this.txtSearchUsernameListView.Size = new System.Drawing.Size(184, 20);
            this.txtSearchUsernameListView.TabIndex = 4;
            // 
            // listview_userResult
            // 
            this.listview_userResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listview_userResult.FullRowSelect = true;
            this.listview_userResult.HideSelection = false;
            this.listview_userResult.Location = new System.Drawing.Point(37, 122);
            this.listview_userResult.Name = "listview_userResult";
            this.listview_userResult.Size = new System.Drawing.Size(305, 178);
            this.listview_userResult.TabIndex = 3;
            this.listview_userResult.UseCompatibleStateImageBehavior = false;
            this.listview_userResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Username";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "AccountType";
            // 
            // btnListViewEdit
            // 
            this.btnListViewEdit.Location = new System.Drawing.Point(37, 329);
            this.btnListViewEdit.Name = "btnListViewEdit";
            this.btnListViewEdit.Size = new System.Drawing.Size(99, 23);
            this.btnListViewEdit.TabIndex = 2;
            this.btnListViewEdit.Text = "edit";
            this.btnListViewEdit.UseVisualStyleBackColor = true;
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Location = new System.Drawing.Point(43, 27);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(99, 23);
            this.btnAddNewUser.TabIndex = 3;
            this.btnAddNewUser.Text = "add new user";
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            // 
            // btnDeleteItemInDgridview
            // 
            this.btnDeleteItemInDgridview.Location = new System.Drawing.Point(131, 329);
            this.btnDeleteItemInDgridview.Name = "btnDeleteItemInDgridview";
            this.btnDeleteItemInDgridview.Size = new System.Drawing.Size(99, 23);
            this.btnDeleteItemInDgridview.TabIndex = 6;
            this.btnDeleteItemInDgridview.Text = "delete";
            this.btnDeleteItemInDgridview.UseVisualStyleBackColor = true;
            // 
            // btnDeleteItemInListView
            // 
            this.btnDeleteItemInListView.Location = new System.Drawing.Point(174, 329);
            this.btnDeleteItemInListView.Name = "btnDeleteItemInListView";
            this.btnDeleteItemInListView.Size = new System.Drawing.Size(99, 23);
            this.btnDeleteItemInListView.TabIndex = 7;
            this.btnDeleteItemInListView.Text = "edit";
            this.btnDeleteItemInListView.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 502);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "mainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_userResult)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_dgridview_edit;
        private System.Windows.Forms.DataGridView datagridview_userResult;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listview_userResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnListViewEdit;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.Button btnSearchUsernameDataGridView;
        private System.Windows.Forms.TextBox txtSearchUsernameDataGridView;
        private System.Windows.Forms.Button btnSearchUsernameListView;
        private System.Windows.Forms.TextBox txtSearchUsernameListView;
        private System.Windows.Forms.Button btnLoadAllUsers_datagridview;
        private System.Windows.Forms.Button btnLoadAllUsers_listview;
        private System.Windows.Forms.Button btnDeleteItemInDgridview;
        private System.Windows.Forms.Button btnDeleteItemInListView;
    }
}

