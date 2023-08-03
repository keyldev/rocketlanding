using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_rocketlanding.MVVM.Models
{
    class LoggerModel
    {
        public static string setLog(string methodName = null, string logType=null)
        { 
            string log = null;
            log = $"[{DateTime.Now}]: {methodName} - {logType};\n";
            return log;
        }
    }
}
