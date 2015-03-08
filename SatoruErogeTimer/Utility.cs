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
	public static class Utility
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

		[DllImport("user32.dll", EntryPoint = "GetForegroundWindow")]
		public static extern IntPtr GetForegroundWindow();

		public static Font fRunning = new Font(Control.DefaultFont, FontStyle.Bold);
		public static Font fResting = new Font(Control.DefaultFont, FontStyle.Regular);
	}
}
