using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;

namespace SemniarPI

{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private Koktel s;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { //Code below is for testing purposes and will be removed TODO: Remove, duuh
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

        /* private void metroLabel1_MouseHover(object sender, EventArgs e)
         {
             var s = (MetroLabel)sender;
             s.BackColor = Color.DarkSlateBlue;
         }*/
    }
}
