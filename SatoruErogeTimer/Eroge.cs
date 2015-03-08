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
using System.Xml;
using Microsoft.Win32;
using System.Net;
using System.Web;
using System.Collections;
using System.IO.Compression;
using System.Threading;
using System.Xml.Serialization;

namespace SatoruErogeTimer
{
	public class Eroge
	{
		//public string title;
		//public float time;
		//public string addr;
		//public string processName;
		string title;
		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		int time;
		public int Time
		{
			get { return time; }
			set { time = value; }
		}

		string path;
		public string Path
		{
			get { return path; }
			set { path = value; }
		}

		public string processName {get;set;}

		public enum RunningStatus{Focused,Resting,Unfocused};
		private RunningStatus status;
		public RunningStatus Status
		{
			get { return status; }
			set { status = value; }
		}

		public Eroge() { }
		public Eroge(string _title, int _time, string _addr,RunningStatus _status = RunningStatus.Resting)
		{
			title = _title;
			time = _time;
			path = _addr;
		}
		public string getTime()
		{
			int m = (time / 60);
			int h = m / 60;
			m %= 60;
			return h + @"時間" + m + @"分";
		}
		public void addTime(int i)
		{
			time += i;
		}
		public string getState()
		{
			return status.ToString();
		}
		public bool run()
		{
			ProcessStartInfo start = new ProcessStartInfo(path);
			start.CreateNoWindow = false;
			start.RedirectStandardOutput = true;
			start.RedirectStandardInput = true;
			start.UseShellExecute = false;
			start.WorkingDirectory = new FileInfo(path).DirectoryName;
			try
			{
				Process p = Process.Start(start);
			}
			catch
			{
				return false;
			}
			return true;
		}
	/*	public ListViewItem toListViewItem()
		{
			ListViewItem i = new ListViewItem(new string[] { title, getTime(), addr, getState() });
			return i;
		}*/
	}
}
