namespace WRMC.Server.Extensions
{
    public static class ExceptionExtensions
    {
        public static IEnumerable<string> GetMessages(this Exception ex)
        {
            while (ex != null)
            {
                yield return ex.Message;
                ex = ex.InnerException;
            }
        }

    }
}
