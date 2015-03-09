using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatoruErogeTimer
{
	class UserNameEventArgs:EventArgs
	{
		string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	}
}
