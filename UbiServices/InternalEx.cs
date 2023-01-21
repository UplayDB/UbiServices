namespace UbiServices
{
    internal class InternalEx
    {
        public static void WriteEx(Exception ex)
        {
            string ToWrite = "\n";
            ToWrite += DateTime.UtcNow.ToString("yyyy.MM.dd hh:mm:ss") + " (UTC)";
            ToWrite += $"\n{ex.InnerException}";
            ToWrite += $"\n{ex.StackTrace}";
            ToWrite += $"\n{ex.Message}";
            ToWrite += $"\n{ex.Source}";
            File.AppendAllText("UbiServices_Ex.txt", ToWrite);
        }
    }
}
