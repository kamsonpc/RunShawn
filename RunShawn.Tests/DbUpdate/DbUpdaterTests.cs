using RunShaw.Database;
using Xunit;

namespace RunShawn.Tests.DbUpdate
{
    public static class DbUpdaterTests
    {
        [Fact]
        public static void DbUpdater_Return_Valid_ConnectionString()
        {
            const string vaildText = "<connectionStrings> add name=\"DefaultConnection\" connectionString=\"Data Source=.\\SQLEXPRESS;Initial Catalog=RunShaw;User ID=admin;Password=admin\" providerName=\"System.Data.SqlClient\" /><add name=\"Simple.Data.Properties.Settings.DefaultConnectionString\" connectionString=\"Data Source=.\\SQLEXPRESS;Initial Catalog=RunShaw;User ID=admin;Password=admin\" /></connectionStrings>";
            const string expected = "Data Source=.\\SQLEXPRESS;Initial Catalog=RunShaw;User ID=admin;Password=admin";

            var actual = DbUpdater.GetConnectionString(vaildText);
            Assert.Equal(expected, actual);
        }
    }
}
