using System;
using System.Security.Cryptography;

namespace cookbookAPI.Utilities
{
    public static class Encryptor
    {
        public static string Encrypt(string password, string salt)
        {
            SHA256 encrypt = new SHA256Managed();
            
            password = password + salt;
            return BitConverter.ToString(encrypt.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password)));
        }

        public static string CreateSaltForEncryption()
        {
            byte[] salt = new byte[64];
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            random.GetNonZeroBytes(salt);

            return BitConverter.ToString(salt);  
        }
 
    }
}
