namespace ExamPortalApp.Infrastructure.Helpers
{
    internal static class ByteArrayExtensions
    {
        public static string ToBase64String(this byte[] byteArray)
        {
            return Convert.ToBase64String(byteArray);
        }
    }
}
