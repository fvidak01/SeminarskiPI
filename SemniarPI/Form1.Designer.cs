using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Controls;

namespace SemniarPI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TabsTC = new MetroFramework.Controls.MetroTabControl();
            this.SviKokteli = new MetroFramework.Controls.MetroTabPage();
            this.MojiKokteli = new MetroFramework.Controls.MetroTabPage();
            this.SviSastojci = new MetroFramework.Controls.MetroTabPage();
            this.MojiSastojci = new MetroFramework.Controls.MetroTabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroListView1 = new MetroFramework.Controls.MetroListView();
            this.SearchboxTB = new MetroFramework.Controls.MetroTextBox();
            this.SearchFieldSelectorCB = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchingPB = new System.Windows.Forms.PictureBox();
            this.TabsTC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.metroContextMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchingPB)).BeginInit();
            this.SuspendLayout();
            // 
            // TabsTC
            // 
            this.TabsTC.Controls.Add(this.MojiKokteli);
            this.TabsTC.Controls.Add(this.SviKokteli);
            this.TabsTC.Controls.Add(this.SviSastojci);
            this.TabsTC.Controls.Add(this.MojiSastojci);
            this.TabsTC.Location = new System.Drawing.Point(244, 117);
            this.TabsTC.Name = "TabsTC";
            this.TabsTC.SelectedIndex = 1;
            this.TabsTC.Size = new System.Drawing.Size(309, 48);
            this.TabsTC.Style = MetroFramework.MetroColorStyle.White;
            this.TabsTC.TabIndex = 0;
            this.TabsTC.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TabsTC.UseSelectable = true;
            this.TabsTC.UseStyleColors = true;
            this.TabsTC.SelectedIndexChanged += new System.EventHandler(this.TabSelectionChanged);
            // 
            // SviKokteli
            // 
            this.SviKokteli.HorizontalScrollbarBarColor = true;
            this.SviKokteli.HorizontalScrollbarHighlightOnWheel = false;
            this.SviKokteli.HorizontalScrollbarSize = 10;
            this.SviKokteli.Location = new System.Drawing.Point(4, 38);
            this.SviKokteli.Name = "SviKokteli";
            this.SviKokteli.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SviKokteli.Size = new System.Drawing.Size(301, 6);
            this.SviKokteli.TabIndex = 0;
            this.SviKokteli.Text = "Svi kokteli";
            this.SviKokteli.VerticalScrollbarBarColor = true;
            this.SviKokteli.VerticalScrollbarHighlightOnWheel = false;
            this.SviKokteli.VerticalScrollbarSize = 10;
            // 
            // MojiKokteli
            // 
            this.MojiKokteli.HorizontalScrollbarBarColor = true;
            this.MojiKokteli.HorizontalScrollbarHighlightOnWheel = false;
            this.MojiKokteli.HorizontalScrollbarSize = 10;
            this.MojiKokteli.Location = new System.Drawing.Point(4, 38);
            this.MojiKokteli.Name = "MojiKokteli";
            this.MojiKokteli.Size = new System.Drawing.Size(301, 6);
            this.MojiKokteli.TabIndex = 1;
            this.MojiKokteli.Text = "Moji Kokteli";
            this.MojiKokteli.VerticalScrollbarBarColor = true;
            this.MojiKokteli.VerticalScrollbarHighlightOnWheel = false;
            this.MojiKokteli.VerticalScrollbarSize = 10;
            // 
            // SviSastojci
            // 
            this.SviSastojci.HorizontalScrollbarBarColor = true;
            this.SviSastojci.HorizontalScrollbarHighlightOnWheel = false;
            this.SviSastojci.HorizontalScrollbarSize = 10;
            this.SviSastojci.Location = new System.Drawing.Point(4, 38);
            this.SviSastojci.Name = "SviSastojci";
            this.SviSastojci.Size = new System.Drawing.Size(301, 6);
            this.SviSastojci.TabIndex = 2;
            this.SviSastojci.Text = "Svi sastojci";
            this.SviSastojci.VerticalScrollbarBarColor = true;
            this.SviSastojci.VerticalScrollbarHighlightOnWheel = false;
            this.SviSastojci.VerticalScrollbarSize = 10;
            // 
            // MojiSastojci
            // 
            this.MojiSastojci.HorizontalScrollbarBarColor = true;
            this.MojiSastojci.HorizontalScrollbarHighlightOnWheel = false;
            this.MojiSastojci.HorizontalScrollbarSize = 10;
            this.MojiSastojci.Location = new System.Drawing.Point(4, 38);
            this.MojiSastojci.Name = "MojiSastojci";
            this.MojiSastojci.Size = new System.Drawing.Size(301, 6);
            this.MojiSastojci.TabIndex = 3;
            this.MojiSastojci.Text = "Moji sastojci";
            this.MojiSastojci.UseStyleColors = true;
            this.MojiSastojci.VerticalScrollbarBarColor = true;
            this.MojiSastojci.VerticalScrollbarHighlightOnWheel = false;
            this.MojiSastojci.VerticalScrollbarSize = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(447, 183);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(52, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(75, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Settings";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseStyleColors = true;
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(488, 390);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(122, 80);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "1) Prokuhajte vino \r\n2) Dodajte cimet\r\n3) ....\r\n";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(488, 357);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(111, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Kuhano vino";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseStyleColors = true;
            // 
            // metroListView1
            // 
            this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView1.FullRowSelect = true;
            this.metroListView1.Location = new System.Drawing.Point(154, 183);
            this.metroListView1.Name = "metroListView1";
            this.metroListView1.OwnerDraw = true;
            this.metroListView1.Size = new System.Drawing.Size(233, 171);
            this.metroListView1.TabIndex = 6;
            this.metroListView1.UseCompatibleStateImageBehavior = false;
            this.metroListView1.UseSelectable = true;
            this.metroListView1.View = System.Windows.Forms.View.Details;
            // 
            // SearchboxTB
            // 
            // 
            // 
            // 
            this.SearchboxTB.CustomButton.Image = null;
            this.SearchboxTB.CustomButton.Location = new System.Drawing.Point(139, 1);
            this.SearchboxTB.CustomButton.Name = "";
            this.SearchboxTB.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SearchboxTB.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SearchboxTB.CustomButton.TabIndex = 1;
            this.SearchboxTB.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SearchboxTB.CustomButton.UseSelectable = true;
            this.SearchboxTB.CustomButton.Visible = false;
            this.SearchboxTB.Lines = new string[] {
        "Search"};
            this.SearchboxTB.Location = new System.Drawing.Point(197, 374);
            this.SearchboxTB.MaxLength = 32767;
            this.SearchboxTB.Name = "SearchboxTB";
            this.SearchboxTB.PasswordChar = '\0';
            this.SearchboxTB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SearchboxTB.SelectedText = "";
            this.SearchboxTB.SelectionLength = 0;
            this.SearchboxTB.SelectionStart = 0;
            this.SearchboxTB.ShortcutsEnabled = true;
            this.SearchboxTB.Size = new System.Drawing.Size(161, 23);
            this.SearchboxTB.Style = MetroFramework.MetroColorStyle.White;
            this.SearchboxTB.TabIndex = 7;
            this.SearchboxTB.Text = "Search";
            this.SearchboxTB.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SearchboxTB.UseSelectable = true;
            this.SearchboxTB.UseStyleColors = true;
            this.SearchboxTB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SearchboxTB.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.SearchboxTB.TextChanged += new System.EventHandler(this.OnSearchTextChanged);
            // 
            // SearchFieldSelectorCB
            // 
            this.SearchFieldSelectorCB.FormattingEnabled = true;
            this.SearchFieldSelectorCB.ItemHeight = 24;
            this.SearchFieldSelectorCB.Items.AddRange(new object[] {
            "Ime",
            "Opis",
            "Upute"});
            this.SearchFieldSelectorCB.Location = new System.Drawing.Point(197, 413);
            this.SearchFieldSelectorCB.Name = "SearchFieldSelectorCB";
            this.SearchFieldSelectorCB.Size = new System.Drawing.Size(161, 30);
            this.SearchFieldSelectorCB.Style = MetroFramework.MetroColorStyle.White;
            this.SearchFieldSelectorCB.TabIndex = 8;
            this.SearchFieldSelectorCB.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SearchFieldSelectorCB.UseSelectable = true;
            this.SearchFieldSelectorCB.UseStyleColors = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.ContextMenuStrip = this.metroContextMenu1;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(154, 60);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(87, 25);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "User data";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel4.UseCustomBackColor = true;
            this.metroLabel4.UseStyleColors = true;
            this.metroLabel4.Click += new System.EventHandler(this.metroLabel4_Click);
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.metroContextMenu1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.metroContextMenu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(112, 52);
            this.metroContextMenu1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroContextMenu1.UseStyleColors = true;
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // SearchingPB
            // 
            this.SearchingPB.ErrorImage = global::SemniarPI.Properties.Resources.searching;
            this.SearchingPB.Image = global::SemniarPI.Properties.Resources.searching;
            this.SearchingPB.Location = new System.Drawing.Point(364, 374);
            this.SearchingPB.Name = "SearchingPB";
            this.SearchingPB.Size = new System.Drawing.Size(23, 23);
            this.SearchingPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.SearchingPB.TabIndex = 10;
            this.SearchingPB.TabStop = false;
            this.SearchingPB.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 504);
            this.Controls.Add(this.SearchingPB);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.SearchFieldSelectorCB);
            this.Controls.Add(this.SearchboxTB);
            this.Controls.Add(this.metroListView1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TabsTC);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "CoMa";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabsTC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.metroContextMenu1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SearchingPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroTabControl TabsTC;
        private MetroTabPage SviKokteli;
        private MetroTabPage MojiKokteli;
        private MetroTabPage SviSastojci;
        private MetroTabPage MojiSastojci;
        private PictureBox pictureBox1;
        private MetroStyleManager metroStyleManager1;
        private MetroLabel metroLabel1;
        private MetroLabel metroLabel3;
        private MetroLabel metroLabel2;
        private MetroComboBox SearchFieldSelectorCB;
        private MetroTextBox SearchboxTB;
        private MetroListView metroListView1;
        private MetroLabel metroLabel4;
        private MetroContextMenu metroContextMenu1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        public PictureBox SearchingPB;
    }
}

