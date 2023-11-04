using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Infrastructure.Constants;
using System.Security.Cryptography;
using System.Text;

namespace ExamPortalApp.Infrastructure.Helpers
{
    internal static class PasswordHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static string Decrypt(string? text, string encryptionKey)
        {
            if(text == null) { return string.Empty;}
            byte[] buffer = Convert.FromBase64String(text), initialisationVector = new byte[16];

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aes.IV = initialisationVector;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(buffer))
                {
                    using (var cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static string Encrypt(string text, string encryptionKey)
        {
            byte[] array, initialisationVector = new byte[16];

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aes.IV = initialisationVector;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(text);
                        }

                        array = ms.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string GeneratePassword()
        {
            string guid = Guid.NewGuid().ToString("N");
            string password = guid.Substring(0, 8).ToUpper();
            return password;
        }

        public static bool VerifyPasswordHash(string password, byte[]? passwordHash, byte[]? passwordSalt)
        {
            if (passwordHash == null || passwordSalt == null) return false;

            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {

                        /*try
                        {
                            throw new StudentNotFoundException("The user cannot  be found", "please double check your credentials");
                            //throw new Exception(ErrorMessages.Auth.Unauthorised);
                        }
                        catch
                        {
                            throw new StudentNotFoundException("The user cannot  be found", "please double check your credentials");
                            //throw new Exception(ErrorMessages.Auth.Unauthorised);
                        }
                        throw new StudentNotFoundException("The user cannot  be found", "please double check your credentials");*/
                        //throw new Exception(ErrorMessages.Auth.PasswordValidationMessage); //password length error
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool VerifyStudentCredentials(string password, byte[]? passwordHash, byte[]? passwordSalt)
        {
            if (passwordHash == null || passwordSalt == null) return false;
       

            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }

            return true;
        }
    }
}
