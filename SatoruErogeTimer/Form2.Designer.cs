namespace SatoruErogeTimer
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.lstShow = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.確認ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstShow
            // 
            this.lstShow.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.lstShow.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstShow.AllowColumnReorder = true;
            this.lstShow.BackColor = System.Drawing.SystemColors.Window;
            this.lstShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstShow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstShow.FullRowSelect = true;
            this.lstShow.GridLines = true;
            this.lstShow.HoverSelection = true;
            this.lstShow.LabelEdit = true;
            this.lstShow.Location = new System.Drawing.Point(0, 0);
            this.lstShow.MultiSelect = false;
            this.lstShow.Name = "lstShow";
            this.lstShow.Size = new System.Drawing.Size(584, 462);
            this.lstShow.TabIndex = 5;
            this.lstShow.UseCompatibleStateImageBehavior = false;
            this.lstShow.View = System.Windows.Forms.View.Details;
            this.lstShow.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstShow_ColumnClick);
            this.lstShow.DoubleClick += new System.EventHandler(this.lstShow_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.確認ToolStripMenuItem,
            this.更新ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // 確認ToolStripMenuItem
            // 
            this.確認ToolStripMenuItem.Name = "確認ToolStripMenuItem";
            this.確認ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.確認ToolStripMenuItem.Text = "確認";
            this.確認ToolStripMenuItem.Click += new System.EventHandler(this.確認ToolStripMenuItem_Click);
            // 
            // 更新ToolStripMenuItem
            // 
            this.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem";
            this.更新ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.更新ToolStripMenuItem.Text = "更新";
            this.更新ToolStripMenuItem.Click += new System.EventHandler(this.更新ToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AccessibleName = "ProcessWindow";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lstShow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "SelectProcess";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstShow;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 確認ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新ToolStripMenuItem;
    }
}