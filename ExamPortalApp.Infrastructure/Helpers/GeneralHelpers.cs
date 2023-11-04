using ExamPortalApp.Infrastructure.Constants;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace ExamPortalApp.Infrastructure.Helpers
{
    internal static class GeneralHelpers
    {
        public static string EncryptPassword(string password)
        {
            MD5CryptoServiceProvider md5Encryption = new MD5CryptoServiceProvider();
            // Convert the input string to a byte array
            byte[] data = md5Encryption.ComputeHash(Encoding.UTF8.GetBytes(password));
            // Create a new Stringbuilder to collect the bytes and create a string
            StringBuilder sbEncryptedPass = new StringBuilder();
            // Loop through each byte of the encrypted data and format each one as a string. 
            for (int iPass = 0; iPass <= data.Length - 1; iPass++)
            {
                sbEncryptedPass.Append(data[iPass].ToString("x2"));
                iPass = iPass + 1;
            }
            // Return the string
            return sbEncryptedPass.ToString();
        }

        public static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public static FileStream SaveFile(IFormFile file, string prefix, string folder, out string fullPath, out string dbPath)
        {
            if (file == null) throw new Exception(ErrorMessages.FileIsRequired);

            var fileName = prefix + ContentDispositionHeaderValue.Parse(file.ContentDisposition)?.FileName?.Trim('"');
            var folderName = Path.Combine("Uploads", folder);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            FileStream stream;
            
            fullPath = Path.Combine(pathToSave, fileName);
            dbPath = Path.Combine(folderName, fileName);

            using (stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return stream;
        }

        public static async Task<(string, byte[])> AddUploadedTestAsync(IFormFile file)
        {
            
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty.");
            }

            try
            {
                
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    var imageBytes = ms.ToArray();                
                    return (file.FileName, imageBytes);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error uploading file: {ex.Message}");
            }
        }

        public static string RandomPassword(int length)
        {
            const string chars = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&(){}|\][?/>.<:;_-+=";
            var random = new Random();

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
