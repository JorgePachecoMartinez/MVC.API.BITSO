using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace BitsoProyect
{
    public class ExceptionHandler
    {
        private static ExceptionHandler _Instance;
        private static readonly object _Lock = new object();
        private StreamWriter _StreamWriter;

        public static ExceptionHandler Instance
        {
            get
            {
                lock (_Lock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new ExceptionHandler();
                    }
                }
                return _Instance;
            }
        }

        private ExceptionHandler()
        {
            string exePath = AppDomain.CurrentDomain.BaseDirectory;
            _StreamWriter = new StreamWriter(Path.Combine(exePath, ConfigurationManager.AppSettings["LogNameTxt"].ToString()));
        }

        public void WriteExceptionLog(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"));
            sb.Append(": ");
            sb.Append(ex.Message);
            sb.Append(" || ");
            sb.Append(ex.StackTrace);
            _StreamWriter.WriteLine(sb.ToString());
            _StreamWriter.Flush();
        }
    }
}