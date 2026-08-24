
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace PawnManagement
{
  internal class AES
  {
    public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
    {
      byte[] numArray = (byte[]) null;
      byte[] salt = passwordBytes;
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
        {
          rijndaelManaged.KeySize = 256;
          rijndaelManaged.BlockSize = 128;
          Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passwordBytes, salt, 1000);
          rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
          rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
          rijndaelManaged.Mode = CipherMode.CBC;
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write))
          {
            cryptoStream.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
            cryptoStream.Close();
          }
          numArray = memoryStream.ToArray();
        }
      }
      return numArray;
    }

    public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
    {
      byte[] numArray = (byte[]) null;
      byte[] salt = passwordBytes;
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
        {
          rijndaelManaged.KeySize = 256;
          rijndaelManaged.BlockSize = 128;
          Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passwordBytes, salt, 1000);
          rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
          rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
          rijndaelManaged.Mode = CipherMode.CBC;
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Write))
          {
            cryptoStream.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
            cryptoStream.Close();
          }
          numArray = memoryStream.ToArray();
        }
      }
      return numArray;
    }

    public static string Encrypt(string text, byte[] passwordBytes)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(text);
      passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
      byte[] randomBytes = AES.GetRandomBytes(AES.GetSaltSize(passwordBytes));
      byte[] bytesToBeEncrypted = new byte[randomBytes.Length + bytes.Length];
      for (int index = 0; index < randomBytes.Length; ++index)
        bytesToBeEncrypted[index] = randomBytes[index];
      for (int index = 0; index < bytes.Length; ++index)
        bytesToBeEncrypted[index + randomBytes.Length] = bytes[index];
      return Convert.ToBase64String(AES.AES_Encrypt(bytesToBeEncrypted, passwordBytes));
    }

    public static string Encrypt(string text, SecureString password)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(text);
      byte[] passwordBytes = AES.GetPasswordBytes(password);
      byte[] hash = SHA256.Create().ComputeHash(passwordBytes);
      byte[] randomBytes = AES.GetRandomBytes(AES.GetSaltSize(hash));
      byte[] bytesToBeEncrypted = new byte[randomBytes.Length + bytes.Length];
      for (int index = 0; index < randomBytes.Length; ++index)
        bytesToBeEncrypted[index] = randomBytes[index];
      for (int index = 0; index < bytes.Length; ++index)
        bytesToBeEncrypted[index + randomBytes.Length] = bytes[index];
      return Convert.ToBase64String(AES.AES_Encrypt(bytesToBeEncrypted, hash));
    }

    public static string Decrypt(string decryptedText, byte[] passwordBytes)
    {
      byte[] bytesToBeDecrypted = Convert.FromBase64String(decryptedText);
      passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
      byte[] numArray = AES.AES_Decrypt(bytesToBeDecrypted, passwordBytes);
      int saltSize = AES.GetSaltSize(passwordBytes);
      byte[] bytes = new byte[numArray.Length - saltSize];
      for (int index = saltSize; index < numArray.Length; ++index)
        bytes[index - saltSize] = numArray[index];
      return Encoding.UTF8.GetString(bytes);
    }

    public static string Decrypt(string decryptedText, SecureString password)
    {
      byte[] bytesToBeDecrypted = Convert.FromBase64String(decryptedText);
      byte[] passwordBytes = AES.GetPasswordBytes(password);
      byte[] hash = SHA256.Create().ComputeHash(passwordBytes);
      byte[] numArray = AES.AES_Decrypt(bytesToBeDecrypted, hash);
      int saltSize = AES.GetSaltSize(hash);
      byte[] bytes = new byte[numArray.Length - saltSize];
      for (int index = saltSize; index < numArray.Length; ++index)
        bytes[index - saltSize] = numArray[index];
      return Encoding.UTF8.GetString(bytes);
    }

    public static int GetSaltSize(byte[] passwordBytes)
    {
      byte[] bytes = new Rfc2898DeriveBytes(passwordBytes, passwordBytes, 1000).GetBytes(2);
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < bytes.Length; ++index)
        stringBuilder.Append(Convert.ToInt32(bytes[index]).ToString());
      int saltSize = 0;
      foreach (char ch in stringBuilder.ToString())
      {
        int int32 = Convert.ToInt32(ch.ToString());
        saltSize += int32;
      }
      return saltSize;
    }

    public static byte[] GetRandomBytes(int length)
    {
      byte[] data = new byte[length];
      RandomNumberGenerator.Create().GetBytes(data);
      return data;
    }

    public static unsafe byte[] GetPasswordBytes(SecureString password)
    {
      byte[] buffer = (byte[]) null;
      if (password.Length == 0)
      {
        buffer = new byte[8]
        {
          (byte) 1,
          (byte) 2,
          (byte) 3,
          (byte) 4,
          (byte) 5,
          (byte) 6,
          (byte) 7,
          (byte) 8
        };
      }
      else
      {
        IntPtr globalAllocAnsi = Marshal.SecureStringToGlobalAllocAnsi(password);
        try
        {
          byte* pointer = (byte*) globalAllocAnsi.ToPointer();
          byte* numPtr = pointer;
          do
            ;
          while (*numPtr++ > (byte) 0);
          int length = (int) (numPtr - pointer - 1L);
          buffer = new byte[length];
          for (int index = 0; index < length; ++index)
          {
            byte num = pointer[index];
            buffer[index] = num;
          }
        }
        finally
        {
          Marshal.ZeroFreeGlobalAllocAnsi(globalAllocAnsi);
        }
      }
      return SHA256.Create().ComputeHash(buffer);
    }
  }
}
