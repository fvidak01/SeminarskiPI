using System;
using MetroFramework.Forms;

namespace SemniarPI
{
    public partial class SettingsForm : MetroForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            this.metroComboBox3.SelectedIndex = 0;
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
        }
    }
}
