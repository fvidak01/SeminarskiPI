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
        private const string QUERYselectAllMaxPairs = "SELECT K_FK as KoktelD, COUNT(*) as NumberOfIngridiens FROM Veze GROUP BY(K_FK)";
        private static bool _isOpen;
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
        public static List<object[]> SelectAll(Table tablica)
        {
            if (!_isOpen)
                return null; //TODO: Open connection or throw
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
            var list = new List<object[]>();
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
        public static List<object[]> SelectAll(string query)
        {
            var sqliteCmd = _sqliteConn.CreateCommand();
            sqliteCmd.CommandText = query;
            var reader = sqliteCmd.ExecuteReader();
            var list = new List<object[]>();
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

        public static List<Koktel> GetMyKoktels(List<Sastojci> mySastojcis)
        {
            //Get number of ing for each coctail
            List<int[]> KoktelSastocjiNumberPairs = GetTwoIntPairs(QUERYselectAllMaxPairs);
            //Get number of ing contained in each Koktel based on inputed mySastojci
            //Get PK from mySastojci objects
            var listQuery = "";
            mySastojcis.ForEach(x => listQuery += x.Id.ToString() + ",");
            var array = listQuery.ToCharArray();
            array[listQuery.LastIndexOf(',')] = ' ';
            listQuery = new string(array);
            List<int[]> MyKoktelSastocjiNumberPairs =
                GetTwoIntPairs(
                    "SELECT K_PK,COUNT(*) as Times FROM (SELECT K_PK,Ime,Opis,Upute,Slika FROM Kokteli INNER JOIN Veze V ON Kokteli.K_PK = V.K_FK Where (S_FK in (" + listQuery + "))) GROUP BY K_PK");
            //Compare the two and get full Koktels; TODO: Add tolerance n shit
            var theChosenOnes = new List<int>();
            foreach (var o in KoktelSastocjiNumberPairs)
            {
                var thePair = new int[2];
                if ((thePair = MyKoktelSastocjiNumberPairs.FirstOrDefault(x => x[0] == o[0])) == null)
                    continue;
                //Add to final list
                if (o[1] - thePair[1] <= 0) //0->Tolerance, in this case 0 TODO: Create tolerance field
                    theChosenOnes.Add(thePair[0]); //Add ID to the list of requested Koktels
            }
            //Get IDs to a string
            var finalListQuery = "";
            theChosenOnes.ForEach(x => finalListQuery += x.ToString() + ',');
            var finalArray = finalListQuery.ToCharArray();
            finalArray[finalListQuery.LastIndexOf(',')] = ' ';
            finalListQuery = new string(finalArray);
            //Run the final query 
            var theFinalList = SelectAll("SELECT * FROM Kokteli WHERE K_PK in (" + finalListQuery + ")");
            return Koktel.CreateKoktailList(theFinalList);
        }

        private static List<int[]> GetTwoIntPairs(string query)
        {
            var rawList = SelectAll(query);
            var myList = new List<int[]>();
            foreach (var pair in rawList)
            {
                myList.Add(new[] { int.Parse(pair[0].ToString()), int.Parse(pair[1].ToString()) }); //Possible OverflowExcp due to unchecked long=>int convertion.
            } //^ should work fine given that the DB is quite small (certanly fucking smaller than MAX_INT). Will test
            return myList;
        }
    }
}
