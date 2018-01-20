using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemniarPI
{
    static class DBaccess
    {
        #region Data lists
        public static Dictionary<Koktel,List<Sastojci>> MyKoktels
        {
            get => GetFullSastojciKoktelPars(GetMyKoktels(MySastojcis));
        }
        public static List<Sastojci> MySastojcis = new List<Sastojci>();
        public static List<object> SearchResults;
        private static List<Koktel> _allKoktels;
        public static List<Koktel> AllKoktels
        {
            get
            {
                _allKoktels = _allKoktels is null ? Koktel.CreateKoktailList(SelectAll(Table.Kokteli)) : _allKoktels;
                return _allKoktels;
            }
            set
            {
                _allKoktels = null;
                var shit = AllKoktels;
            }

        }
        public static List<Sastojci> AllSastojci
        {
            get => Sastojci.CreateSastojciList(SelectAll(Table.Sastojci));
        }
        #endregion

        #region SQL queries and DB vars
        private const string QuerYselectAllMaxPairs = "SELECT K_FK as KoktelD, COUNT(*) as NumberOfIngridiens FROM Veze GROUP BY(K_FK)";
        private const string QuerySelectAllSastojiForKoktel = "SELECT Ime,Napomena,Slika FROM Sastojci INNER JOIN Veze V ON Sastojci.S_PK = V.S_FK WHERE V.K_FK == <value>";
        private const string QuerYselectMyKoktelSastojciPairs =
            "SELECT K_PK,COUNT(*) as Times FROM (SELECT K_PK,Ime,Opis,Upute,Slika FROM Kokteli INNER JOIN Veze V ON Kokteli.K_PK = V.K_FK Where (S_FK in (<LIST>))) GROUP BY K_PK";
        private const string QuerYselectMissingSastojciInMyKoktels = "SELECT S_PK,Ime,Napomena,Slika FROM Sastojci INNER JOIN(SELECT K_FK, S_FK from Veze where K_FK = <KID> EXCEPT SELECT K_FK, S_FK from Veze where S_FK in (<LIST>)) as Mid on S_PK = Mid.S_FK";
        private static bool _isOpen;
        public static int Tolerance = 5; //TODO: Encapsulate this fucker (to gui)

        public enum Table
        {
            Kokteli,
            Sastojci,
            Veza
        }
        // create a new database connection:
        private static SQLiteConnection _sqliteConn;
        #endregion

        #region Function control variables

        private static bool _setup;
        private static bool _searchRunningSemaphore = false;
        public static int DelayInterval { get; } = 1000;

        private static Timer _searchDelayTimer = new Timer
        {
            Interval = DelayInterval
        };

        private static void TickMethod(object sender, EventArgs eventArgs)
        {
            var s = (Timer)sender;
            var p1 = MainForm.GetInstance().SelectedTab;
            var p2 = MainForm.GetInstance().SelectedFiled;
            s.Enabled = false;
            var run = new Task<List<object[]>>(() => DBsearch(p1, p2));
            run.Start();
            run.Wait(1000);
            //_focused = Koktel.CreateKoktailList(run.Result); //TODO: Select
            MainForm.GetInstance().SearchingPB.Visible = false;
        }

        private static List<object[]> DBsearch(MainForm.Tabs selectedTab, string selectedFiled)
        {
            List<object[]> res = null;
            var query = MainForm.GetInstance().SearchQuery;
            switch (selectedTab)
            {
                case MainForm.Tabs.MojiKokteli:
                    //TODO: Search lists
                    break;
                case MainForm.Tabs.MojiSastojci:
                    //TODO: Search list
                    break;
                case MainForm.Tabs.SviSastojci:
                case MainForm.Tabs.SviKokteli:
                    //TODO: Search base
                    string where = selectedFiled + " LIKE '%" + query + "%'";
                    res = SelectAll(selectedTab == MainForm.Tabs.SviKokteli ? Table.Kokteli : Table.Sastojci, where);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(selectedTab), selectedTab, null);
            }
            return res;
        }

        #endregion
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
        public static List<object[]> SelectAll(Table tablica, string where = null)
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
            if (where != null)
            {
                sqliteCmd.CommandText = sqliteCmd.CommandText + " WHERE (" + where + ")";
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
            //return list.Count == 0 ? null : list;
        }

        public static List<Koktel> GetMyKoktels(List<Sastojci> mySastojcis)
        {
            if (mySastojcis is null || mySastojcis.Count == 0)
                return null;
            //Get number of ing for each coctail
            List<int[]> koktelSastocjiNumberPairs = GetTwoIntPairs(QuerYselectAllMaxPairs);
            //Get number of ing contained in each Koktel based on inputed mySastojci in 3 steps
            //1) Get PK from mySastojci objects
            var listQuery = "";
            mySastojcis.ForEach(x => listQuery += x.Id.ToString() + ",");
            listQuery = listQuery.Remove(listQuery.Length - 1);
            List<int[]> myKoktelSastocjiNumberPairs = GetTwoIntPairs(QuerYselectMyKoktelSastojciPairs.Replace("<LIST>", listQuery));
            //2) Compare the two and get valid Koktels relative to Tolerance; TODO: Add <real> tolerance n shit
            var theChosenOnes = new List<int>();
            foreach (var o in koktelSastocjiNumberPairs)
            {
                var thePair = new int[2];
                if ((thePair = myKoktelSastocjiNumberPairs.FirstOrDefault(x => x[0] == o[0])) == null)
                    continue;
                //Add to final list
                if (o[1] - thePair[1] <= Tolerance) //0->Tolerance, in this case 0 TODO: Create <real> tolerance field
                    theChosenOnes.Add(thePair[0]); //Add ID to the list of requested Koktels
            }
            //2.1 Get IDs of Koktels passing the test above (SUB <= Tolerance)
            var finalListQuery = "";
            theChosenOnes.ForEach(x => finalListQuery += x.ToString() + ',');
            finalListQuery = finalListQuery.Remove(finalListQuery.Length - 1);
            //3) Use IDs to get Koktels from the DB 
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

        public static Dictionary<Koktel, List<Sastojci>> GetMissingSastojciForKoktelList(List<Koktel> myKoktels, List<Sastojci> mySastojcis)
        {
            string listQuery = "";
            mySastojcis.ForEach(x => listQuery += x.Id.ToString() + ",");
            listQuery = listQuery.Remove(listQuery.Length - 1);
            string rawQuery = QuerYselectMissingSastojciInMyKoktels;
            var pairs = new Dictionary<Koktel, List<Sastojci>>();
            foreach (var koktel in myKoktels)
            {
                var newQuery = rawQuery.Replace("<KID>", koktel.ID.ToString()).Replace("<LIST>", listQuery);
                var row = SelectAll(newQuery);
                if (row is null)
                {
                    var shit = new Exception("Well, shit");
                    throw shit; //ha ha look, me funny X)
                }
                pairs.Add(koktel, Sastojci.CreateSastojciList(row));
            }
            return pairs;
        }
        public static Dictionary<Koktel, List<Sastojci>> GetFullSastojciKoktelPars(List<Koktel> k)
        {
            if (k is null)
                return null;
            var dic = new Dictionary<Koktel, List<Sastojci>>();
            foreach (var item in k)
            {
                var sastojci = Sastojci.CreateSastojciList(SelectAll(QuerySelectAllSastojiForKoktel.Replace("<value>", item.ID.ToString())));
                dic.Add(item, sastojci);
            }
            return dic;
        }
        public static void ResetTimer()
        {
            if (!_setup)
            {
                _searchDelayTimer.Tick += TickMethod;
                _setup = !_setup;
            }
            //TODO: Check semaphore's work
            if (_searchRunningSemaphore)
            {
                if (_searchDelayTimer.Enabled)
                    _searchDelayTimer.Stop();
                return;
            }
            _searchDelayTimer.Stop();
            _searchDelayTimer.Start();
        }

        public static void DisableTimer()
        {
            _searchDelayTimer.Stop();
            _searchDelayTimer.Enabled = false;
        }
        public static object BindRowToItem(DataGridViewRow var, object list, MainForm.Tabs tab)
        {
            switch (tab)
            {
                case MainForm.Tabs.MojiKokteli:
                    break;
                case MainForm.Tabs.SviKokteli:
                    break;
                case MainForm.Tabs.MojiSastojci:
                    break;
                case MainForm.Tabs.SviSastojci:
                    break;
            }
        }
    }
}