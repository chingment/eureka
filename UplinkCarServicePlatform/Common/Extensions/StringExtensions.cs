using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumos.Common
{
    public static class StringExtensions
    {
        public static string ToSearchString(this string s)
        {

            if (s == null)
                return null;

            s = s.Trim();
            if(s.Length>1000)
            {
                s = s.Substring(0, 1000);
            }

           
            return s.ToString();
        }
    }
}
