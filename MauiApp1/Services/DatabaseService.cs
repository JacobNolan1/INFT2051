
using SQLite;
using Sleepwise.Models;

namespace Sleepwise.Services
{
    internal static class DatabaseService
    {
        private static string _databaseFile;
        private static string DatabaseFile
        {
            get
            {
                if (_databaseFile == null)
                {
                    string databaseDir = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "data");
                    System.IO.Directory.CreateDirectory(databaseDir);

                    _databaseFile = Path.Combine(databaseDir, "sleepwise_data.sqlite");
                }
                return _databaseFile;
            }
        }

        private static SQLiteConnection _connection;
        public static SQLiteConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SQLiteConnection(DatabaseFile);
                    _connection.CreateTable<CategoryModel>();
                    _connection.CreateTable<CategoryTypeModel>();
                    _connection.CreateTable<SummaryCatagoriesModel>();
                    _connection.CreateTable<SummaryModel>();
                    _connection.CreateTable<SummaryTypeModel>();
                    _connection.CreateTable<UserModel>();
                }
                return _connection;
            }
        }
    }
}
