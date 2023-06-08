namespace PROJEKAT_PROGRAMIRANJE
{
    partial class Form1
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
            this.modeliAutomobilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.osiguranjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poliseKojeIsticuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uputstvoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.krajRadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeliAutomobilaToolStripMenuItem,
            this.osiguranjeToolStripMenuItem,
            this.uputstvoToolStripMenuItem,
            this.krajRadaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(791, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // modeliAutomobilaToolStripMenuItem
            // 
            this.modeliAutomobilaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.modeliAutomobilaToolStripMenuItem.Name = "modeliAutomobilaToolStripMenuItem";
            this.modeliAutomobilaToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.modeliAutomobilaToolStripMenuItem.Text = "Modeli automobila";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::PROJEKAT_PROGRAMIRANJE.Properties.Resources.ikona1;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 70);
            this.toolStripMenuItem1.Text = "Modeli";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // osiguranjeToolStripMenuItem
            // 
            this.osiguranjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.poliseKojeIsticuToolStripMenuItem});
            this.osiguranjeToolStripMenuItem.Name = "osiguranjeToolStripMenuItem";
            this.osiguranjeToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.osiguranjeToolStripMenuItem.Text = "Osiguranje";
            // 
            // poliseKojeIsticuToolStripMenuItem
            // 
            this.poliseKojeIsticuToolStripMenuItem.Image = global::PROJEKAT_PROGRAMIRANJE.Properties.Resources.auto2;
            this.poliseKojeIsticuToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.poliseKojeIsticuToolStripMenuItem.Name = "poliseKojeIsticuToolStripMenuItem";
            this.poliseKojeIsticuToolStripMenuItem.Size = new System.Drawing.Size(244, 70);
            this.poliseKojeIsticuToolStripMenuItem.Text = "Polise koje isticu";
            this.poliseKojeIsticuToolStripMenuItem.Click += new System.EventHandler(this.poliseKojeIsticuToolStripMenuItem_Click);
            // 
            // uputstvoToolStripMenuItem
            // 
            this.uputstvoToolStripMenuItem.Name = "uputstvoToolStripMenuItem";
            this.uputstvoToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.uputstvoToolStripMenuItem.Text = "Uputstvo";
            this.uputstvoToolStripMenuItem.Click += new System.EventHandler(this.uputstvoToolStripMenuItem_Click);
            // 
            // krajRadaToolStripMenuItem
            // 
            this.krajRadaToolStripMenuItem.Name = "krajRadaToolStripMenuItem";
            this.krajRadaToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.krajRadaToolStripMenuItem.Text = "Kraj rada";
            this.krajRadaToolStripMenuItem.Click += new System.EventHandler(this.krajRadaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 363);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modeliAutomobilaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem osiguranjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poliseKojeIsticuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uputstvoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem krajRadaToolStripMenuItem;
    }
}

