using System.Data.SQLite;

namespace LMS.Utility
{
    public class Db
    {
        public static readonly SQLiteConnection Connection = new("Data Source=./LMS.db");
        public static SQLiteCommand? Command;
        public static SQLiteDataReader? DataReader;
        public static SQLiteDataAdapter? Adapter;
    }
}