using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Reflection;


//[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Lite
{
	class Log
	{

		public static void Debug(Type type, string str, params object[] args)
		{
			log4net.ILog log = log4net.LogManager.GetLogger(type);
			log.DebugFormat(str, args);
		}

		public static void Info(Type type, string str, params object[] args)
		{
			log4net.ILog log = log4net.LogManager.GetLogger(type);
			log.InfoFormat(str, args);
		}

		public static void Warn(Type type, string str, params object[] args)
		{
			log4net.ILog log = log4net.LogManager.GetLogger(type);
			log.WarnFormat(str, args);
		}

		public static void Fatal(Type type, string str, params object[] args)
		{
			log4net.ILog log = log4net.LogManager.GetLogger(type);
			log.FatalFormat(str, args);
		}

		public static void Error(Type type, string str, params object[] args)
		{
			log4net.ILog log = log4net.LogManager.GetLogger(type);//MethodBase.GetCurrentMethod().DeclaringType);
			log.ErrorFormat(str, args);
		}

		////
		public static void Info(string str)
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine("[Info]: " + str);
			Console.ResetColor();
		}

		public static void Warn(string str)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("[Warn]: " + str);
			Console.ResetColor();
		}

		public static void Error(string str)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("[Error]: " + str);
			Console.ResetColor();
		}

	}
}
