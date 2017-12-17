using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MetroFramework;
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
            var sastojci = new List<object[]>();
            sastojci.Add(new object[] { (long)1, null, null, null });
            sastojci.Add(new object[] { (long)2, null, null, null });
            sastojci.Add(new object[] { (long)3, null, null, null });
            sastojci.Add(new object[] { (long)4, null, null, null });
            sastojci.Add(new object[] { (long)5, null, null, null });
            sastojci.Add(new object[] { (long)6, null, null, null });
            sastojci.Add(new object[] { (long)7, null, null, null });
            var sas = SemniarPI.Sastojci.CreateSastojciList(sastojci);
            var li = DBaccess.GetMyKoktels(sas);
            s = koktel[0];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var b = (PictureBox)sender;
            b.Image = s.Slika;
        }
    }
}
