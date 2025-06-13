using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class SimpleEncryptor
{
    private static readonly string password = "Encrpterd1598522_DelpmentByOmar";

    public static string Encrypt(string plainText)
    {
        byte[] salt = Encoding.UTF8.GetBytes("mysalt123");
        var key = new Rfc2898DeriveBytes(password, salt, 1000);

        using (var aes = new RijndaelManaged())
        {
            aes.Key = key.GetBytes(32);
            aes.IV = key.GetBytes(16);

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(plainText);
                }

                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    public static string Decrypt(string cipherText)
    {
        byte[] salt = Encoding.UTF8.GetBytes("mysalt123");
        var key = new Rfc2898DeriveBytes(password, salt, 1000);

        using (var aes = new RijndaelManaged())
        {
            aes.Key = key.GetBytes(32);
            aes.IV = key.GetBytes(16);

            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream(Convert.FromBase64String(cipherText)))
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            using (var sr = new StreamReader(cs))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
