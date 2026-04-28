using System.Diagnostics;
using System.Text;

namespace ULMSWinFormsApp.Helpers
{
    internal static class NonFunctionalTestLogger
    {
        private static readonly object SyncRoot = new object();
        private static readonly Dictionary<string, int> OperationCounts = new Dictionary<string, int>();

        public static string LogFilePath { get; } =
            Path.Combine(AppContext.BaseDirectory, "NonFunctionalTestResults.csv");

        public static Stopwatch StartTimer()
        {
            return Stopwatch.StartNew();
        }

        public static void LogPerformance(string operation, Stopwatch stopwatch, string result, string details = "")
        {
            stopwatch.Stop();
            WriteRow("Performance", operation, stopwatch.ElapsedMilliseconds, result, details);
        }

        public static void LogUsability(string operation, int navigationSteps, string details = "")
        {
            WriteRow("Usability", operation, 0, "Steps=" + navigationSteps, details);
        }

        public static void LogSecurity(string operation, Stopwatch stopwatch, string result, string details = "")
        {
            stopwatch.Stop();
            WriteRow("Security", operation, stopwatch.ElapsedMilliseconds, result, details);
        }

        public static void LogReliability(string operation, Stopwatch stopwatch, string result, string details = "")
        {
            stopwatch.Stop();
            int count = IncrementOperationCount(operation);
            WriteRow("Reliability", operation, stopwatch.ElapsedMilliseconds, result, "Run=" + count + "; " + details);
        }

        public static int GetOperationCount(string operation)
        {
            lock (SyncRoot)
            {
                return OperationCounts.TryGetValue(operation, out int count) ? count : 0;
            }
        }

        private static int IncrementOperationCount(string operation)
        {
            lock (SyncRoot)
            {
                OperationCounts.TryGetValue(operation, out int count);
                count++;
                OperationCounts[operation] = count;
                return count;
            }
        }

        private static void WriteRow(string testType, string operation, long elapsedMilliseconds, string result, string details)
        {
            lock (SyncRoot)
            {
                bool addHeader = !File.Exists(LogFilePath);
                using StreamWriter writer = new StreamWriter(LogFilePath, append: true, Encoding.UTF8);

                if (addHeader)
                {
                    writer.WriteLine("Timestamp,TestType,Operation,ElapsedMilliseconds,Result,Details");
                }

                writer.WriteLine(string.Join(",",
                    Escape(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    Escape(testType),
                    Escape(operation),
                    elapsedMilliseconds,
                    Escape(result),
                    Escape(details)));
            }
        }

        private static string Escape(string value)
        {
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }
    }
}
