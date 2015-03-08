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

	public partial class MainForm : Form
	{


        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0011://WM_QUERYENDSESSION程序接到关机消息 
                    
                    m.Result = (IntPtr)1; //返回1，让系统继续关机
                    Application.Exit();
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

		public static Controller erogeController=new Controller();
		public MainForm()
		{
			InitializeComponent();
			timer1.Enabled = true;
            
			erogeController.LoadDataFile(Utility.dataPath);
			erogeController.LoadSyncFile(Utility.syncPath);
			updateListView(erogeController.getErogeList());
			//ErogeList.printToListViewer(lstShow);

    /*        lstShow.ListViewItemSorter = new Sorter();
            lstShow.Columns[1].Tag = "Numeric";

            Sorter s = (Sorter)lstShow.ListViewItemSorter;
            s.Column = 1;
            s.Order = System.Windows.Forms.SortOrder.Descending;
            lstShow.Sort();*/

            //检查更新
            Thread updateThread = new Thread(new ThreadStart(checkUpdate));
            updateThread.Start();
		}
		bool isEqual(ListViewItem a, ListViewItem b)
		{
			if (a.SubItems[0].Text != b.SubItems[0].Text) return false;
			if (a.SubItems[1].Text != b.SubItems[1].Text) return false;
			if (a.SubItems[2].Text != b.SubItems[2].Text) return false;
			if (a.SubItems[3].Text != b.SubItems[3].Text) return false;
			return true;
		}
		void updateListView(List<Eroge> erg)
		{
			bool changed = false;
			if (erg.Count != lstShow.Items.Count) changed = true;
		//	lstShow.Items.Clear();
			foreach (Eroge i in erg)
			{
				ListViewItem lstItem = new ListViewItem(new string[] { i.Title, i.getTime(), i.Path, i.getState() });
				switch (i.Status)
				{
					case Eroge.RunningStatus.Focused:
						lstItem.ForeColor = Color.Black;
						lstItem.Font = Utility.fRunning;
						break;
					case Eroge.RunningStatus.Resting:
						lstItem.ForeColor = Color.Gray;
						lstItem.Font = Utility.fResting;
						break;
					case Eroge.RunningStatus.Unfocused:
						lstItem.ForeColor = Color.Black;
						lstItem.Font = Utility.fResting;
						break;
				}
				int idx = erg.IndexOf(i);
				if (idx < lstShow.Items.Count)
				{
					if (!isEqual(lstShow.Items[erg.IndexOf(i)], lstItem))
					{
						lstShow.Items[erg.IndexOf(i)] = lstItem;
						changed = true;
					}
				}
				else
				{
					lstShow.Items.Add(lstItem);
				}
			//	lstShow.Items.Add(lstItem);
			}
			if (lstShow.Items.Count > erg.Count)
			{
				for (int j = lstShow.Items.Count-1; j>=erg.Count;j--)
				{
					lstShow.Items.RemoveAt(j);
				}
			}
			if (changed) erogeController.refreshXML();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			erogeController.updateTime();
			updateListView(erogeController.getErogeList());
		}
		private void GetProcessStripMenuItem_Click(object sender, EventArgs e)
		{
			ProcessForm processWindow = new ProcessForm();

            processWindow.StartPosition = FormStartPosition.Manual;  
            Point a = new Point();
            a.X = this.Left+50;
            a.Y = this.Top+50;
            processWindow.Location = a;
			DialogResult ddr = processWindow.ShowDialog();
            
			if (ddr == DialogResult.OK)
			{
				erogeController.check();
				updateListView(erogeController.getErogeList());
			}
		}
		private void ゲームを実行するToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (lstShow.SelectedItems.Count > 0)
				{
					if (erogeController.runErogeByIndex(lstShow.SelectedIndices[0]))
					{
						updateListView(erogeController.getErogeList());
					}
				}
				else
				{
					MessageBox.Show("何も選択されていません", "ErogeTimer");
				}
			}
			catch
			{
				MessageBox.Show("エラーが発生しました、パスは正しくありません", "ErogeTimer");
			};
		}
		private void 名前編集ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lstShow.SelectedItems.Count > 0)
			{
				Form3 editNameWindow = new Form3();
                editNameWindow.StartPosition = FormStartPosition.Manual;
                Point a = new Point();

                a.X = this.Left + 50;
                a.Y = this.Top + 50;
                editNameWindow.Location = a;
				editNameWindow.Text = "タイトルを編集する";
                editNameWindow.Flag = lstShow.SelectedItems[0].SubItems[0].Text;
				DialogResult ddr = editNameWindow.ShowDialog();
				if (ddr == DialogResult.OK)
				{
					if (erogeController.changeNameByIndex(lstShow.SelectedIndices[0], editNameWindow.str))
					{
						updateListView(erogeController.getErogeList());
					}
				}
			}
			else
			{
				MessageBox.Show("何も選択されていません", "ErogeTimer");
			}
		}
		private void 時間編集ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lstShow.SelectedItems.Count > 0)
			{
				Form3 editTimeWindow = new Form3();
                editTimeWindow.StartPosition = FormStartPosition.Manual;
                Point a = new Point();

                a.X = this.Left + 50;
                a.Y = this.Top + 50;
                editTimeWindow.Location = a;
				editTimeWindow.Text = "時間を調整する";
				editTimeWindow.Flag = erogeController.getErogeList()[lstShow.SelectedIndices[0]].Time.ToString();
				DialogResult ddr = editTimeWindow.ShowDialog();
				if (ddr == DialogResult.OK)
				{
					if (erogeController.changeTimeByIndex(lstShow.SelectedIndices[0], editTimeWindow.str))
					{
						updateListView(erogeController.getErogeList());
					}
				}
			}
			else
			{
				MessageBox.Show("何も選択されていません", "ErogeTimer");
			}
		}
		private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lstShow.SelectedItems.Count > 0)
			{
				if (MessageBox.Show("削除しますか？", "ErogeTimer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					if (erogeController.deleteByIndex(lstShow.SelectedIndices[0]))
					{
						updateListView(erogeController.getErogeList());
					}
				}
			}
			else
			{
				MessageBox.Show("何も選択されていません", "ErogeTimer");
			}
		}
        private void パス設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstShow.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("プロセスフォーム...はい\n自分で入力...いいえ", "ErogeTimer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
					ProcessForm processWindow = new ProcessForm()
					{
						selectedErogeIndex = lstShow.SelectedIndices[0]
					};
                    processWindow.StartPosition = FormStartPosition.Manual;
                    Point a = new Point();
                    a.X = this.Left + 50;
                    a.Y = this.Top + 50;
                    processWindow.Location = a;
                    DialogResult ddr = processWindow.ShowDialog();
                    if (ddr == DialogResult.OK)
                    {
						updateListView(erogeController.getErogeList());
                    }
                }
                else
                {
                    Form3 editPassWindow = new Form3();
                    editPassWindow.StartPosition = FormStartPosition.Manual;
                    Point a = new Point();

                    a.X = this.Left + 50;
                    a.Y = this.Top + 50;
                    editPassWindow.Location = a;
                    editPassWindow.Text = "パスを設定する";
                    editPassWindow.Flag = lstShow.SelectedItems[0].SubItems[2].Text;
                    DialogResult ddr = editPassWindow.ShowDialog();
                    if (ddr == DialogResult.OK)
                    {
						if (erogeController.changePathByIndex(lstShow.SelectedIndices[0],editPassWindow.str))
						{
							updateListView(erogeController.getErogeList());
						}
                    }
                }
            }
            else
            {
                MessageBox.Show("何も選択されていません", "ErogeTimer");
            }
        }
		private void Form1_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.Visible = false;

			}
		}
		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{

				this.Visible = true;
				this.WindowState = FormWindowState.Normal;

			}
		}
		private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
		{
            Dispose();
            Application.Exit();
		}
		public static void SetAutoRun(string fileName, bool isAutoRun)
		{
			RegistryKey reg = null;
			try
			{
                if (!System.IO.File.Exists(fileName))
                { throw new Exception("ファイルを見つけない！"); }
				String name = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
				reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (reg == null)
                { reg = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"); }
                if (isAutoRun)
                { reg.SetValue(name, fileName); }
                else
                { reg.SetValue(name, false); }
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
			finally
			{
                if (reg != null)
                { reg.Close(); }
			}
		}
		private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string str = this.GetType().Assembly.Location;
			if (MessageBox.Show("確認お願いします", "ErogeTimer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{
				SetAutoRun(str, true);
                MessageBox.Show("設定終了", "ErogeTimer");
			}
		}

		private void 元に戻すToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string str = this.GetType().Assembly.Location;
			if (MessageBox.Show("確認お願いします", "ErogeTimer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{
				SetAutoRun(str, false);
                MessageBox.Show("元に戻した", "ErogeTimer");
			}

		}

		private void erogeTimerについてToolStripMenuItem_Click(object sender, EventArgs e)
		{
            MessageBox.Show("Version "+Utility.version+" By SakuraiSatoru, Many thanks to Amane Nagatsuki", "ErogeTimer");
		}
        private void labelRedraw()
        {
            Point a = new Point();
            a.X = this.Width-label1.Width-20;
            a.Y = 5;
            this.label1.Location = a;
        }
        private void ユーザ変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strSourcePath = Application.StartupPath + "\\";
            string dataPath = strSourcePath + "data.xml";
            string syncPath = strSourcePath + "sync.xml";
            if (!File.Exists(syncPath))
            {
                Form3 setUserWindow = new Form3();
                setUserWindow.StartPosition = FormStartPosition.Manual;
                Point a = new Point();

                a.X = this.Left + 50;
                a.Y = this.Top + 50;
                setUserWindow.Location = a;
                setUserWindow.Text = "新規ユーザ";
                DialogResult ddr = setUserWindow.ShowDialog();
                
                if (ddr == DialogResult.OK)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    XmlDeclaration xmldecl;
                    xmldecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                    xmlDoc.AppendChild(xmldecl);
                    XmlNode xmlelem0 = xmlDoc.CreateElement("", "Sync", "");
                    xmlDoc.AppendChild(xmlelem0);
                    XmlNode rootNode = xmlDoc.SelectSingleNode("Sync");
                    XmlNode xmlelem = xmlDoc.CreateElement("", "Config", "");
                    string userName = setUserWindow.str;
                    XmlElement userNameNode = xmlDoc.CreateElement("userName");
                    userNameNode.InnerText = userName;
                    xmlelem.AppendChild(userNameNode);
                    rootNode.AppendChild(xmlelem);
                    XmlNode xmlelem2 = xmlDoc.CreateElement("", "Eroges", "");
                    rootNode.AppendChild(xmlelem2);
                    xmlDoc.Save(syncPath);
                    this.label1.Text = userName;
                    labelRedraw();
                }
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(syncPath);
                XmlNode rootNode = xmlDoc.SelectSingleNode("Sync");
                XmlNodeList userName = rootNode.ChildNodes;
                string userNameStr = userName[0].InnerText;
                if (MessageBox.Show(userNameStr + "から新規しますか？", "ErogeTimer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                { 
                    Form3 setUserWindow = new Form3();
                    setUserWindow.StartPosition = FormStartPosition.Manual;
                    Point a = new Point();

                    a.X = this.Left + 50;
                    a.Y = this.Top + 50;
                    setUserWindow.Location = a;
                    setUserWindow.Text = "新規ユーザ";
                    DialogResult ddr = setUserWindow.ShowDialog();

                    if (ddr == DialogResult.OK)
                    {
                        userNameStr = setUserWindow.str;
                        userName[0].InnerText = userNameStr;
                        xmlDoc.Save(syncPath);
                        this.label1.Text = userNameStr;
                        labelRedraw();
                    }
                }
            }
        }
        private void 同期ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.label1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("ユーザが必要です", "ErogeTimer");
            }
            else 
            {
                this.Text = "ErogeTimer @同期中";
                this.timer1.Enabled = false;
                string strSourcePath = Application.StartupPath + "\\";
                string dataPath = strSourcePath + "data.xml";
				string dataBakPath = strSourcePath + "data.xml.bak";
                string syncPath = strSourcePath + "sync.xml";
                string syncBakPath = strSourcePath + "sync.xml.bak";
				File.Copy((dataPath), (dataBakPath), true);
                File.Copy((syncPath), (syncBakPath), true);
                try
                {
                    this.Text = "ErogeTimer @同期中(ダウンロード)";
                    string userName = label1.Text;
                    string postDataStr = "userName=" + userName;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://106.187.52.177:8080/satoru/sync.php");
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Timeout = 5000;
                    request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
                    Stream myRequestStream = request.GetRequestStream();
                    StreamWriter myStreamWriter = new StreamWriter(myRequestStream);
                    myStreamWriter.Write(postDataStr);
                    myStreamWriter.Close();
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    string retString = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();


                    this.Text = "ErogeTimer @同期中(上書き)";
                    XmlDocument xmlLocalSyncDoc = new XmlDocument();
                    xmlLocalSyncDoc.Load(syncPath);
                    XmlNode syncDocRoot = xmlLocalSyncDoc.SelectSingleNode("Sync");
                    XmlNodeList opt = syncDocRoot.ChildNodes;
                    XmlNodeList eroges = opt[1].ChildNodes;


                    string[] s = retString.Split(new char[] { '\n' });
                    if (retString == String.Empty)
                    {//新建用户名后清除旧同步日志
                        opt[1].RemoveAll();
                        xmlLocalSyncDoc.Save(syncPath);
                    }
                    else
                    {//服务器xml和本地同步xml比较，变化存入数组s
                        for (int i = 0; i < s.Count(); i++)
                        {
                            string[] detail = s[i].Split(',');//服务器
                            foreach (XmlNode erogeNode in eroges)
                            {
                                string localSyncTitle;//本地缓存
                                string localSyncTime;
                                XmlNode localSyncTitleNode = erogeNode.SelectSingleNode("title");
                                localSyncTitle = localSyncTitleNode.InnerText;
                                XmlNode localSyncTimeNode = erogeNode.SelectSingleNode("time");
                                localSyncTime = localSyncTimeNode.InnerText;
                                if (detail[0] == localSyncTitle)
                                {
                                    float t1 = float.Parse(detail[1]);
                                    float t2 = float.Parse(localSyncTime);
                                    float t = t1 - t2;
                                    detail[1] = t.ToString("f3");
                                    s[i] = localSyncTitle + "," + detail[1];
                                }
                            }
                        }//服务器xml和本地同步xml比较，变化存入数组s
                    }

                    XmlDocument xmlLocalConfigDoc = new XmlDocument();
					xmlLocalConfigDoc.Load(dataPath);
                    XmlNode configDocRoot = xmlLocalConfigDoc.SelectSingleNode("Eroges");
                    XmlNodeList configErogeNodes = configDocRoot.ChildNodes;

					//Need To Be fixed
                    //s反应到config.xml
                    if (retString != String.Empty)
                    {
                        foreach (String sChange in s)
                        {
                            string[] detail = sChange.Split(',');
                            if (detail[1] != "0.000")
                            {
                                bool flag = true;
                                foreach (XmlNode configErogeNode in configErogeNodes)
                                {
                                    string localConfigTitle;
                                    string localConfigTime;
                                    XmlNode titleNode = configErogeNode.SelectSingleNode("title");
                                    localConfigTitle = titleNode.InnerText;
                                    XmlNode timeNode = configErogeNode.SelectSingleNode("time");
                                    localConfigTime = timeNode.InnerText;
                                    if (localConfigTitle == detail[0])
                                    {
                                        float t1 = float.Parse(detail[1]);
                                        float t2 = float.Parse(localConfigTime);
                                        float t = t1 + t2;
                                        timeNode.InnerText = t.ToString("f3");
                                        flag = false;
                                    }
                                }
                                if (flag == true)
                                {   //存在新游戏
                                    //appendXML("???", detail[0], detail[1]);
                                    XmlElement erogeNode = xmlLocalConfigDoc.CreateElement("Node");
                                    erogeNode.SetAttribute("path", "???");
                                    XmlElement titleNode = xmlLocalConfigDoc.CreateElement("title");
                                    titleNode.InnerText = detail[0];
                                    erogeNode.AppendChild(titleNode);
                                    XmlElement timeNode = xmlLocalConfigDoc.CreateElement("time");
                                    timeNode.InnerText = detail[1];
                                    erogeNode.AppendChild(timeNode);
                                    configDocRoot.AppendChild(erogeNode);
									xmlLocalConfigDoc.Save(dataPath);
                                }
                            }

                        }
						xmlLocalConfigDoc.Save(dataPath);
                    }
                    //s反应到config.xml



                    //重新载入listview,保存到sync.xml
                    if (lstShow.Items.Count > 0)
                    {
                        foreach (ListViewItem item in lstShow.Items)
                        {
                            this.lstShow.Items.Remove(item);
                        }
                    }

                    opt[1].RemoveAll();//清除sync.xml所有游戏
                    string postDataStr2 = "";

                    foreach (XmlNode erogeNode in configErogeNodes)
                    {
                        string path;
                        string title;
                        string time;
                        XmlElement eN = (XmlElement)erogeNode;
                        path = eN.GetAttribute("path");
                        XmlNode titleNode = erogeNode.SelectSingleNode("title");
                        title = titleNode.InnerText;
                        XmlNode timeNode = erogeNode.SelectSingleNode("time");
                        time = timeNode.InnerText;

                        lstShow.Items.Add(new ListViewItem(new string[] { title, time, path, "resting" }));

                        if (postDataStr2 != string.Empty) { postDataStr2 += "\n"; }
                        else
                        {
                            postDataStr2 = "userName=" + userName + "\n";
                        }
                        postDataStr2 += title + "," + time;

                        XmlElement erogeLocalSyncNode = xmlLocalSyncDoc.CreateElement("Node");
                        XmlElement erogeLocalSyncTitleNode = xmlLocalSyncDoc.CreateElement("title");
                        erogeLocalSyncTitleNode.InnerText = title;
                        erogeLocalSyncNode.AppendChild(erogeLocalSyncTitleNode);
                        XmlElement erogeLocalSyncTimeNode = xmlLocalSyncDoc.CreateElement("time");
                        erogeLocalSyncTimeNode.InnerText = time;
                        erogeLocalSyncNode.AppendChild(erogeLocalSyncTimeNode);
                        opt[1].AppendChild(erogeLocalSyncNode);
                        xmlLocalSyncDoc.Save(syncPath);


                    }
            //        listStyle();
                    //重新载入listview


                    //MessageBox.Show(postDataStr2);
                    //post listChanges
                    this.Text = "ErogeTimer @同期中(アップロード)";
                    HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("http://106.187.52.177:8080/satoru/sync.php");
                    request2.Method = "POST";
                    request2.Timeout = 5000;
                    request2.ContentType = "application/x-www-form-urlencoded";
                    request2.ContentLength = Encoding.UTF8.GetByteCount(postDataStr2);
                    Stream myRequestStream2 = request2.GetRequestStream();
                    StreamWriter myStreamWriter2 = new StreamWriter(myRequestStream2);
                    myStreamWriter2.Write(postDataStr2);
                    myStreamWriter2.Close();
                    HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                    Stream myResponseStream2 = response2.GetResponseStream();
                    StreamReader myStreamReader2 = new StreamReader(myResponseStream2, Encoding.GetEncoding("utf-8"));
                    string retString2 = myStreamReader2.ReadToEnd();
                    myStreamReader2.Close();
                    myResponseStream2.Close();
					if (File.Exists(dataBakPath))
                    {
						File.Delete(dataBakPath);
                    }
                    if (File.Exists(syncBakPath))
                    {
                        File.Delete(syncBakPath);
                    }
                    if (retString2 == "ok")
                    {
                        MessageBox.Show("同期完了", "ErogeTimer");
                    }


                }
                catch 
                {
                    MessageBox.Show("同期できませんでしたが、バックアップが作成しました", "ErogeTimer");

                }
                this.Text = "ErogeTimer";

                this.timer1.Enabled = true;
            }
            
        }

        //public bool stopFlag;
        //private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        //private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    stopFlag = true;
        //}

        public string gameName = string.Empty;
        public string erogeSavadataPath = string.Empty;
        public Thread backUpThread;
        public Thread restoreThread;
        private void backUp()
        {
            if (erogeSavadataPath != string.Empty)
            {
                try
                {
                    this.Text = ("ErogeTimer @バックアップ中(圧縮)");
                    string folder = erogeSavadataPath.Substring(0, erogeSavadataPath.LastIndexOf("\\"));//存档同级目录
                    if (!File.Exists(erogeSavadataPath))
                    {//文件夹
                        FileInfo[] info = { };
                        GZip.Compress(info, new string[] { erogeSavadataPath }, folder, folder, gameName + ".gzip");
                        //GZip.Decompress(folder, Path.Combine(folder, "newfolder"), gameName + ".gzip");
                    }
                    else
                    {//文件
                        FileInfo[] info = { new FileInfo(erogeSavadataPath) };
                        GZip.Compress(info, new string[] { }, folder, folder, gameName + ".gzip");
                        //GZip.Decompress(folder, Path.Combine(folder, "newfolder"), gameName + ".gzip");
                    }
                    this.Text = ("ErogeTimer @バックアップ中(アップロード)");
                    Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                    WebClient client = new WebClient();
                    string userName = label1.Text;
                    byte[] bytes = client.UploadFile("http://106.187.52.177:8080/satoru/savedata.php?username=" + userName, Path.Combine(folder, gameName + ".gzip"));
                    string result = enc.GetString(bytes);
                    File.Delete(folder + "//" + gameName + ".gzip");
                    this.Text = ("ErogeTimer");
                    MessageBox.Show(result);
                }
                catch 
                {
                    MessageBox.Show("インターネットエラー");
                }
                finally { this.Text = ("ErogeTimer"); }

            }
        }//debug模式下会报错，生成以后没问题
        private void セーブデータをバックアップToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameName = string.Empty;

            if (lstShow.SelectedItems.Count > 0)
            {
                gameName = lstShow.SelectedItems[0].SubItems[0].Text;
                if (gameName != string.Empty || label1.Text != string.Empty)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    string strSourcePath = Application.StartupPath + "\\";
                    string saveDataPath = strSourcePath + "savedata.xml";
                    if (!File.Exists(saveDataPath))
                    {
                        XmlDeclaration xmldecl;
                        xmldecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                        xmlDoc.AppendChild(xmldecl);
                        XmlNode xmlelem0 = xmlDoc.CreateElement("", "Savedata", "");
                        xmlDoc.AppendChild(xmlelem0);
                        xmlDoc.Save(saveDataPath);
                    }

                    XmlDocument xmlSavadataDoc = new XmlDocument();
                    xmlSavadataDoc.Load(saveDataPath);
                    XmlNode savedataDocRoot = xmlSavadataDoc.SelectSingleNode("Savedata");
                    XmlNodeList savedataNodes = savedataDocRoot.ChildNodes;

                    bool flag = false;
                    erogeSavadataPath = string.Empty;
                    foreach (XmlNode savedataNode in savedataNodes)
                    {
                        string title;
                        XmlNode titleNode = savedataNode.SelectSingleNode("title");
                        title = titleNode.InnerText;
                        XmlNode pathNode = savedataNode.SelectSingleNode("path");
                        if (gameName == title)
                        {
                            flag = true;
                            erogeSavadataPath = pathNode.InnerText;
                        }
                    }
                    if (!flag)//未设置路径
                    {
                        if (MessageBox.Show("セーブデータは：\n   フォルダ...はい\n   ファイル...いいえ", "ErogeTimer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {//存档是文件夹
                            FolderBrowserDialog dialog = new FolderBrowserDialog();
                            dialog.Description = "フォルダを選択";
                            dialog.ShowNewFolderButton = false;
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                string foldPath = dialog.SelectedPath;
                                erogeSavadataPath = foldPath;
                            }
                        }
                        else
                        {//存档是文件
                            OpenFileDialog fileDialog = new OpenFileDialog();
                            fileDialog.Multiselect = true;
                            fileDialog.Title = "ファイルを選択";
                            fileDialog.Filter = "すべてのファイル(*.*)|*.*";
                            if (fileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string file = fileDialog.FileName;
                                erogeSavadataPath = file;
                            }
                        }

                        Form3 editSavePathWindow = new Form3();
                        editSavePathWindow.StartPosition = FormStartPosition.Manual;
                        Point a = new Point();

                        a.X = this.Left + 50;
                        a.Y = this.Top + 50;
                        editSavePathWindow.Location = a;
                        editSavePathWindow.Text = "パス編集";
                        editSavePathWindow.Flag = erogeSavadataPath;
                        DialogResult ddr = editSavePathWindow.ShowDialog();
                        if (ddr == DialogResult.OK)
                        {
                            erogeSavadataPath = editSavePathWindow.str;
                            //refreshXML();
                        }


                        if (erogeSavadataPath != string.Empty)
                        {//保存地址
                            XmlNode xmlelem1 = xmlSavadataDoc.CreateElement("", "Node", "");
                            XmlNode xmlelem2 = xmlSavadataDoc.CreateElement("", "title", "");
                            xmlelem2.InnerText = gameName;
                            XmlNode xmlelem3 = xmlSavadataDoc.CreateElement("", "path", "");
                            xmlelem3.InnerText = erogeSavadataPath;
                            xmlelem1.AppendChild(xmlelem2);
                            xmlelem1.AppendChild(xmlelem3);
                            savedataDocRoot.AppendChild(xmlelem1);
                            xmlSavadataDoc.Save(saveDataPath);
                        }
                        
                    }
                    //this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                    //this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.cancelToolStripMenuItem });
                    //this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
                    //this.cancelToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
                    //this.cancelToolStripMenuItem.Text = "cancel";
                    //this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);

                    //stopFlag = false;
                    backUpThread = new Thread(new ThreadStart(backUp));
                    backUpThread.Start();

                    //while (backUpThread.IsAlive)
                    //{
                    //    if (stopFlag == true)
                    //    {
                    //        backUpThread.Abort();
                    //        break;
                    //    }
                    //}
                }
                else
                {
                    MessageBox.Show("ゲーム名またユーザー名存在しない", "ErogeTimer");
                }

            }
            else
            {
                MessageBox.Show("何も選択されていません", "ErogeTimer");
            }
            
        }

        private void restore()
        {
            if (erogeSavadataPath != string.Empty)
            {
                try
                {
                    this.Text = "ErogeTimer @リストア中(ダウンロード)";
                    string userName = label1.Text;
                    this.Text = ("ErogeTimer @リストア中(ダウンロード)");
                    string folder = erogeSavadataPath.Substring(0, erogeSavadataPath.LastIndexOf("\\"));//存档同级目录
                    string URLAddress = @"http://106.187.52.177:8080/satoru/" + userName + "/" + gameName + ".gzip";
                    WebClient client = new WebClient();
                    client.DownloadFile(URLAddress, folder + "//" + gameName + ".gzip");
                    this.Text = ("ErogeTimer @リストア中(解凍)");
                    GZip.Decompress(folder, folder, gameName + ".gzip");
                    File.Delete(folder + "//" + gameName + ".gzip");
                    this.Text = ("ErogeTimer");
                    MessageBox.Show("リストア完了", "ErogeTimer");
                }
                catch { }
                finally
                {
                    this.Text = ("ErogeTimer");
                }

                

            }
        }//debug模式下会报错，生成以后没问题
        private void セーブデータをリストアToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameName = string.Empty;
            if (lstShow.SelectedItems.Count > 0)
            {
                gameName = lstShow.SelectedItems[0].SubItems[0].Text;
                if (gameName != string.Empty || label1.Text != string.Empty)
                {
                    

                    try
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        string strSourcePath = Application.StartupPath + "\\";
                        string saveDataPath = strSourcePath + "savedata.xml";
                        if (!File.Exists(saveDataPath))
                        {
                            XmlDeclaration xmldecl;
                            xmldecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                            xmlDoc.AppendChild(xmldecl);
                            XmlNode xmlelem0 = xmlDoc.CreateElement("", "Savedata", "");
                            xmlDoc.AppendChild(xmlelem0);
                            xmlDoc.Save(saveDataPath);
                        }

                        XmlDocument xmlSavadataDoc = new XmlDocument();
                        xmlSavadataDoc.Load(saveDataPath);
                        XmlNode savedataDocRoot = xmlSavadataDoc.SelectSingleNode("Savedata");
                        XmlNodeList savedataNodes = savedataDocRoot.ChildNodes;

                        bool flag = false;
                        erogeSavadataPath = string.Empty;
                        foreach (XmlNode savedataNode in savedataNodes)
                        {
                            string title;
                            XmlNode titleNode = savedataNode.SelectSingleNode("title");
                            title = titleNode.InnerText;
                            XmlNode pathNode = savedataNode.SelectSingleNode("path");
                            if (gameName == title)
                            {
                                flag = true;
                                erogeSavadataPath = pathNode.InnerText;

                            }
                        }
                        if (!flag)//未设置路径
                        {
                            if (MessageBox.Show("セーブデータは：\n   フォルダ...はい\n   ファイル...いいえ", "ErogeTimer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {//存档是文件夹
                                FolderBrowserDialog dialog = new FolderBrowserDialog();
                                dialog.Description = "フォルダを選択";
                                dialog.ShowNewFolderButton = false;
                                if (dialog.ShowDialog() == DialogResult.OK)
                                {
                                    string foldPath = dialog.SelectedPath;
                                    erogeSavadataPath = foldPath;
                                }
                            }
                            else
                            {//存档是文件
                                OpenFileDialog fileDialog = new OpenFileDialog();
                                fileDialog.Multiselect = true;
                                fileDialog.Title = "ファイルを選択";
                                fileDialog.Filter = "すべてのファイル(*.*)|*.*";
                                if (fileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    string file = fileDialog.FileName;
                                    erogeSavadataPath = file;
                                }
                            }

                            if (erogeSavadataPath != string.Empty)
                            {//保存地址
                                XmlNode xmlelem1 = xmlSavadataDoc.CreateElement("", "Node", "");
                                XmlNode xmlelem2 = xmlSavadataDoc.CreateElement("", "title", "");
                                xmlelem2.InnerText = gameName;
                                XmlNode xmlelem3 = xmlSavadataDoc.CreateElement("", "path", "");
                                xmlelem3.InnerText = erogeSavadataPath;
                                xmlelem1.AppendChild(xmlelem2);
                                xmlelem1.AppendChild(xmlelem3);
                                savedataDocRoot.AppendChild(xmlelem1);
                                xmlSavadataDoc.Save(saveDataPath);
                            }
                        }

                        restoreThread = new Thread(new ThreadStart(restore));
                        restoreThread.Start();
                    }
                    catch
                    {
                        MessageBox.Show("インタネットエラーまたはバックアップ存在しない");
                    }
                    
                }
                else
                {
                    MessageBox.Show("ゲーム名またユーザー名存在しない", "ErogeTimer");
                }
            }
            else
            {
                MessageBox.Show("何も選択されていません", "ErogeTimer");
            }


            
            
        }

        private void lstShow_ColumnClick(object sender, ColumnClickEventArgs e)
        {
     /*       Sorter s = (Sorter)lstShow.ListViewItemSorter;
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
            refreshXML();*/
        }

        private void checkUpdate()
        {
            try
            {
                Thread.Sleep(5000);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://106.187.52.177:8080/satoru/checkupdate.php");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Timeout = 5000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                if (retString != Utility.version)
                {
                    if (MessageBox.Show("新しいバージョンがあります、確認しますか？\n" + Utility.version + "-->" + retString, "ErogeTimer", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("http://106.187.52.177:8080/satoru/erogetimer.html");
                    }
                }
            }
            catch { }

        }

		private void lstShow_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

	}
}
