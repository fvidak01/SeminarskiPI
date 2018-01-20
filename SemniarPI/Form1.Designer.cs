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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabsTC = new MetroFramework.Controls.MetroTabControl();
            this.MojiKokteli = new MetroFramework.Controls.MetroTabPage();
            this.SviKokteli = new MetroFramework.Controls.MetroTabPage();
            this.MojiSastojci = new MetroFramework.Controls.MetroTabPage();
            this.SviSastojci = new MetroFramework.Controls.MetroTabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SearchboxTB = new MetroFramework.Controls.MetroTextBox();
            this.SearchFieldSelectorCB = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchingPB = new System.Windows.Forms.PictureBox();
            this.GridView = new MetroFramework.Controls.MetroGrid();
            this.koktelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TabsTC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.metroContextMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchingPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.koktelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TabsTC
            // 
            this.TabsTC.Controls.Add(this.MojiKokteli);
            this.TabsTC.Controls.Add(this.SviKokteli);
            this.TabsTC.Controls.Add(this.MojiSastojci);
            this.TabsTC.Controls.Add(this.SviSastojci);
            this.TabsTC.Location = new System.Drawing.Point(197, 123);
            this.TabsTC.Name = "TabsTC";
            this.TabsTC.SelectedIndex = 1;
            this.TabsTC.Size = new System.Drawing.Size(489, 42);
            this.TabsTC.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabsTC.Style = MetroFramework.MetroColorStyle.White;
            this.TabsTC.TabIndex = 0;
            this.TabsTC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TabsTC.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TabsTC.UseSelectable = true;
            this.TabsTC.UseStyleColors = true;
            this.TabsTC.SelectedIndexChanged += new System.EventHandler(this.TabSelectionChanged);
            // 
            // MojiKokteli
            // 
            this.MojiKokteli.AutoScroll = true;
            this.MojiKokteli.HorizontalScrollbar = true;
            this.MojiKokteli.HorizontalScrollbarBarColor = true;
            this.MojiKokteli.HorizontalScrollbarHighlightOnWheel = false;
            this.MojiKokteli.HorizontalScrollbarSize = 10;
            this.MojiKokteli.Location = new System.Drawing.Point(4, 38);
            this.MojiKokteli.Name = "MojiKokteli";
            this.MojiKokteli.Size = new System.Drawing.Size(481, 0);
            this.MojiKokteli.TabIndex = 1;
            this.MojiKokteli.Text = "Moji Kokteli";
            this.MojiKokteli.VerticalScrollbar = true;
            this.MojiKokteli.VerticalScrollbarBarColor = true;
            this.MojiKokteli.VerticalScrollbarHighlightOnWheel = false;
            this.MojiKokteli.VerticalScrollbarSize = 10;
            // 
            // SviKokteli
            // 
            this.SviKokteli.AutoScroll = true;
            this.SviKokteli.HorizontalScrollbar = true;
            this.SviKokteli.HorizontalScrollbarBarColor = true;
            this.SviKokteli.HorizontalScrollbarHighlightOnWheel = false;
            this.SviKokteli.HorizontalScrollbarSize = 10;
            this.SviKokteli.Location = new System.Drawing.Point(4, 38);
            this.SviKokteli.Name = "SviKokteli";
            this.SviKokteli.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SviKokteli.Size = new System.Drawing.Size(481, 0);
            this.SviKokteli.TabIndex = 0;
            this.SviKokteli.Text = "Svi kokteli";
            this.SviKokteli.VerticalScrollbar = true;
            this.SviKokteli.VerticalScrollbarBarColor = true;
            this.SviKokteli.VerticalScrollbarHighlightOnWheel = false;
            this.SviKokteli.VerticalScrollbarSize = 10;
            // 
            // MojiSastojci
            // 
            this.MojiSastojci.AutoScroll = true;
            this.MojiSastojci.HorizontalScrollbar = true;
            this.MojiSastojci.HorizontalScrollbarBarColor = true;
            this.MojiSastojci.HorizontalScrollbarHighlightOnWheel = false;
            this.MojiSastojci.HorizontalScrollbarSize = 10;
            this.MojiSastojci.Location = new System.Drawing.Point(4, 38);
            this.MojiSastojci.Name = "MojiSastojci";
            this.MojiSastojci.Size = new System.Drawing.Size(481, 0);
            this.MojiSastojci.TabIndex = 3;
            this.MojiSastojci.Text = "Moji sastojci";
            this.MojiSastojci.UseStyleColors = true;
            this.MojiSastojci.VerticalScrollbar = true;
            this.MojiSastojci.VerticalScrollbarBarColor = true;
            this.MojiSastojci.VerticalScrollbarHighlightOnWheel = false;
            this.MojiSastojci.VerticalScrollbarSize = 10;
            // 
            // SviSastojci
            // 
            this.SviSastojci.AutoScroll = true;
            this.SviSastojci.HorizontalScrollbar = true;
            this.SviSastojci.HorizontalScrollbarBarColor = true;
            this.SviSastojci.HorizontalScrollbarHighlightOnWheel = false;
            this.SviSastojci.HorizontalScrollbarSize = 10;
            this.SviSastojci.Location = new System.Drawing.Point(4, 38);
            this.SviSastojci.Name = "SviSastojci";
            this.SviSastojci.Size = new System.Drawing.Size(481, 0);
            this.SviSastojci.TabIndex = 2;
            this.SviSastojci.Text = "Svi sastojci";
            this.SviSastojci.VerticalScrollbar = true;
            this.SviSastojci.VerticalScrollbarBarColor = true;
            this.SviSastojci.VerticalScrollbarHighlightOnWheel = false;
            this.SviSastojci.VerticalScrollbarSize = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(518, 171);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 259);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
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
            this.metroLabel2.Location = new System.Drawing.Point(592, 473);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(122, 80);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "1) Prokuhajte vino \r\n2) Dodajte cimet\r\n3) ....\r\n";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseStyleColors = true;
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
            this.SearchboxTB.Location = new System.Drawing.Point(197, 447);
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
            this.SearchFieldSelectorCB.Location = new System.Drawing.Point(197, 486);
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
            this.SearchingPB.Location = new System.Drawing.Point(376, 447);
            this.SearchingPB.Name = "SearchingPB";
            this.SearchingPB.Size = new System.Drawing.Size(23, 23);
            this.SearchingPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.SearchingPB.TabIndex = 10;
            this.SearchingPB.TabStop = false;
            this.SearchingPB.Visible = false;
            // 
            // GridView
            // 
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.AllowUserToOrderColumns = true;
            this.GridView.AllowUserToResizeRows = false;
            this.GridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.GridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GridView.EnableHeadersVisualStyles = false;
            this.GridView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.GridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.GridView.Location = new System.Drawing.Point(154, 171);
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridView.RowTemplate.Height = 24;
            this.GridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.ShowRowErrors = false;
            this.GridView.Size = new System.Drawing.Size(342, 259);
            this.GridView.TabIndex = 11;
            this.GridView.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.GridView.UseStyleColors = true;
            this.GridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
            this.GridView.SelectionChanged += new System.EventHandler(this.OnSelection);
            this.GridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // koktelBindingSource
            // 
            this.koktelBindingSource.DataSource = typeof(SemniarPI.Koktel);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 637);
            this.Controls.Add(this.GridView);
            this.Controls.Add(this.SearchingPB);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.SearchFieldSelectorCB);
            this.Controls.Add(this.SearchboxTB);
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
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.koktelBindingSource)).EndInit();
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
        private MetroLabel metroLabel2;
        private MetroComboBox SearchFieldSelectorCB;
        private MetroTextBox SearchboxTB;
        private MetroLabel metroLabel4;
        private MetroContextMenu metroContextMenu1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        public PictureBox SearchingPB;
        private MetroGrid GridView;
        private BindingSource koktelBindingSource;
    }
}

