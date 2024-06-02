using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SaveSystem.Utils
{
    public static class Encryptor
    {
        private static readonly string _key = "71629384736253748291042749628538";
        private static readonly string _iv = "6273649178275384";
        
        public static string Encrypt(string text)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_key);
                aes.IV = Encoding.UTF8.GetBytes(_iv);

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var encrypt = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(encrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(text);
                        }
                        return Convert.ToBase64String(encrypt.ToArray());
                    }
                }
            }
        }
        
        public static string Decrypt(string encryptedText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_key);
                aesAlg.IV = Encoding.UTF8.GetBytes(_iv);

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var stream = new MemoryStream(Convert.FromBase64String(encryptedText)))
                {
                    using (var cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}