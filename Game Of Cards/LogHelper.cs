using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Cards
{
    class LogHelper
    {
        public static log4net.ILog GetLogger([System.Runtime.CompilerServices.CallerFilePath]string filename = "")
        {

            return log4net.LogManager.GetLogger(filename);
        }
    }
}
/*
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Currency_Converter_updates
{
    class LogHelper
    {

        //([CallerFilePath])string filename = "")
        public static log4net.ILog GetLogger([System.Runtime.CompilerServices.CallerFilePath]string filename = "")
        {

            return log4net.LogManager.GetLogger(filename);
        }
    }
}*/
