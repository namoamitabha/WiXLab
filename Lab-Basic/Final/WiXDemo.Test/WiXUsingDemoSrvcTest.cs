using System;
using System.Threading;
using IA.WiXDemo.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IA.WiXDemo;

namespace IA.WiXDemo.Test
{
    [TestClass]
    public class WiXUsingDemoSrvcTest
    {
        [TestMethod]
        public void WriteLogSuccessful()
        {
            //Config.CreateLogFileRegistryKey(@"D:\WiXDemoLog\WiXDemo.log");

            WiXUsingDemoSrvc.threadActive = true;
            ThreadStart job = new ThreadStart(WiXUsingDemoSrvc.WriteLog);
            Thread thread = new Thread(job);
            thread.Start();

            Thread.Sleep(new TimeSpan(0,0,20));
            WiXUsingDemoSrvc.threadActive = false;
        }
    }
}
