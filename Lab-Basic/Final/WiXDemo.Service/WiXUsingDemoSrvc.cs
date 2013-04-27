using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using IA.WiXDemo.Lib;

namespace IA.WiXDemo
{
	public partial class WiXUsingDemoSrvc : ServiceBase
	{
	    private Thread thread;
	    public static bool threadActive;
		public WiXUsingDemoSrvc()
		{
			InitializeComponent();
		}

		//static Thread 

		protected override void OnStart(string[] args)
		{
		    threadActive = true;
            ThreadStart job = new ThreadStart(WriteLog);
            this.thread = new Thread(job);
            this.thread.Start();
		}

		protected override void OnStop()
		{
		    threadActive = false;
            this.thread.Join();
		}

        public static void WriteLog()
        {
            string logLocation = Config.LogFileLocation();
            if(!File.Exists(logLocation))
                throw new FileNotFoundException(logLocation);

            while(threadActive)
            {
                using(var sw = new StreamWriter(logLocation,true))
                {
                    sw.WriteLine("Random-{0}-{1}", DemoLib.RandomInit(0, 100), DateTime.Now.ToLongTimeString());
                }
                Thread.Sleep( new TimeSpan(0,0,0,1));
            }
        }
	}
}
