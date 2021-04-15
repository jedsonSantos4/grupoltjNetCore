using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppCore.Helpers
{
    public static class Crypto
    {
        private static readonly string key = "LtjGr#p@";

        public static string ConvertToCrypto(string psw) {

            if (string.IsNullOrEmpty(psw))
                return string.Empty;

            psw += key;

            var passwordBytes = Encoding.UTF8.GetBytes(psw);

            return Convert.ToBase64String(passwordBytes);
        }

        public static string ConvertToDeCrypto(string pswByte)
        {

            if (string.IsNullOrEmpty(pswByte))
                return string.Empty;

            var decrypto = Convert.FromBase64String(pswByte);
            var result = Encoding.UTF8.GetString(decrypto);

            return result.Substring(0, result.Length - key.Length);           

        }

        public static bool IsAlphNumEsp(string psw)
        {
            if (string.IsNullOrWhiteSpace(psw))
                return false;

            try
            {                
                Regex r = new(@"^[ A-Za-z0-9_@./#&+-]*$");
                if (r.IsMatch(psw))
                    return true;
                else
                    return false;
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

           
        }


        public static bool IsValid(string source, string client) =>  source.Trim().Equals(client.Trim());



    }
}
