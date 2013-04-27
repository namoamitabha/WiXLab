using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IA.WiXDemo.Lib;

namespace IA.WiXDemo.Test
{
	[TestClass]
	public class DemoLibTest
	{


		[TestMethod]
		public void RandomValue_Must_InRange()
		{
			int r = DemoLib.RandomInit(0, 10);
			Assert.IsTrue( r >= 0 && r <= 10);
		}
	}
}
