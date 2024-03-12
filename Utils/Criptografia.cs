using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Criptografia
    {
        public static string EsconderParametros(string _cadeia)
        {
            try
            {
                char[] charArray = _cadeia.ToCharArray();
                byte[] byteArray = new byte[charArray.Length];
                string texto = string.Empty;
                for (int i = 0; i < charArray.Length; i++)
                    byteArray[i] = Convert.ToByte(charArray[i]);

                return Convert.ToBase64String(byteArray);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string MostrarParametros(string _cadeia)
        {
            try
            {
                byte[] valorByte = Convert.FromBase64String(_cadeia);
                char[] charArray = new char[valorByte.Length];
                for (int i = 0; i < valorByte.Length; i++)
                    charArray[i] = Convert.ToChar(valorByte[i]);

                return new string(charArray);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
