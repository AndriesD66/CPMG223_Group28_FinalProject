
namespace CMPG_Group28_FinalProject
{
    partial class Clients
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
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAddEdit = new System.Windows.Forms.GroupBox();
            this.cbAdmin = new System.Windows.Forms.CheckBox();
            this.tbContact = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbBank = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.cbEdit = new System.Windows.Forms.CheckBox();
            this.gbDelete = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbDelete = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btAddEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.gbAddEdit.SuspendLayout();
            this.gbDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClients
            // 
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(12, 33);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.Size = new System.Drawing.Size(1109, 334);
            this.dgvClients.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client Records";
            // 
            // gbAddEdit
            // 
            this.gbAddEdit.Controls.Add(this.btAddEdit);
            this.gbAddEdit.Controls.Add(this.cbAdmin);
            this.gbAddEdit.Controls.Add(this.tbContact);
            this.gbAddEdit.Controls.Add(this.label7);
            this.gbAddEdit.Controls.Add(this.tbBank);
            this.gbAddEdit.Controls.Add(this.label6);
            this.gbAddEdit.Controls.Add(this.tbEmail);
            this.gbAddEdit.Controls.Add(this.label5);
            this.gbAddEdit.Controls.Add(this.tbSurname);
            this.gbAddEdit.Controls.Add(this.label4);
            this.gbAddEdit.Controls.Add(this.tbName);
            this.gbAddEdit.Controls.Add(this.label3);
            this.gbAddEdit.Controls.Add(this.tbID);
            this.gbAddEdit.Controls.Add(this.lblID);
            this.gbAddEdit.Controls.Add(this.cbEdit);
            this.gbAddEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAddEdit.Location = new System.Drawing.Point(12, 374);
            this.gbAddEdit.Name = "gbAddEdit";
            this.gbAddEdit.Size = new System.Drawing.Size(826, 142);
            this.gbAddEdit.TabIndex = 2;
            this.gbAddEdit.TabStop = false;
            this.gbAddEdit.Text = "Add new client record or edit an existing record";
            // 
            // cbAdmin
            // 
            this.cbAdmin.AutoSize = true;
            this.cbAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAdmin.Location = new System.Drawing.Point(9, 114);
            this.cbAdmin.Name = "cbAdmin";
            this.cbAdmin.Size = new System.Drawing.Size(156, 17);
            this.cbAdmin.TabIndex = 13;
            this.cbAdmin.Text = "This user is an administrator";
            this.cbAdmin.UseVisualStyleBackColor = true;
            this.cbAdmin.CheckedChanged += new System.EventHandler(this.cbAdmin_CheckedChanged);
            // 
            // tbContact
            // 
            this.tbContact.Location = new System.Drawing.Point(606, 71);
            this.tbContact.Name = "tbContact";
            this.tbContact.Size = new System.Drawing.Size(100, 22);
            this.tbContact.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(509, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Contact Number: ";
            // 
            // tbBank
            // 
            this.tbBank.Location = new System.Drawing.Point(350, 69);
            this.tbBank.Name = "tbBank";
            this.tbBank.Size = new System.Drawing.Size(100, 22);
            this.tbBank.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(229, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Bank Account Number:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(65, 71);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(100, 22);
            this.tbEmail.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Email:";
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(468, 41);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(100, 22);
            this.tbSurname.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(413, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Surname:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(270, 40);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 22);
            this.tbName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(226, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name:";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(65, 41);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(100, 22);
            this.tbID.TabIndex = 2;
            this.tbID.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(6, 45);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(53, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "Client ID: ";
            // 
            // cbEdit
            // 
            this.cbEdit.AutoSize = true;
            this.cbEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEdit.Location = new System.Drawing.Point(7, 22);
            this.cbEdit.Name = "cbEdit";
            this.cbEdit.Size = new System.Drawing.Size(130, 17);
            this.cbEdit.TabIndex = 0;
            this.cbEdit.Text = "Edit an existing record";
            this.cbEdit.UseVisualStyleBackColor = true;
            this.cbEdit.CheckedChanged += new System.EventHandler(this.cbEdit_CheckedChanged);
            // 
            // gbDelete
            // 
            this.gbDelete.Controls.Add(this.btnDelete);
            this.gbDelete.Controls.Add(this.tbDelete);
            this.gbDelete.Controls.Add(this.label2);
            this.gbDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDelete.Location = new System.Drawing.Point(859, 382);
            this.gbDelete.Name = "gbDelete";
            this.gbDelete.Size = new System.Drawing.Size(262, 108);
            this.gbDelete.TabIndex = 3;
            this.gbDelete.TabStop = false;
            this.gbDelete.Text = "Delete a record";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(66, 62);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete Record";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbDelete
            // 
            this.tbDelete.Location = new System.Drawing.Point(66, 24);
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(100, 22);
            this.tbDelete.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Client ID: ";
            // 
            // btAddEdit
            // 
            this.btAddEdit.Location = new System.Drawing.Point(631, 108);
            this.btAddEdit.Name = "btAddEdit";
            this.btAddEdit.Size = new System.Drawing.Size(113, 28);
            this.btAddEdit.TabIndex = 14;
            this.btAddEdit.Text = "Add Record";
            this.btAddEdit.UseVisualStyleBackColor = true;
            this.btAddEdit.Click += new System.EventHandler(this.button1_Click);
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 587);
            this.Controls.Add(this.gbDelete);
            this.Controls.Add(this.gbAddEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvClients);
            this.Name = "Clients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.Clients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.gbAddEdit.ResumeLayout(false);
            this.gbAddEdit.PerformLayout();
            this.gbDelete.ResumeLayout(false);
            this.gbDelete.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbAddEdit;
        private System.Windows.Forms.GroupBox gbDelete;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.CheckBox cbEdit;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbContact;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbBank;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbAdmin;
        private System.Windows.Forms.Button btAddEdit;
    }
}