using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Xess.Infrastructure.DataSources.WinFolder
{
    public class FileFuncs
    {
        public static String GetBytesStringKB(Int64 bytesCount)
        {
            Int64 bytesShow = (bytesCount + 1023) >> 10;
            String bytesString = GetPointString(bytesShow) + " KB";
            return bytesString;
        }

        private static String GetPointString(Int64 value)
        {
            String pointString = value.ToString();

            Int32 i = 3;
            while (pointString.Length > i)
            {
                pointString = pointString.Substring(0, pointString.Length - i) + "." + pointString.Substring(pointString.Length - i, i);
                i += 4;
            }

            return pointString;
        }
    }
}
