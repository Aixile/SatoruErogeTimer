using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace SatoruErogeTimer
{
	[XmlRoot("SyncProfile")]
	public class SyncController
	{
		public string user{get;set;}
		public string password { get; set; }

		public SyncController() { }
		public void LoadSyncProfile(){
		}
	/*	List<Eroge> getFromServer()
		{
			return;
		}*/

	}
}
