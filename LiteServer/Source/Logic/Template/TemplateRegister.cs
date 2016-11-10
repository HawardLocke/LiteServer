using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite
{
	class TemplateRegister
	{
		public static void RegisterALL()
		{
			string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string filePath = exePath.Substring(0, exePath.LastIndexOf('\\')+1) + "Template\\";
			var mgr = TemplateManager.Instance;
			mgr.Register(typeof(Npc0_Data), filePath + "Npc0.txt");
			//...
		}
	}
}
