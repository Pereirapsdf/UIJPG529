using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;



namespace DallJPG529.Contratos529
{
    internal class HashhJPG
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                //    byte[] salt = new byte[16];
                //    rng.GetBytes(salt);

                //    var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
                //byte[] hash = pbkdf2.GetBytes(32);
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                //byte[] hashBytes = new byte[48];
                //Array.Copy(salt, 0, hashBytes, 0, 16);
                //Array.Copy(hash, 0, hashBytes, 16, 32);
                return Convert.ToBase64String(bytes);
            }
       
        }
        //public static bool VerifyPassword(string password, string storedHash)
        //{
        //     byte[] hashBytes = Convert.FromBase64String(storedHash);

        //    byte[] salt = new byte[16];
        //    Array.Copy(hashBytes, 0, salt, 0, 16);

        //    var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
        //    byte[] hash = pbkdf2.GetBytes(32);

        //    for (int i = 0; i < 32; i++)
        //    {
        //        if (hashBytes[i + 16] != hash[i]) return false;
        //    }

        //    return true;
        //}

        
    }
}
