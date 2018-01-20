using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace SemniarPI

{
    public partial class MainForm : MetroForm
    {
        bool[] trackList;
        public string SearchQuery; //For CB
        private static MainForm _me;
        private object _focused;
        public enum Tabs
        {
            MojiKokteli = 1,
            SviKokteli = 0,
            MojiSastojci = 3,
            SviSastojci = 2
        }

        private static Tabs _selectedTab;

        public string SelectedFiled => SearchFieldSelectorCB.Items[SearchFieldSelectorCB.SelectedIndex].ToString(); 
        public Tabs SelectedTab
        {
            get
            {
                int i;
                for (i = 0; i < TabsTC.TabCount; i++)
                {
                    if (TabsTC.SelectedTab.TabIndex == i)
                        break;
                }
                return (Tabs)i;
            }
            set => _selectedTab = value;
        }

        private MainForm()
        {
            InitializeComponent();
        }

        public static MainForm GetInstance()
        {
            if (_me is null)
            {
                _me = new MainForm();
            }
            return _me;
        }
        private void Form1_Load(object sender, EventArgs e)
        { //Code below is for testing purposes and will be removed TODO: Remove, duuh
            TabsTC.SizeMode = TabSizeMode.Fixed;
            this.GridView.RowTemplate.Height = 40;
            DBaccess.DBconnect(new FileInfo("PIdb.db"));
            trackList = new bool[DBaccess.AllSastojci.Count];
            TabSelectionChanged(TabsTC, null);
            var sastojci = new List<object[]>
            {
                new object[] {(long) 1, null, null, null},
                new object[] {(long) 2, null, null, null},
                new object[] {(long) 3, null, null, null},
                new object[] {(long) 4, null, null, null},
                new object[] {(long) 5, null, null, null},
                new object[] {(long) 6, null, null, null},
                new object[] {(long) 7, null, null, null}
            };
            var st = new DataGridViewCellStyle()
            {
                WrapMode = DataGridViewTriState.True,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(2, 5, 2, 5)
            };
            GridView.DefaultCellStyle = st;
            //this.ImeLB.BackColor = Color.Transparent;
        }
        private void metroLabel1_Click(object sender, EventArgs e)
        {
            var settings = new SettingsForm();
            settings.Show();
        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {
            MetroLabel btnSender = (MetroLabel)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            metroContextMenu1.Show(ptLowerLeft);

        }

        private void OnSearchTextChanged(object sender, EventArgs e)
        {
            SearchQuery = ((MetroTextBox)sender).Text;
            if (string.IsNullOrEmpty(SearchQuery))
            {
                //TODO: Disable search, stop the timer, change focus
                DBaccess.DisableTimer();
                SearchingPB.Visible = false;
                return;
            }
            SearchingPB.Visible = true;
            SearchingPB.Enabled = true;
            DBaccess.ResetTimer();
        }

        private void TabSelectionChanged(object sender, EventArgs e)
        {
            switch (SelectedTab)
            {
                case Tabs.MojiKokteli:
                case Tabs.SviKokteli:
                    SearchFieldSelectorCB.Items.Clear();
                    SearchFieldSelectorCB.Items.AddRange(new object[] { "Ime", "Opis", "Upute" });
                    SearchFieldSelectorCB.SelectedIndex = 0;
                    GridView.Columns.Clear();
                    GridView.MultiSelect = false;
                    GridView.Columns.Add(new DataGridViewImageColumn { HeaderText = "", Width = 35,Resizable = DataGridViewTriState.False, ImageLayout = DataGridViewImageCellLayout.Stretch });
                    GridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ime", Width = 75, Resizable = DataGridViewTriState.False });
                    GridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Opis", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, Resizable = DataGridViewTriState.False });
                    if (SelectedTab == Tabs.MojiKokteli)
                        _focused = DBaccess.MyKoktels;
                    else
                        _focused = DBaccess.AllKoktels;
                    break;
                case Tabs.MojiSastojci:
                case Tabs.SviSastojci:
                    GridView.MultiSelect = true;
                    SearchFieldSelectorCB.Items.Clear();
                    SearchFieldSelectorCB.Items.AddRange(new object[] { "Ime", "Napomena" });
                    SearchFieldSelectorCB.SelectedIndex = 0;
                    GridView.Columns.Clear();
                    GridView.Columns.Add(new DataGridViewImageColumn { HeaderText = "", Width = 35, Resizable = DataGridViewTriState.False, ImageLayout = DataGridViewImageCellLayout.Stretch });
                    GridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ime", Width = 75, Resizable = DataGridViewTriState.False });
                    GridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Napomena", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, Resizable = DataGridViewTriState.False });
                    if (SelectedTab == Tabs.SviSastojci)
                        _focused = DBaccess.AllSastojci;
                    else
                        _focused = DBaccess.MySastojcis;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(); //TODO: Handle
            }
            Populate();
        }

        private void Populate()
        {
            if (_focused is null)
                return;
            switch (SelectedTab)
            {
                case Tabs.MojiKokteli:
                    var obj = (Dictionary<Koktel, List<Sastojci>>)_focused;
                    foreach (var item in obj)
                    {
                        GridView.Rows.Add(new object[] { item.Key.Slika.GetThumbnailImage(40, 40, null, IntPtr.Zero), item.Key.Ime, item.Key.Opis });
                    }
                    break;
                case Tabs.SviKokteli:
                    var ob = (List<Koktel>)_focused;
                    foreach (var item in ob)
                    {
                        GridView.Rows.Add(new object[] { item.Slika.GetThumbnailImage(40, 40, null, IntPtr.Zero), item.Ime, item.Opis });
                    }
                    break;
                case Tabs.SviSastojci:
                case Tabs.MojiSastojci:
                    var o = (List<Sastojci>)_focused;
                    foreach (var item in o)
                    {
                        GridView.Rows.Add(new object[] { item.Slika.GetThumbnailImage(40, 40, null, IntPtr.Zero), item.Ime, item.Napomena});
                    }
                    break;
            }
            if (SelectedTab == Tabs.SviSastojci)
            {
                for (int i=0;i<trackList.Length;i++)
                {
                    if (trackList[i])
                        GridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var s = (PictureBox)sender;
            /* using (Font myFont = new Font("Arial", 12,FontStyle.Bold)) -> Why bother kek
             {
                 e.Graphics.DrawString("Kuhano vino", myFont, Brushes.White, new Point((int)(s.Width/2 - e.Graphics.MeasureString("Kuhano vino", myFont).Width/2), s.Height - 25));
             }*/
            //^ To simple for me kek
            //Not how I roll 
            var gp = new GraphicsPath();
            //They see me rolli'n....
            Font myFont = new Font("Arial", 12, FontStyle.Bold);
            //I'm rolling smoothly 
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //https://goo.gl/DBvmfy
            gp.AddString("Kuhano vino", FontFamily.GenericSansSerif, (int)FontStyle.Bold, 18, new Point((int)(s.Width / 2 - e.Graphics.MeasureString("Kuhano vino", myFont).Width / 2) +15, s.Height - 25), null);
            e.Graphics.DrawPath(Pens.Black, gp);
            e.Graphics.FillPath(Brushes.White, gp);
            //You hatti'n nigga?
            //https://www.youtube.com/watch?v=N9qYF9DZPdw

        }

        private void OnSelection(object sender, EventArgs e)
        {
            var s = (MetroGrid)sender;
            //var sp = 
            switch (SelectedTab)
            {
                case Tabs.MojiKokteli:
                    break;
                case Tabs.SviKokteli:
                    break;
                case Tabs.MojiSastojci:
                    break;
                case Tabs.SviSastojci:
                    break;
            }
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SelectedTab == Tabs.SviSastojci)
                {
                    if (GridView.SelectedRows.Count == 0)
                        return;
                    var enm = GridView.SelectedRows.GetEnumerator();
                    while (enm.MoveNext())
                    {
                        var temp = DBaccess.AllSastojci.FirstOrDefault(x => ((DataGridViewRow)(enm.Current)).Cells[1].Value.Equals(x.Ime));
                        if (temp is null)
                            throw new Exception("Fuck me"); //Should not happen
                        DBaccess.MySastojcis.Add(temp);
                        ((DataGridViewRow)(enm.Current)).DefaultCellStyle.BackColor = Color.LightGreen;
                        trackList[((DataGridViewRow)(enm.Current)).Index] = true;
                    }
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (SelectedTab == Tabs.SviSastojci)
                {
                    if (GridView.SelectedRows.Count == 0)
                        return;
                    var enm = GridView.SelectedRows.GetEnumerator();
                    while (enm.MoveNext())
                    {
                        var temp = DBaccess.AllSastojci.FirstOrDefault(x => ((DataGridViewRow)(enm.Current)).Cells[1].Value.Equals(x.Ime));
                        if (temp is null)
                            throw new Exception("Fuck me"); //Should not happen
                        try
                        {
                            DBaccess.MySastojcis.RemoveAt(DBaccess.MySastojcis.IndexOf(DBaccess.MySastojcis.First(x => x.Id == temp.Id))); //Remove won't fucking work....
                        }
                        catch (InvalidOperationException)
                        {
                            MessageBox.Show("Item nije dodan u listu");
                        }
                        catch (Exception ex)
                        {

                        }
                        
                        ((DataGridViewRow)(enm.Current)).DefaultCellStyle.BackColor = Color.White; //TODO: FIX according to style
                        trackList[((DataGridViewRow)(enm.Current)).Index] = false;
                    }
                }
                else if (SelectedTab == Tabs.MojiSastojci)
                {
                    foreach (DataGridViewRow row in GridView.SelectedRows)
                    {
                        var a = DBaccess.AllSastojci.First(x => x.Ime.Equals(row.Cells[1].Value));
                        int i = 0;
                        for (i = 0; i < DBaccess.AllSastojci.Count; i++) //IndexOf won't fucking work....
                            if (DBaccess.AllSastojci[i].Id == a.Id)
                                break;
                        trackList[i] = false;
                        DBaccess.MySastojcis.Remove(DBaccess.MySastojcis.FirstOrDefault(x => x.Ime.Equals(row.Cells[1].Value)));
                        GridView.Rows.Remove(row);
                    }
                }
            }
        }
    }
}