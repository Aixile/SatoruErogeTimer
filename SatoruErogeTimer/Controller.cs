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
			{//载入用户名
				XmlDocument xmlDoc2 = new XmlDocument();
				xmlDoc2.Load(syncPath);
				XmlNode rootNode = xmlDoc2.SelectSingleNode("Sync");
				XmlNodeList userName = rootNode.ChildNodes;
	//			this.label1.Text = userName[0].InnerText;
	//			labelRedraw();
			}
		}
		public void refreshXML()
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
				//	listStyle();
			}	
			//refreshXML();
		}
		public List<Eroge> getErogeList()
		{
			return erogeList.getErogeList();
		}
		public void addEroge(Eroge e){
			getErogeList().Add(e);
		}
		public bool runErogeByIndex(int i)
		{
			try
			{
				getErogeList()[i].run();
				erogeList.check();
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
				erogeList.check();
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
				erogeList.check();
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
				erogeList.check();
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
				erogeList.check();
			}
			catch
			{
				return false;
			}
			return true;
		}
	}
}
