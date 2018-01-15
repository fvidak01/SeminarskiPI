using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace SemniarPI

{
    public partial class MainForm : MetroForm
    {
        public string SearchQuery;
        private static MainForm _me;
        private Koktel _s; //TODO: Delete
        public enum Tabs
        {
            MojiKokteli = 1,
            SviKokteli = 0,
            MojiSastojci = 3,
            SviSastojci = 2
        }

        private static Tabs _selectedTab;

        public string SelectedFiled => SearchFieldSelectorCB.Items[SearchFieldSelectorCB.SelectedIndex].ToString(); //Why the fuck this won't work?
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
                    GridView.Columns.Add(new DataGridViewImageColumn { HeaderText = "", Width = 35,Resizable = DataGridViewTriState.False, ImageLayout = DataGridViewImageCellLayout.Stretch });
                    GridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ime", Width = 75, Resizable = DataGridViewTriState.False });
                    GridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Opis", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, Resizable = DataGridViewTriState.False });
                    if (SelectedTab == Tabs.MojiKokteli)
                        Populate(DBaccess.MyKoktels);
                    else
                        Populate(DBaccess.AllKoktels);
                    break;
                case Tabs.MojiSastojci:
                case Tabs.SviSastojci:
                    SearchFieldSelectorCB.Items.Clear();
                    SearchFieldSelectorCB.Items.AddRange(new object[] { "Ime", "Napomena" });
                    SearchFieldSelectorCB.SelectedIndex = 0;
                    GridView.Columns.Clear();
                    GridView.Columns.Add(new DataGridViewImageColumn { HeaderText = "", Width = 35, Resizable = DataGridViewTriState.False, ImageLayout = DataGridViewImageCellLayout.Stretch });
                    GridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ime", Width = 75, Resizable = DataGridViewTriState.False });
                    GridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Napomena", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, Resizable = DataGridViewTriState.False });
                    if (SelectedTab == Tabs.MojiSastojci)
                        Populate(DBaccess.MySastojcis);
                    else
                        Populate(DBaccess.AllSastojci);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(); //TODO: Handle
            }
            /* private void metroLabel1_MouseHover(object sender, EventArgs e)
             {
                 var s = (MetroLabel)sender;
                 s.BackColor = Color.DarkSlateBlue;
             }*/
        }

        private void Populate(object list)
        {
            if (list is null)
                return;
            switch (SelectedTab)
            {
                case Tabs.MojiKokteli:
                    var obj = (Dictionary<Koktel, List<Sastojci>>)list;
                    foreach (var item in obj)
                    {
                        GridView.Rows.Add(new object[] { item.Key.Slika.GetThumbnailImage(40, 40, null, IntPtr.Zero), item.Key.Ime, item.Key.Opis });
                    }
                    break;
                case Tabs.SviKokteli:
                    var ob = (List<Koktel>)list;
                    foreach (var item in ob)
                    {
                        GridView.Rows.Add(new object[] { item.Slika.GetThumbnailImage(40, 40, null, IntPtr.Zero), item.Ime, item.Opis });
                    }
                    break;
                case Tabs.SviSastojci:
                case Tabs.MojiSastojci:
                    var o = (List<Sastojci>)list;
                    foreach (var item in o)
                    {
                        GridView.Rows.Add(new object[] { item.Slika.GetThumbnailImage(40, 40, null, IntPtr.Zero), item.Ime, item.Napomena});
                    }
                    break;
            }
        }
    }
}