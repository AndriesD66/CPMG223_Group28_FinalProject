﻿
namespace CMPG_Group28_FinalProject
{
    partial class frmHome
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.Window = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnView = new System.Windows.Forms.Button();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnPmnt = new System.Windows.Forms.Button();
            this.btnEnterExit = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.pnlHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Window,
            this.Exit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.Window;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(50, 29);
            this.File.Text = "&File";
            // 
            // Window
            // 
            this.Window.Name = "Window";
            this.Window.Size = new System.Drawing.Size(90, 29);
            this.Window.Text = "&Window";
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(51, 29);
            this.Exit.Text = "&Exit";
            // 
            // btnView
            // 
            this.btnView.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(0, 0);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(800, 44);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View, Update or Delete Client records";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // pnlHome
            // 
            this.pnlHome.Controls.Add(this.btnReport);
            this.pnlHome.Controls.Add(this.btnPmnt);
            this.pnlHome.Controls.Add(this.btnEnterExit);
            this.pnlHome.Controls.Add(this.btnBook);
            this.pnlHome.Controls.Add(this.btnView);
            this.pnlHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHome.Location = new System.Drawing.Point(0, 33);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(800, 417);
            this.pnlHome.TabIndex = 5;
            this.pnlHome.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHome_Paint);
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(0, 176);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(800, 44);
            this.btnReport.TabIndex = 7;
            this.btnReport.Text = "Request Reports";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnPmnt
            // 
            this.btnPmnt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPmnt.Location = new System.Drawing.Point(0, 132);
            this.btnPmnt.Name = "btnPmnt";
            this.btnPmnt.Size = new System.Drawing.Size(800, 44);
            this.btnPmnt.TabIndex = 6;
            this.btnPmnt.Text = "Log a Payment";
            this.btnPmnt.UseVisualStyleBackColor = true;
            this.btnPmnt.Click += new System.EventHandler(this.btnPmnt_Click);
            // 
            // btnEnterExit
            // 
            this.btnEnterExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEnterExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnterExit.Location = new System.Drawing.Point(0, 88);
            this.btnEnterExit.Name = "btnEnterExit";
            this.btnEnterExit.Size = new System.Drawing.Size(800, 44);
            this.btnEnterExit.TabIndex = 5;
            this.btnEnterExit.Text = "Client access";
            this.btnEnterExit.UseVisualStyleBackColor = true;
            this.btnEnterExit.Click += new System.EventHandler(this.btnEnterExit_Click);
            // 
            // btnBook
            // 
            this.btnBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.Location = new System.Drawing.Point(0, 44);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(800, 44);
            this.btnBook.TabIndex = 4;
            this.btnBook.Text = "Book A Class";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlHome);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmHome";
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlHome.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Window;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnEnterExit;
        private System.Windows.Forms.Button btnPmnt;
        private System.Windows.Forms.Button btnReport;
    }
}
