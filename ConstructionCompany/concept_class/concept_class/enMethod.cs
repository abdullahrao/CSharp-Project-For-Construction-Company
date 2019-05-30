using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace concept_class
{
    class enMethod
    {

        public string MD5Encrypt(string txt)
        {
            MD5 Obj = new MD5CryptoServiceProvider();

            Obj.ComputeHash(ASCIIEncoding.ASCII.GetBytes(txt));

            byte[] rst = Obj.Hash;

            StringBuilder StrBuilder = new StringBuilder();

            for (int i = 0; i < rst.Length; i++)
            {
                StrBuilder.Append(rst[i].ToString("x2"));
            }

            return StrBuilder.ToString();



        }
    }
}
