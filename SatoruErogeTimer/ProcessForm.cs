using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace SatoruErogeTimer
{
	public partial class ProcessForm : Form
	{
		public ProcessForm()
		{
			InitializeComponent();
			lstShow.ListViewItemSorter = new Sorter();
			Sorter s = (Sorter)lstShow.ListViewItemSorter;
			s.Column = 1;
			s.Order = System.Windows.Forms.SortOrder.Descending;
			lstShow.Sort();
			selectedErogeIndex = -1;
		}

		public int selectedErogeIndex { get; set; }

		public void procProview()
		{
			lstShow.Columns.Add("ID", 30, HorizontalAlignment.Left);
			lstShow.Columns[0].Tag = "Numeric";
			lstShow.Columns.Add("イメージ名", 130);
			lstShow.Columns[1].TextAlign = 0; //左对齐可以用0 右或中 1 2 会出错
			lstShow.Columns.Add("PID", 40);
			lstShow.Columns[2].Tag = "Numeric";
			lstShow.Columns[2].TextAlign = HorizontalAlignment.Left;
			lstShow.Columns.Add("パス", 200);
			lstShow.Columns[3].TextAlign = HorizontalAlignment.Left;
			lstShow.Columns.Add("タイトル", 150);
			lstShow.Columns[4].TextAlign = HorizontalAlignment.Left;
			//lstShow.Columns.Add("启动时间", 150);
			//lstShow.Columns[6].TextAlign = HorizontalAlignment.Left;

			int prociNum = 0; //编号进程总数
			//int allmerry=0;//使用内存总数
			Process[] proc = Process.GetProcesses();
			foreach (Process p in proc)
			{
				string procId = Convert.ToString(prociNum++); //编号
				//allmerry = allmerry + Convert.ToInt32(p.PrivateMemorySize64 / 1024 / 1024);
				string procName = Convert.ToString(p.ProcessName); //取进程名
				string procPid = Convert.ToString(p.Id); //取ID
				//string usemerry = (p.PrivateMemorySize64 / 1024.00 / 1024.00).ToString("0.00") + " M"; //内存使用
				string procPath = ""; //路径
				string proTitle = ""; //标题
				//string proTime = ""; //启动时间
				//string priority = ""; //优先级
				//IntPtr prochWnd = IntPtr.Zero;
				//忽略异常 某些进程拒绝访问 会导致程序崩溃
				try
				{
					procPath = Convert.ToString(p.MainModule.FileName);
					procName = procName + Path.GetExtension(procPath);
					proTitle = Convert.ToString(p.MainWindowTitle);
					//proTime = Convert.ToString(p.StartTime);
					//priority = Convert.ToString(p.PriorityClass);
					//prochWnd = p.Handle;
				}
				catch
				{
					; //system 等拒绝访问的进程 抛弃
				}
				lstShow.Items.Add(
					new ListViewItem(new string[]
                                         {
                                             procId, procName,procPid,procPath,proTitle
                                         }));
			}
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			procProview();
		}

		private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			lstShow.Clear();
			procProview();
		}


//		public Eroge erogeCart = new Eroge();
		private void 確認ToolStripMenuItem_Click(object sender, EventArgs e)
		{

			/*Eroge eroge = new Eroge ();
			eroge.processName = lstShow.SelectedItems[0].SubItems[1].Text;
			eroge.addr = lstShow.SelectedItems[0].SubItems[4].Text;
			eroge.title = lstShow.SelectedItems[0].SubItems[5].Text;


			Form1 f1 = (Form1)this.Owner;
			f1.cart.processName = eroge.processName;
			f1.cart.addr = eroge.addr;
			f1.cart.title = eroge.title;

			Close();*/

			if (lstShow.SelectedItems[0].SubItems[3].Text == string.Empty)
			{
				MessageBox.Show("パスが必要", "ErogeTimer");
			}
			else
			{
				if (selectedErogeIndex >= 0)
				{
					MainForm.erogeController.changePathByIndex(selectedErogeIndex, lstShow.SelectedItems[0].SubItems[3].Text);
				}
				else
				{
					Eroge eroge = new Eroge(lstShow.SelectedItems[0].SubItems[4].Text, 0, lstShow.SelectedItems[0].SubItems[3].Text)
					{
						processName = lstShow.SelectedItems[0].SubItems[1].Text
					};
					MainForm.erogeController.addEroge(eroge);
				}
				this.DialogResult = DialogResult.OK;

			}

		}

		private void lstShow_DoubleClick(object sender, EventArgs e)
		{
			if (lstShow.SelectedItems[0].SubItems[3].Text == string.Empty)
			{
				MessageBox.Show("パスが必要", "ErogeTimer");
			}
			else
			{
				if (selectedErogeIndex >= 0)
				{
					MainForm.erogeController.changePathByIndex(selectedErogeIndex, lstShow.SelectedItems[0].SubItems[3].Text);
				}
				else
				{
					Eroge eroge = new Eroge(lstShow.SelectedItems[0].SubItems[4].Text, 0, lstShow.SelectedItems[0].SubItems[3].Text)
					{
						processName = lstShow.SelectedItems[0].SubItems[1].Text
					};
					MainForm.erogeController.addEroge(eroge);
				}
				this.DialogResult = DialogResult.OK;
			}
		}

		private void lstShow_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			Sorter s = (Sorter)lstShow.ListViewItemSorter;
			s.Column = e.Column;

			if (s.Order == System.Windows.Forms.SortOrder.Ascending)
			{
				s.Order = System.Windows.Forms.SortOrder.Descending;
			}
			else
			{
				s.Order = System.Windows.Forms.SortOrder.Ascending;
			}
			lstShow.Sort();
		}
	}
}
