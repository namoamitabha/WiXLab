using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IA.WiXDemo.Lib;

namespace IA.WiXDemo.Test
{
	[TestClass]
	public class ConfigTest
	{
		[TestMethod]
		public void LogFileLocation_Should_NotNULL_After_Created()
		{
			Config.CreateLogFileRegistryKey("TEST");

			Assert.IsNotNull(Config.LogFileLocation());

			Config.RemoveLogFileRegistryKey();

		}

		[TestMethod]
		public void LogFileLocation_Should_NULL_After_Removed()
		{
			Config.RemoveLogFileRegistryKey();

			Assert.IsNull(Config.LogFileLocation());

		}
        [TestMethod]
        public void LogFileLocation_Should_Exist()
        {
            Config.CreateLogFileRegistryKey(@"D:\WiXDemoLog\WiXDemo.log");

            Assert.IsTrue(File.Exists(Config.LogFileLocation()));

            Config.RemoveLogFileRegistryKey();

        }

		
	}
}
