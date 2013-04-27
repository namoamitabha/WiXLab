using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace IA.WiXDemo.Lib
{
	public class DemoLib
	{
		private static Random random = new Random(DateTime.Now.Millisecond);
		public static int RandomInit(int min, int max)
		{
			return random.Next(min, max);
		}
	}
}
