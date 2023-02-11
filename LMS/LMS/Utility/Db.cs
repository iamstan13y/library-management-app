using System.Data.SQLite;

namespace LMS.Utility
{
    public class Db
    {
        public static readonly SQLiteConnection Connection = new("Data Source=./LMS.db");
        public static readonly SQLiteCommand? Command;
        public static readonly SQLiteDataReader? DataReader;
        public static readonly SQLiteDataAdapter? Adapter;
    }
}