namespace SatoruErogeTimer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ユーザ変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同期ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PlayGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.セーブデータをバックアップToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.セーブデータをリストアToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.パース設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstShow = new System.Windows.Forms.ListView();
            this.game = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playtime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.state = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetAutorunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveAutorunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.同期ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(550, 26);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.fileToolStripMenuItem.Text = "追加";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // 同期ToolStripMenuItem
            // 
            this.同期ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ユーザ変更ToolStripMenuItem,
            this.同期ToolStripMenuItem1});
            this.同期ToolStripMenuItem.Name = "同期ToolStripMenuItem";
            this.同期ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.同期ToolStripMenuItem.Text = "同期";
            // 
            // ユーザ変更ToolStripMenuItem
            // 
            this.ユーザ変更ToolStripMenuItem.Name = "ユーザ変更ToolStripMenuItem";
            this.ユーザ変更ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ユーザ変更ToolStripMenuItem.Text = "ユーザ設定・変更";
            this.ユーザ変更ToolStripMenuItem.Click += new System.EventHandler(this.ユーザ変更ToolStripMenuItem_Click);
            // 
            // 同期ToolStripMenuItem1
            // 
            this.同期ToolStripMenuItem1.Name = "同期ToolStripMenuItem1";
            this.同期ToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.同期ToolStripMenuItem1.Text = "今すぐ同期";
            this.同期ToolStripMenuItem1.Click += new System.EventHandler(this.同期ToolStripMenuItem1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3600;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayGameToolStripMenuItem,
            this.セーブデータをバックアップToolStripMenuItem,
            this.セーブデータをリストアToolStripMenuItem,
            this.EditNameToolStripMenuItem,
            this.EditTimeToolStripMenuItem,
            this.パース設定ToolStripMenuItem,
            this.DeleteGameToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(233, 158);
            // 
            // PlayGameToolStripMenuItem
            // 
            this.PlayGameToolStripMenuItem.Name = "PlayGameToolStripMenuItem";
            this.PlayGameToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.PlayGameToolStripMenuItem.Text = "ゲームを実行する";
            this.PlayGameToolStripMenuItem.Click += new System.EventHandler(this.ゲームを実行するToolStripMenuItem_Click);
            // 
            // セーブデータをバックアップToolStripMenuItem
            // 
            this.セーブデータをバックアップToolStripMenuItem.Name = "セーブデータをバックアップToolStripMenuItem";
            this.セーブデータをバックアップToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.セーブデータをバックアップToolStripMenuItem.Text = "セーブデータをバックアップ";
            this.セーブデータをバックアップToolStripMenuItem.Click += new System.EventHandler(this.セーブデータをバックアップToolStripMenuItem_Click);
            // 
            // セーブデータをリストアToolStripMenuItem
            // 
            this.セーブデータをリストアToolStripMenuItem.Name = "セーブデータをリストアToolStripMenuItem";
            this.セーブデータをリストアToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.セーブデータをリストアToolStripMenuItem.Text = "セーブデータをリストア";
            this.セーブデータをリストアToolStripMenuItem.Click += new System.EventHandler(this.セーブデータをリストアToolStripMenuItem_Click);
            // 
            // EditNameToolStripMenuItem
            // 
            this.EditNameToolStripMenuItem.Name = "EditNameToolStripMenuItem";
            this.EditNameToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.EditNameToolStripMenuItem.Text = "名前編集";
            this.EditNameToolStripMenuItem.Click += new System.EventHandler(this.名前編集ToolStripMenuItem_Click);
            // 
            // EditTimeToolStripMenuItem
            // 
            this.EditTimeToolStripMenuItem.Name = "EditTimeToolStripMenuItem";
            this.EditTimeToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.EditTimeToolStripMenuItem.Text = "時間編集";
            this.EditTimeToolStripMenuItem.Click += new System.EventHandler(this.時間編集ToolStripMenuItem_Click);
            // 
            // パース設定ToolStripMenuItem
            // 
            this.パース設定ToolStripMenuItem.Name = "パース設定ToolStripMenuItem";
            this.パース設定ToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.パース設定ToolStripMenuItem.Text = "パス編集";
            this.パース設定ToolStripMenuItem.Click += new System.EventHandler(this.パース設定ToolStripMenuItem_Click);
            // 
            // DeleteGameToolStripMenuItem
            // 
            this.DeleteGameToolStripMenuItem.Name = "DeleteGameToolStripMenuItem";
            this.DeleteGameToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.DeleteGameToolStripMenuItem.Text = "リストから削除する";
            this.DeleteGameToolStripMenuItem.Click += new System.EventHandler(this.ゲームをToolStripMenuItem_Click);
            // 
            // lstShow
            // 
            this.lstShow.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.lstShow.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstShow.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lstShow.BackColor = System.Drawing.SystemColors.Window;
            this.lstShow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.game,
            this.playtime,
            this.path,
            this.state});
            this.lstShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstShow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstShow.FullRowSelect = true;
            this.lstShow.GridLines = true;
            this.lstShow.HoverSelection = true;
            this.lstShow.LabelEdit = true;
            this.lstShow.Location = new System.Drawing.Point(0, 26);
            this.lstShow.MultiSelect = false;
            this.lstShow.Name = "lstShow";
            this.lstShow.ShowGroups = false;
            this.lstShow.Size = new System.Drawing.Size(550, 335);
            this.lstShow.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstShow.TabIndex = 6;
            this.lstShow.UseCompatibleStateImageBehavior = false;
            this.lstShow.View = System.Windows.Forms.View.Details;
            this.lstShow.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstShow_ColumnClick);
            // 
            // game
            // 
            this.game.Text = "ゲーム";
            this.game.Width = 150;
            // 
            // playtime
            // 
            this.playtime.Text = "プレイタイム";
            this.playtime.Width = 70;
            // 
            // path
            // 
            this.path.Text = "パス";
            this.path.Width = 125;
            // 
            // state
            // 
            this.state.Text = "実行状態";
            this.state.Width = 201;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "ErogrTimer Running";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip2;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ErogeTimer Running";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem,
            this.AutoRunToolStripMenuItem,
            this.EndToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(192, 70);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.AboutToolStripMenuItem.Text = "ErogeTimerについて";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.erogeTimerについてToolStripMenuItem_Click);
            // 
            // AutoRunToolStripMenuItem
            // 
            this.AutoRunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetAutorunToolStripMenuItem,
            this.RemoveAutorunToolStripMenuItem});
            this.AutoRunToolStripMenuItem.Name = "AutoRunToolStripMenuItem";
            this.AutoRunToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.AutoRunToolStripMenuItem.Text = "自動起動";
            // 
            // SetAutorunToolStripMenuItem
            // 
            this.SetAutorunToolStripMenuItem.Name = "SetAutorunToolStripMenuItem";
            this.SetAutorunToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.SetAutorunToolStripMenuItem.Text = "設定";
            this.SetAutorunToolStripMenuItem.Click += new System.EventHandler(this.設定ToolStripMenuItem_Click);
            // 
            // RemoveAutorunToolStripMenuItem
            // 
            this.RemoveAutorunToolStripMenuItem.Name = "RemoveAutorunToolStripMenuItem";
            this.RemoveAutorunToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.RemoveAutorunToolStripMenuItem.Text = "元に戻す";
            this.RemoveAutorunToolStripMenuItem.Click += new System.EventHandler(this.元に戻すToolStripMenuItem_Click);
            // 
            // EndToolStripMenuItem
            // 
            this.EndToolStripMenuItem.Name = "EndToolStripMenuItem";
            this.EndToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.EndToolStripMenuItem.Text = "終了";
            this.EndToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(445, 9);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(1);
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(2, 14);
            this.label1.TabIndex = 7;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 361);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstShow);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ErogeTimer";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem PlayGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditNameToolStripMenuItem;
        private System.Windows.Forms.ListView lstShow;
        private System.Windows.Forms.ToolStripMenuItem DeleteGameToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem EndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AutoRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetAutorunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveAutorunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader game;
        private System.Windows.Forms.ColumnHeader playtime;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.ColumnHeader state;
        private System.Windows.Forms.ToolStripMenuItem 同期ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ユーザ変更ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 同期ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem パース設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem セーブデータをバックアップToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem セーブデータをリストアToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

