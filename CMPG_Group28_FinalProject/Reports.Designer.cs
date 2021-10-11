
using System.Drawing;
using System.Windows.Forms;

namespace CMPG_Group28_FinalProject
{
    partial class Reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRepType = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.rtbShowReport = new System.Windows.Forms.RichTextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.saveD = new System.Windows.Forms.SaveFileDialog();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generate a report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type of report: ";
            // 
            // cmbRepType
            // 
            this.cmbRepType.FormattingEnabled = true;
            this.cmbRepType.Items.AddRange(new object[] {
            "Income Summary",
            "Income in the last month",
            "Class attendance summary",
            "Number of bookings in the last month"});
            this.cmbRepType.Location = new System.Drawing.Point(137, 45);
            this.cmbRepType.Name = "cmbRepType";
            this.cmbRepType.Size = new System.Drawing.Size(170, 21);
            this.cmbRepType.TabIndex = 2;
            this.cmbRepType.Text = "Choose a report type";
            this.cmbRepType.SelectedIndexChanged += new System.EventHandler(this.cmbRepType_SelectedIndexChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(16, 69);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(255, 35);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate report";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // rtbShowReport
            // 
            this.rtbShowReport.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.rtbShowReport.Location = new System.Drawing.Point(16, 106);
            this.rtbShowReport.Name = "rtbShowReport";
            this.rtbShowReport.ReadOnly = true;
            this.rtbShowReport.Size = new System.Drawing.Size(1052, 584);
            this.rtbShowReport.TabIndex = 7;
            this.rtbShowReport.Text = "mIghTy Gym";
            // 
            // btSave
            // 
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.Location = new System.Drawing.Point(787, 707);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(239, 62);
            this.btSave.TabIndex = 8;
            this.btSave.Text = "Save Report";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // cmbClass
            // 
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(287, 730);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(132, 21);
            this.cmbClass.TabIndex = 9;
            this.cmbClass.Text = "Pick a class";
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 1393);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.rtbShowReport);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cmbRepType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Reports_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRepType;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RichTextBox rtbShowReport;
        private Button btSave;
        private SaveFileDialog saveD;
        private ComboBox cmbClass;
    }
}