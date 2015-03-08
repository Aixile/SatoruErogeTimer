using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SatoruErogeTimer
{
	[Serializable]
	public class ErogeList
	{
		List<Eroge> erg=new List<Eroge>();
		public ErogeList() { }
		public ErogeList(List<Eroge> a)
		{
			erg = a;
		}
		public bool isEmpty(){
			return erg.Count == 0;
		}
		public void check(int time=0)
		{
			IntPtr actWin = Utility.GetForegroundWindow();
			int calcID;
			Utility.GetWindowThreadProcessId(actWin, out calcID);

			ProcessForm processWindow = new ProcessForm();
			Process[] proc = Process.GetProcesses();
			string procPath;

			foreach (Eroge i in erg)
			{
				i.Status = Eroge.RunningStatus.Resting;
			}

			foreach (Process p in proc)
			{
				try
				{
					procPath = Convert.ToString(p.MainModule.FileName);
					string procPid = Convert.ToString(p.Id);
					foreach (Eroge i in erg)
					{
						if (i.Path == procPath)
						{
							if (procPid == calcID.ToString())
							{
								i.Status=Eroge.RunningStatus.Focused;
								if (time != 0)
								{
									i.addTime(time);
								}
							}else{
								i.Status=Eroge.RunningStatus.Unfocused;
							}

						}
					}
				}
				catch
				{
					; //system 等拒绝访问的进程 抛弃
				}
			}

		}
		public List<Eroge> getErogeList()
		{
			return erg;
		}

		public void addEroge(Eroge e){
			erg.Add(e);
		}

	}
}
