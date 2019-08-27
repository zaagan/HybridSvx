using System;
using System.IO;
using System.Reflection;

namespace HybridSvx
{
    internal class DataProcessor
    {

        internal void Execute()
        {
            try
            {
                LogMessage();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }


        /// <summary>
        /// Writes a simple message to a file in the application directory
        /// </summary>
        private void LogMessage()
        {
            string assemblyName = Assembly.GetCallingAssembly().GetName().Name;
            string fileName = string.Format(assemblyName + "-{0:yyyy-MM-dd}.log", DateTime.Now);
            string filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;

            string message = "Execution completed at " + DateTime.Now.ToShortTimeString();

            Console.WriteLine(message);
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(message);
                sw.Close();
            }
        }

    }
}
