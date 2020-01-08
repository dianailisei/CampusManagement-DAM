using System;
using System.Collections.Generic;
using System.Text;

namespace UCM.Business.Logger
{
    public class Logger
    {
        private static Logger Instance = null;

        private Logger() { }

        public Logger GetInstance()
        {
            if (Instance == null)
                return new Logger();
            return Instance;
        }

        public void Log(string message)
        {
            System.IO.File.WriteAllText(@"C:\Users\Mihai\Documents\Visual Studio 2019", DateTime.Now +" : " + message);
        }
    }
}
