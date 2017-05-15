using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace WebDashboardv2.Model
{
    public static class StringExtensions
    {
        public static string ToSentenceCase (this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + m.Value[1]);
        }
    }
}
