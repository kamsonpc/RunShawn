using DbUp;
using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace RunShaw.Database
{
    public static class DbUpdater
    {
        private static readonly string configFilePath = Environment.CurrentDirectory + "\\..\\ConnectionsStrings.config";

        private static string ReadConnectionStringConfig()
        {
            if (!File.Exists(configFilePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ConnectionsString.config in {configFilePath} Not Found");
                Console.ResetColor();
                throw new Exception($"ConnectionsString.config in {configFilePath} Not Found");
            }

            string text = File.ReadAllText(configFilePath);
            return GetConnectionString(text);
        }

        public static string GetConnectionString(string text)
        {
            Match serverMatch = Regex.Match(text, @"Data Source=([A-Za-z0-9_.\\]+)", RegexOptions.IgnoreCase);
            Match databaseMatch = Regex.Match(text, @"Initial Catalog=([A-Za-z0-9_]+)", RegexOptions.IgnoreCase);
            Match passwordMatch = Regex.Match(text, @"Password=([A-Za-z0-9_]+)", RegexOptions.IgnoreCase);
            Match loginMatch = Regex.Match(text, @"User ID=([A-Za-z0-9_]+)", RegexOptions.IgnoreCase);

            if (serverMatch.Success && databaseMatch.Success && passwordMatch.Success && loginMatch.Success)
            {
                String server = serverMatch.Groups[1].Value;
                String database = databaseMatch.Groups[1].Value;
                String password = passwordMatch.Groups[1].Value;
                String login = loginMatch.Groups[1].Value;

                return $"Data Source={server};Initial Catalog={database};User ID={login};Password={password}";
            }
            return string.Empty;
        }

        private static int Main(string[] args)
        {
            string connectionString = ReadConnectionStringConfig();
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ConnectionString");
                Console.ResetColor();
                throw new Exception("Invalid ConnectionString");
            }

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();

                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
