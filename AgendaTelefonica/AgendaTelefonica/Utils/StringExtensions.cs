using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Utils
{
    public static class StringExtensions
    {
        public static bool ContainsCaseInsensitive(this string holder, string target)
        {
            if (target.Length > holder.Length) return false;

            return holder.ToUpper().Contains(target.ToUpper());
        }
    }
}
