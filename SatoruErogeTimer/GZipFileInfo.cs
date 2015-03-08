using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatoruErogeTimer
{
	public class GZipFileInfo
	{
		public int Index = 0;
		public string RelativePath = null;
		public DateTime ModifiedDate;
		public int Length = 0;
		public bool AddedToTempFile = false;
		public bool RestoreRequested = false;
		public bool Restored = false;
		public string LocalPath = null;
		public string Folder = null;

		public bool ParseFileInfo(string fileInfo)
		{
			bool success = false;
			try
			{
				if (!string.IsNullOrEmpty(fileInfo))
				{
					// get the file information
					string[] info = fileInfo.Split(',');
					if (info != null && info.Length == 4)
					{
						this.Index = Convert.ToInt32(info[0]);
						this.RelativePath = info[1].Replace("/", "\\");
						this.ModifiedDate = Convert.ToDateTime(info[2]);
						this.Length = Convert.ToInt32(info[3]);
						success = true;
					}
				}
			}
			catch
			{
				success = false;
			}
			return success;
		}
	}
}
