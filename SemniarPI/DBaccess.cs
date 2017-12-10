using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace SemniarPI
{
    static class DBaccess
    {
        private static bool _isOpen = false;
        public enum Table
        {
            Kokteli,
            Sastojci,
            Veza
        }
        // create a new database connection:
        private static SQLiteConnection _sqliteConn;

        // open the connection:
        public static bool DBconnect(FileInfo file)
        {
            _sqliteConn = new SQLiteConnection("Data Source=" + file.FullName + ";Version=3;");
            try
            {
                _sqliteConn.Open();
                _isOpen = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e); //TODO: Log the error
                _isOpen = false;
            }
            return _isOpen;
        }

        public static List<object> SelectAll(Table tablica)
        {
            if (!_isOpen)
                return null; //TODO: Open connection
            var sqliteCmd = _sqliteConn.CreateCommand();
            switch (tablica)
            {
                case Table.Kokteli:
                    sqliteCmd.CommandText = "SELECT * FROM " + Enum.GetName(typeof(Table), Table.Kokteli);
                    break;
                case Table.Sastojci:
                    sqliteCmd.CommandText = "SELECT * FROM " + Enum.GetName(typeof(Table), Table.Sastojci);
                    break;
                case Table.Veza:
                    sqliteCmd.CommandText = "SELECT * FROM " + Enum.GetName(typeof(Table), Table.Veza);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tablica), tablica, null); //TODO: not
            }
            var reader = sqliteCmd.ExecuteReader();
            var list = new List<object>();
            while (reader.Read())
            {
                object[] row = new object[reader.FieldCount];
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = reader.GetValue(i);
                }
                list.Add(row);
            }
            return list;
        }
    }
}
