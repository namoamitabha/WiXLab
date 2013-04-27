using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Microsoft.Win32;

namespace IA.WiXDemo.Lib
{
	public class Config
	{
		private const string LogFileKeyName = "LogFile";
		private const string AppKeyName = "SOFTWARE\\WiXDemo";
		public static string LogFileLocation()
		{
			RegistryKey regLM = Registry.LocalMachine;
			RegistryKey regLogFile = regLM.OpenSubKey(AppKeyName);
            //TODO: how to read the registry on x64
			try
			{
				return regLogFile.GetValue(LogFileKeyName).ToString();
			}
			catch (Exception ex)
			{
                throw ex;
			}
		}

		public static void CreateLogFileRegistryKey(string logFileLocation)
		{
			if (string.IsNullOrEmpty(logFileLocation))
				throw new ArgumentNullException("logFileLocation");

			RegistryKey regLM = Registry.LocalMachine;

			if (!regLM.GetSubKeyNames().Contains(AppKeyName))
			{
				var regApp = regLM.CreateSubKey(AppKeyName);

				regApp.SetValue(
					LogFileKeyName,
					logFileLocation);
			}
		}

		public static void RemoveLogFileRegistryKey()
		{
			RegistryKey regLM = Registry.LocalMachine;

			if (regLM.OpenSubKey(AppKeyName) != null)
			{
				regLM.DeleteSubKey(AppKeyName);
			}
		}
	}
}
