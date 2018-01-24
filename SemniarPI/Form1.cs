using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using MetroFramework;
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
//            SetStyleManager();
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
            GridView.RowTemplate.Height = 40;
            if (!File.Exists("PIdb.db") || !DBaccess.DBconnect(new FileInfo("PIdb.db")))
                DBconDB();
            trackList = new bool[DBaccess.AllSastojci.Count];
            TabSelectionChanged(TabsTC, null);
            var st = new DataGridViewCellStyle()
            {
                WrapMode = DataGridViewTriState.True,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(2, 5, 2, 5)
            };
            GridView.DefaultCellStyle = st;
            //this.ImeLB.BackColor = Color.Transparent;
        }

        private void DBconDB()
        {
            if (MessageBox.Show(null, "Spajanje na bazu nije mouće!\nBaza nije pronađena!\nImate li svoju bazu?",
                    "Greška s bazom", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (!DBaccess.DBconnect(FindFile()))
                    DBconDB();
                return;
            }
            if (MessageBox.Show(null, "Želite li skinuti default bazu?",
                    "Greška s bazom", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!DBaccess.DBconnect(DownloadFile()))
                {
                    MessageBox.Show(null, "Neočekivana greška!",
                        "Well fuck", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    return;
                }

            }
            Application.Exit();
        }

        private FileInfo DownloadFile()
        {
            var wc = new WebClient();
            wc.DownloadFile("https://github.com/n00ne1mportant/PublicFilesRepo/blob/master/PIdb.db?raw=true", "PI.db");
            return new FileInfo("PI.db");
        }

        private FileInfo FindFile()
        {
            var fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.Filter = "Database Files (*.db)|*.db|All files (*.*)|*.*";
            return fd.ShowDialog() == DialogResult.OK ? new FileInfo(fd.FileName) : null;
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {
            var settings = new SettingsForm();
            this.StyleManager = SettingsObject.GetSettings().StyleManager;
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
            var txt = GridView.SelectedRows[0].Cells[1].Value.ToString();
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
            //https://ci.memecdn.com/8799486.jpg
            gp.AddString(txt, FontFamily.GenericSansSerif, (int)FontStyle.Bold, 18, new Point((int)(s.Width / 2 - e.Graphics.MeasureString("Kuhano vino", myFont).Width / 2) +15, s.Height - 25), null);
            e.Graphics.DrawPath(Pens.Black, gp);
            e.Graphics.FillPath(Brushes.White, gp);
            //You hatti'n nigga?
            //https://www.youtube.com/watch?v=N9qYF9DZPdw

        }

        private void OnSelection(object sender, EventArgs e)
        {
            var s = (MetroGrid)sender;
            //var sp = 
            if (s.SelectedRows.Count > 1)
                return;
            if (s.SelectedRows.Count < 1)
                return;
            switch (SelectedTab)
            {
                case Tabs.MojiKokteli:
                case Tabs.SviKokteli:
                    NedSasLB.ForeColor = Color.Red;
                    var obj = DBaccess.BindRowToItem(s.SelectedRows[0], Tabs.SviKokteli, pairs:true, link:SelectedTab == Tabs.MojiKokteli);
                    sastojciLB.Text = "";
                    NedSasLB.Text = "";
                    var o = (KeyValuePair<Koktel, List<Sastojci>>)obj;
                    o.Value.ForEach(x => sastojciLB.Text += x.Ime.ToString() + ", ");
                    sastojciLB.Text = sastojciLB.Text.Remove(sastojciLB.Text.Length - 2);
                    var op = DBaccess.BindRowToItem(s.SelectedRows[0], Tabs.MojiKokteli);
                    pictureBox1.Image = o.Key.Slika;
                    if (op is null)
                    {
                        NedSasLB.Text = sastojciLB.Text.Replace("Sastojci:", "").TrimStart();
                        return;
                    }
                    ((KeyValuePair<Koktel,List<Sastojci>>)op).Value.ForEach(x => NedSasLB.Text += x.Ime + ", ");
                    if (((KeyValuePair<Koktel, List<Sastojci>>)op).Value.Count == 0)
                    {
                        NedSasLB.Text = "Imate sve!  ";
                        NedSasLB.ForeColor = Color.LightGreen;
                    }
                    NedSasLB.Text = NedSasLB.Text.Remove(NedSasLB.Text.Length - 2);
                    sviSastTXTLB.Show();
                    NedostajeLB.Show();
                    break;
                case Tabs.MojiSastojci:
                case Tabs.SviSastojci:
                    var sas = (Sastojci)DBaccess.BindRowToItem(s.SelectedRows[0], SelectedTab);
                    pictureBox1.Image = sas.Slika;
                    NedSasLB.Text = "";
                    sastojciLB.Text = "";
                    sviSastTXTLB.Hide();
                    NedostajeLB.Hide();
                    break;
            }
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
                        var temp =(Sastojci) DBaccess.BindRowToItem(((DataGridViewRow)(enm.Current)), SelectedTab);
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
                        var temp = (Sastojci)DBaccess.BindRowToItem(((DataGridViewRow)(enm.Current)), SelectedTab);
                        if (temp is null)
                            throw new Exception("Fuck me"); //Should not happen
                        try
                        {
                            DBaccess.MySastojcis.Remove(DBaccess.MySastojcis.First(x => x.Id == temp.Id)); //Remove() not working, THIS is a fix
                        }
                        catch (InvalidOperationException)
                        {
                            MessageBox.Show("Item nije dodan u listu");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: Ex: " + ex.Message + "Inner: "+ex.InnerException?.Message);
                        }
                        
                        ((DataGridViewRow)(enm.Current)).DefaultCellStyle.BackColor = Color.White; //TODO: FIX according to style
                        trackList[((DataGridViewRow)(enm.Current)).Index] = false;
                    }
                }
                else if (SelectedTab == Tabs.MojiSastojci)
                {
                    foreach (DataGridViewRow row in GridView.SelectedRows)
                    {
                        int i;
                        var a = (Sastojci)DBaccess.BindRowToItem(row, SelectedTab);
                        //Fuck index of, stup PoS
                        for (i = 0; i < DBaccess.AllSastojci.Count; i++)
                            if (DBaccess.AllSastojci[i].Id == a.Id)
                                break;
                        trackList[i] = false;
                        DBaccess.MySastojcis.Remove(((Sastojci)DBaccess.BindRowToItem(row,SelectedTab)));
                        GridView.Rows.Remove(row);
                    }
                }
            }
        }

        private void OnDoubleClick(object sender, EventArgs e) //Same as ENTER keypress, shall forward the call
        {
            OnKeyDown(sender, new KeyEventArgs(Keys.Enter));
        }
    }
}