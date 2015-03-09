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
using System.Runtime.Serialization.Formatters.Binary;

namespace SatoruErogeTimer
{
	public class Controller
	{
		public ErogeList erogeList=new ErogeList();
		public SyncController syncController = new SyncController();

		public delegate void UserName(object sender, UserNameEventArgs e);
		public event UserName UserNameChanged;

		public Controller() { } 
		public void LoadDataFile(string dataPath)
		{
			if (!File.Exists(dataPath))
			{
				//First setup
				erogeList = new ErogeList();
			}
			else
			{  //Use Serializer to deserialize file and load class variable
				try
				{
					FileStream fs = new FileStream(dataPath, FileMode.Open);
					BinaryFormatter bf = new BinaryFormatter();
					erogeList = bf.Deserialize(fs) as ErogeList;
					fs.Close();
				}
				catch
				{
					erogeList = new ErogeList();
				}
			}
		}
		public void SaveDataFile(string dataPath)
		{	//Use Serializer to save class variable
			FileStream fs = new FileStream(dataPath, FileMode.Create);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, erogeList);
			fs.Close();
		}
		public void LoadSyncFile(string syncPath)
		{
			if (File.Exists(syncPath))
			{
				try
				{
					FileStream stream = new FileStream(syncPath, FileMode.Open, FileAccess.Read, FileShare.Read);
					XmlSerializer xmlserializer = new XmlSerializer(typeof(SyncController));
					syncController = (SyncController)xmlserializer.Deserialize(stream);
					stream.Close();
					UserNameEventArgs e1 = new UserNameEventArgs();
					e1.Name = syncController.user;
					UserNameChanged(this, e1);
				}
				catch
				{
				}
			}
		}
		public void SaveSyncFile(string syncPath)
		{
			if (syncController.user.Length > 0)
			{
				FileStream stream = new FileStream(syncPath, FileMode.Create, FileAccess.Write, FileShare.None);
				XmlSerializer xmlserializer = new XmlSerializer(typeof(SyncController));
				xmlserializer.Serialize(stream, syncPath);
				stream.Close();
			}
		}
		public void saveData()
		{
			SaveDataFile(Utility.dataPath);
		}

		
		public void check()
		{
			erogeList.check();
		}
		public void updateTime(){
			if (!erogeList.isEmpty())
			{
				erogeList.check(3);
			}	
		}
		
		
		public List<ErogeNode> getErogeList()
		{
			return erogeList.getErogeList();
		}
		public void addEroge(ErogeNode e){
			getErogeList().Add(e);
		}

		
		public bool runErogeByIndex(int i)
		{
			try
			{
				getErogeList()[i].run();
			}
			catch
			{
				return false;
			}
			return true;
		}
		public bool changeNameByIndex(int i,string name)
		{
			try
			{
				getErogeList()[i].Title = name;
			}
			catch
			{
				return false;
			}
			return true;
		}
		public bool changeTimeByIndex(int i, string val)
		{
			try
			{
				getErogeList()[i].Time = Int32.Parse(val);
			}
			catch
			{
				return false;
			}
			return true;
		}
		public bool changePathByIndex(int i, string path)
		{
			try
			{
				getErogeList()[i].Path = path;
			}
			catch
			{
				return false;
			}
			return true;
		}
		public bool deleteByIndex(int i)
		{
			try
			{
				getErogeList().RemoveAt(i);
			}
			catch
			{
				return false;
			}
			return true;
		}


		static bool sort_name=false, sort_time=false, sort_path=false, sort_status=false;
		public void sortByName()
		{
			if (sort_name)
			{
				erogeList.getErogeList().Sort(delegate(ErogeNode a, ErogeNode b)
				{
					return a.Title.CompareTo(b.Title);
				});
			}
			else
			{
				erogeList.getErogeList().Sort(delegate(ErogeNode a, ErogeNode b)
				{
					return b.Title.CompareTo(a.Title);
				});
			}
			sort_name = !sort_name;
		}
		public void sortByTime()
		{
			if (sort_time)
			{
				erogeList.getErogeList().Sort(delegate(ErogeNode a, ErogeNode b)
				{
					return a.Time.CompareTo(b.Time);
				});
			}
			else
			{
				erogeList.getErogeList().Sort(delegate(ErogeNode a, ErogeNode b)
				{
					return b.Time.CompareTo(a.Time);
				});
			}
			sort_time = !sort_time;
		}
		public void sortByPath()
		{
			if (sort_path)
			{
				erogeList.getErogeList().Sort(delegate(ErogeNode a, ErogeNode b)
				{
					return a.Path.CompareTo(b.Path);
				});
			}
			else
			{
				erogeList.getErogeList().Sort(delegate(ErogeNode a, ErogeNode b)
				{
					return b.Path.CompareTo(a.Path);
				});
			}
			sort_path = !sort_path;
		}
		public void sortByStatus()
		{
			if (sort_status)
			{
				erogeList.getErogeList().Sort(delegate(ErogeNode a, ErogeNode b)
				{
					return a.Status.CompareTo(b.Status);
				});
			}
			else
			{
				erogeList.getErogeList().Sort(delegate(ErogeNode a, ErogeNode b)
				{
					return b.Status.CompareTo(a.Status);
				});
			}
			sort_status = !sort_status;
		}
	}
}
