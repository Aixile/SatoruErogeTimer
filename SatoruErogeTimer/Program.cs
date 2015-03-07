using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace SatoruErogeTimer
{
	static class Program
	{
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
		[DllImport("user32.dll ", SetLastError = true)]
		static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
		[DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
		public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
		public const int SW_RESTORE = 9;
		public static IntPtr formhwnd;

		[STAThread]
		static void Main()
		{
			Process currentproc = Process.GetCurrentProcess();
			Console.WriteLine(currentproc.ProcessName);
			Process[] processcollection = Process.GetProcessesByName(currentproc.ProcessName);
			if (processcollection.Length > 1)
			{
				foreach (Process process in processcollection)
				{
					if (process.Id != currentproc.Id)
					{
						SwitchToThisWindow(process.MainWindowHandle, true);
					}
				}
			}
			else
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1());
			}
		}
	}
}
