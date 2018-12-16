using System;
using System.Reflection;
using DbUp;

namespace RunShaw.Database
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=RunShaw;User ID=admin;Password=admin";


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

