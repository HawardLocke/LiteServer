using System;
using System.IO;
using System.Text;
using System.Configuration;
using Lite;

namespace Lite
{
	sealed class ConfigUtil
	{
		// timers
		public static int ServerTickTime = 200;
		public static int ConfigUpdateTime = 60*1000;

		// redis
		public static string RedisHost = "127.0.0.1";
		public static int RedisPort = 8801;
		public static int RedisSaveTime = 5*60*1000;

		// web
		public static string WebUrl = "http://127.0.0.1:gate.php";
		public static string ZeromqUri = "";


		public static void LoadConfig()
		{
			try
			{
				//Log.Info("loading/updating config...");

				ServerTickTime = Int32.Parse(GetValue("ServerTickTime"));
				ConfigUpdateTime = Int32.Parse(GetValue("ConfigUpdateTime"));

				RedisHost = GetValue("RedisHost");
				RedisPort = Int32.Parse(GetValue("RedisPort"));
				RedisSaveTime = Int32.Parse(GetValue("RedisSaveTime"));

				WebUrl = GetValue("WebUrl");
				ZeromqUri = GetValue("ZeromqUri");

				//Log.Info("load/update config done.");
			}
			catch(Exception e)
			{
				Log.Error("ConfigUtil : " + e.ToString());
			}
		}

		static string GetValue(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}
	}
}
