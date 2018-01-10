using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;

namespace SemniarPI

{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public string SearchQuery;
        private static MainForm me;
        private Koktel s; //TODO: Delete

        public enum Tabs
        {
            MojiKokteli = 1,
            SviKokteli = 0,
            MojiSastojci = 3,
            SviSastojci = 2
        };

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
            if (me is null)
            {
                me = new MainForm();
            }
            return me;
        }
        private void Form1_Load(object sender, EventArgs e)
        { //Code below is for testing purposes and will be removed TODO: Remove, duuh
            SearchFieldSelectorCB.SelectedIndex = 0;
            DBaccess.DBconnect(new FileInfo("PIdb.db"));
            var list = DBaccess.SelectAll(DBaccess.Table.Kokteli);
            var koktel = Koktel.CreateKoktailList(list);
            var sastojci = new List<object[]>
            {
                new object[] {(long) 1, null, null, null},
                new object[] {(long) 2, null, null, null},
                new object[] {(long) 3, null, null, null},
                new object[] {(long) 4, null, null, null},
                new object[] {(long) 5, null, null, null},
                new object[] {(long) 6, null, null, null},
                new object[] {(long) 7, null, null, null},
            };
            var sas = Sastojci.CreateSastojciList(sastojci);
            var li = DBaccess.GetMyKoktels(sas);
            var pairs = DBaccess.GetMissingSastojciForKoktelList(li, sas);
            this.metroListView1.Columns.Add("Ime");
            this.metroListView1.Columns.Add("Opis");
            this.metroListView1.View = View.List;
            foreach (var sa in pairs)
            {
                this.metroListView1.Items.Add(sa.Key.Ime, sa.Key.Opis);
            }
            s = koktel[0];
            var tb = li[0].Slika.GetThumbnailImage(80, 80, null, IntPtr.Zero);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var b = (PictureBox)sender;
            b.Image = s.Slika;
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
            this.metroContextMenu1.Show(ptLowerLeft);

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
                    break;
                case Tabs.MojiSastojci:
                case Tabs.SviSastojci:
                    SearchFieldSelectorCB.Items.Clear();
                    SearchFieldSelectorCB.Items.AddRange(new object[] { "Ime", "Napomena" });
                    SearchFieldSelectorCB.SelectedIndex = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(); //TODO: Handle
            }
        }

        /* private void metroLabel1_MouseHover(object sender, EventArgs e)
         {
             var s = (MetroLabel)sender;
             s.BackColor = Color.DarkSlateBlue;
         }*/
    }
}
