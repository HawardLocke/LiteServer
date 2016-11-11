﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lite
{
	abstract class BaseThread
	{
		Thread thread = null;
		abstract public void run();

		public void Start()
		{
			if (thread == null)
				thread = new Thread(run);
			thread.Start();
		}
	}
}