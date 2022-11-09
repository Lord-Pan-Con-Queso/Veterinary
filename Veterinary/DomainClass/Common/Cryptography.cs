using System.Security.Cryptography;
using System.Text;

namespace DomainClass.Common
{
    public static class Cryptography
    {
        public static String Encriptar(this string value) //En vez de string puedo haber puesto object cosa que encripte lo que llegue (si puede)
        {
            SHA256 sHA256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            //Arreglo de bytes para que caracter por caracter se encripte la contraseña
            byte[] bytes = sHA256.ComputeHash(encoding.GetBytes(value));
            //tengo que construir la cadena a travez del arreglo de bytes ya encriptados anterior.
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
                //AppendFormat porque quiero formatearlo para que en lugar de que los guarde como 0 y 1 los guarde como formato hexadecimal. Con la x lo transforma a hexadecimal y el 2 para que lo represente con 2 cifras, si viene una A deberia devolver 0A.
                sb.AppendFormat("{0:X2}", bytes[i]);
            return sb.ToString();
        }

    }
}