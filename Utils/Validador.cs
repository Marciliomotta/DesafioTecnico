using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utils
{
    public class Validador
    {
        public static bool ValidarCpf(string codigoCPF)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            //nada para validar
            if (string.IsNullOrEmpty(codigoCPF))
                return true;

            codigoCPF = codigoCPF.Replace(".", "").Replace("-", "").Replace(" ", "").Replace(",", "").Replace("_", "");

            if (codigoCPF.Length != 11)
                return false;

            switch (codigoCPF)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "22222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            tempCpf = codigoCPF.Substring(0, 9);
            soma = 0;
            try
            {
                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();
                tempCpf = tempCpf + digito;

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();
            }
            catch (Exception)
            {
                return false;
            }

            return codigoCPF.EndsWith(digito, StringComparison.CurrentCulture);
        }

        public static bool ValidarNome(string Nome)
        {
            int flag = 0;
            bool validador = true;
            int j = 0;
            for (int i = 0; i < Nome.Length; i++)
            {
                if (Nome[i] == ' ')
                    break;
                j++;
            }
            if (j < 2)
                validador = false;
            else
            {
                string[] NovoNome = Nome.Split(' ');
                foreach (var parte in NovoNome)
                {
                    if (parte.Length == 1)
                    {
                        flag++;
                    }
                    else
                    {
                        flag = 0;
                    }

                }
                if (flag > 3)
                    validador = false;
            }


            return validador;
        }


        public static bool ValidarEmail(string Email)
        {
            bool emailValido = false;

            if (String.IsNullOrEmpty(Email))
                return emailValido;

            emailValido = Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            return emailValido;
        }

        public static bool ValidarData(string value)
        {
            bool isdate = true;

            try
            {
                DateTime newvalue = Convert.ToDateTime(value);
            }
            catch (Exception)
            {
                isdate = false;
            }

            return isdate;
        }
    }
}
