using System.ComponentModel;
using MetroFramework.Controls;

namespace SemniarPI
{
    partial class SettingsForm
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
            this.LBtheme = new MetroFramework.Controls.MetroLabel();
            this.LBstyle = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroComboBox2 = new MetroFramework.Controls.MetroComboBox();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox3 = new MetroFramework.Controls.MetroComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // LBtheme
            // 
            this.LBtheme.AutoSize = true;
            this.LBtheme.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.LBtheme.Location = new System.Drawing.Point(23, 108);
            this.LBtheme.Name = "LBtheme";
            this.LBtheme.Size = new System.Drawing.Size(134, 25);
            this.LBtheme.TabIndex = 0;
            this.LBtheme.Text = "Tema aplikacije:";
            this.LBtheme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBtheme.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.LBtheme.UseStyleColors = true;
            this.LBtheme.Click += new System.EventHandler(this.LBtheme_Click);
            // 
            // LBstyle
            // 
            this.LBstyle.AutoSize = true;
            this.LBstyle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.LBstyle.Location = new System.Drawing.Point(23, 166);
            this.LBstyle.Name = "LBstyle";
            this.LBstyle.Size = new System.Drawing.Size(115, 25);
            this.LBstyle.TabIndex = 1;
            this.LBstyle.Text = "Stil aplikacije:";
            this.LBstyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBstyle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.LBstyle.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(23, 229);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(132, 25);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Baza podataka:";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(82, 411);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "Učitaj";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(286, 411);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 4;
            this.metroButton2.Text = "Spremi";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.UseStyleColors = true;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 24;
            this.metroComboBox1.Items.AddRange(new object[] {
            "Svijetla",
            "Tamna"});
            this.metroComboBox1.Location = new System.Drawing.Point(286, 108);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(121, 30);
            this.metroComboBox1.TabIndex = 5;
            this.metroComboBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox1.UseSelectable = true;
            this.metroComboBox1.UseStyleColors = true;
            this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // metroComboBox2
            // 
            this.metroComboBox2.FormattingEnabled = true;
            this.metroComboBox2.ItemHeight = 24;
            this.metroComboBox2.Items.AddRange(new object[] {
            "Osnovna",
            "Crna",
            "Bijela",
            "Srebrena",
            "Plava",
            "Zelena",
            "Limeta",
            "Tirkizna",
            "Narančasta",
            "Smeđa",
            "Roza",
            "Megenta",
            "Ljubičasta",
            "Crvena",
            "Žuta"});
            this.metroComboBox2.Location = new System.Drawing.Point(286, 166);
            this.metroComboBox2.Name = "metroComboBox2";
            this.metroComboBox2.Size = new System.Drawing.Size(121, 30);
            this.metroComboBox2.TabIndex = 6;
            this.metroComboBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox2.UseSelectable = true;
            this.metroComboBox2.UseStyleColors = true;
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(332, 231);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(75, 23);
            this.metroButton3.TabIndex = 7;
            this.metroButton3.Text = "Pretraži";
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton3.UseSelectable = true;
            this.metroButton3.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(23, 282);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(237, 25);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "Broj sastojaka koji nedostaju:";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseStyleColors = true;
            // 
            // metroComboBox3
            // 
            this.metroComboBox3.FormattingEnabled = true;
            this.metroComboBox3.ItemHeight = 24;
            this.metroComboBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.metroComboBox3.Location = new System.Drawing.Point(286, 282);
            this.metroComboBox3.Name = "metroComboBox3";
            this.metroComboBox3.Size = new System.Drawing.Size(121, 30);
            this.metroComboBox3.TabIndex = 9;
            this.metroComboBox3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox3.UseSelectable = true;
            this.metroComboBox3.UseStyleColors = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(332, 334);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(23, 334);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(143, 25);
            this.metroLabel3.TabIndex = 11;
            this.metroLabel3.Text = "Uključiti zapisnik:";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseStyleColors = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 472);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.metroComboBox3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroComboBox2);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.LBstyle);
            this.Controls.Add(this.LBtheme);
            this.Name = "SettingsForm";
            this.Text = "Postavke";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroLabel LBtheme;
        private MetroLabel LBstyle;
        private MetroLabel metroLabel1;
        private MetroButton metroButton1;
        private MetroButton metroButton2;
        private MetroComboBox metroComboBox1;
        private MetroComboBox metroComboBox2;
        private MetroButton metroButton3;
        private MetroLabel metroLabel2;
        private MetroComboBox metroComboBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private MetroLabel metroLabel3;
    }
}