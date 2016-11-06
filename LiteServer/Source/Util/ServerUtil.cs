using System;
using System.Collections.Generic;
using System.Text;
using LiteServer.Common;
using LiteServer.Message;
using LiteServer.Service;
using LiteServer.Timer;

namespace LiteServer.Utility
{
	class ServerUtil
	{
		static ServerUtil server;
		private RedisTimer redis;
		private ConfigTimer config;
		private HttpServer http;

		public static ServerUtil instance
		{
			get
			{
				if (server == null)
					server = new ServerUtil();
				return server;
			}
		}

		public ServerUtil()
		{
		}

		/// <summary>
		/// 服务器初始化
		/// </summary>
		public void Init()
		{
			config = new ConfigTimer(); config.Start();
			//redis = new RedisTimer(); redis.Start();
			//http = new HttpServer(7077); http.Start();

			//Const.users = new Dictionary<long, ClientSession>();
			//var v = RedisUtil.Get("aaa");
			//Console.WriteLine(v);
		}

		/// <summary>
		/// 服务器关闭
		/// </summary>
		public void Close()
		{
			//redis.Stop(); redis = null;
			config.Stop(); config = null;
			http.Stop(); http = null;
		}
	}
}
