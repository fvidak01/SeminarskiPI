namespace SemniarPI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.SviKokteli = new MetroFramework.Controls.MetroTabPage();
            this.MojiKokteli = new MetroFramework.Controls.MetroTabPage();
            this.SviSastojci = new MetroFramework.Controls.MetroTabPage();
            this.MojiSastojci = new MetroFramework.Controls.MetroTabPage();
            this.metroTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.SviKokteli);
            this.metroTabControl1.Controls.Add(this.MojiKokteli);
            this.metroTabControl1.Controls.Add(this.SviSastojci);
            this.metroTabControl1.Controls.Add(this.MojiSastojci);
            this.metroTabControl1.Location = new System.Drawing.Point(111, 114);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(419, 48);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl1.UseSelectable = true;
            this.metroTabControl1.UseStyleColors = true;
            // 
            // SviKokteli
            // 
            this.SviKokteli.HorizontalScrollbarBarColor = true;
            this.SviKokteli.HorizontalScrollbarHighlightOnWheel = false;
            this.SviKokteli.HorizontalScrollbarSize = 10;
            this.SviKokteli.Location = new System.Drawing.Point(4, 38);
            this.SviKokteli.Name = "SviKokteli";
            this.SviKokteli.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SviKokteli.Size = new System.Drawing.Size(371, 12);
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
            this.MojiKokteli.Size = new System.Drawing.Size(411, 6);
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
            this.SviSastojci.Size = new System.Drawing.Size(307, 12);
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
            this.MojiSastojci.Size = new System.Drawing.Size(307, 12);
            this.MojiSastojci.TabIndex = 3;
            this.MojiSastojci.Text = "Moji sastojci";
            this.MojiSastojci.UseStyleColors = true;
            this.MojiSastojci.VerticalScrollbarBarColor = true;
            this.MojiSastojci.VerticalScrollbarHighlightOnWheel = false;
            this.MojiSastojci.VerticalScrollbarSize = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 504);
            this.Controls.Add(this.metroTabControl1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "CoMa";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage SviKokteli;
        private MetroFramework.Controls.MetroTabPage MojiKokteli;
        private MetroFramework.Controls.MetroTabPage SviSastojci;
        private MetroFramework.Controls.MetroTabPage MojiSastojci;
    }
}

