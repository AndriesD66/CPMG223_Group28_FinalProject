
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRepType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRepName = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cbShow = new System.Windows.Forms.CheckBox();
            this.rtbShowReport = new System.Windows.Forms.RichTextBox();
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
            this.label2.Location = new System.Drawing.Point(16, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type of report: ";
            // 
            // cmbRepType
            // 
            this.cmbRepType.FormattingEnabled = true;
            this.cmbRepType.Items.AddRange(new object[] {
            "Income in  the last year",
            "Income in the last motnh",
            "Class attendance summary",
            "Number of bookings in the last month"});
            this.cmbRepType.Location = new System.Drawing.Point(101, 38);
            this.cmbRepType.Name = "cmbRepType";
            this.cmbRepType.Size = new System.Drawing.Size(170, 21);
            this.cmbRepType.TabIndex = 2;
            this.cmbRepType.Text = "Choose a report type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Save as: ";
            // 
            // tbRepName
            // 
            this.tbRepName.Location = new System.Drawing.Point(101, 64);
            this.tbRepName.Name = "tbRepName";
            this.tbRepName.Size = new System.Drawing.Size(100, 20);
            this.tbRepName.TabIndex = 4;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(16, 120);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(104, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate report";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // cbShow
            // 
            this.cbShow.AutoSize = true;
            this.cbShow.Location = new System.Drawing.Point(19, 97);
            this.cbShow.Name = "cbShow";
            this.cbShow.Size = new System.Drawing.Size(83, 17);
            this.cbShow.TabIndex = 6;
            this.cbShow.Text = "Show report";
            this.cbShow.UseVisualStyleBackColor = true;
            // 
            // rtbShowReport
            // 
            this.rtbShowReport.Location = new System.Drawing.Point(16, 166);
            this.rtbShowReport.Name = "rtbShowReport";
            this.rtbShowReport.Size = new System.Drawing.Size(760, 258);
            this.rtbShowReport.TabIndex = 7;
            this.rtbShowReport.Text = "";
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbShowReport);
            this.Controls.Add(this.cbShow);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.tbRepName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbRepType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRepType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRepName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox cbShow;
        private System.Windows.Forms.RichTextBox rtbShowReport;
    }
}