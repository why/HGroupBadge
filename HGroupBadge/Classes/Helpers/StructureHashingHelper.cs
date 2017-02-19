using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HGroupBadge.Helpers
{
    public static class StructureHashingHelper
    {
        private const string StaticHash = "ef2356a4926bf225eb86c75c52309c32";

        private static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public static string GetHashedStructure(string structure) 
            => structure + GetMd5Hash(structure + StaticHash);
    }
}
