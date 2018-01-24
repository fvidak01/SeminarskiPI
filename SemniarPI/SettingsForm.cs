using System;
using MetroFramework;
using MetroFramework.Forms;

namespace SemniarPI
{
    public partial class SettingsForm : MetroForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            this.metroComboBox3.SelectedIndex = 0;
            this.metroComboBox1.SelectedIndex = 0;
            this.metroComboBox2.SelectedIndex = 0;
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void LBtheme_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            SettingsObject.GetSettings().Tolerance = this.metroComboBox3.SelectedIndex;
            switch (this.metroComboBox2.SelectedIndex)
            {
                case (int)SettingsObject.FormStyle.Blue:
                    SettingsObject.GetSettings().StyleManager.Style = MetroColorStyle.Blue;
                    break;
                case (int)SettingsObject.FormStyle.Teral:
                    SettingsObject.GetSettings().StyleManager.Style = MetroColorStyle.Teal;
                    break;
                case (int)SettingsObject.FormStyle.White:
                    SettingsObject.GetSettings().StyleManager.Style = MetroColorStyle.White;
                    break;
                case (int)SettingsObject.FormStyle.Green:
                    SettingsObject.GetSettings().StyleManager.Style = MetroColorStyle.Green;
                    break;
                case (int)SettingsObject.FormStyle.Red:
                    SettingsObject.GetSettings().StyleManager.Style = MetroColorStyle.Red;
                    break;
                    default:
                        SettingsObject.GetSettings().StyleManager.Style = MetroColorStyle.Teal;
                    break;
            }
            MainForm.GetInstance().CheckTheme(this.metroComboBox2.SelectedIndex);
            SettingsObject.GetSettings().StyleManager.Theme = this.metroComboBox1.SelectedIndex == 1
                ? MetroThemeStyle.Light
                : MetroThemeStyle.Dark;
        }

    }
}
