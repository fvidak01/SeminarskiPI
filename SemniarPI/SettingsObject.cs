using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemniarPI
{
    class SettingsObject
    {
        public event EventHandler ApperenceChanged;
        public event EventHandler LoggingSwitched;
        public event EventHandler DatabaseChanged; //TODO: Implement and use
        public enum FormTheme
        {
            Black,
            White
        }
        public enum FormStyle
        {
            //TODO: Add all styles
            Blue,
            Teral
        }

        private bool _logging;
        private FormTheme _theme;
        private FormStyle _style;
        private FileInfo _selectedDb;

        public FileInfo SelectedDb
        {
            get => _selectedDb;
            set => _selectedDb = value; //TODO: Fire event
        }

        public bool EnableLogging
        {
            get => _logging;
            set
            {
                if (value == _logging)
                    return;
                _logging = value;
                LoggingSwitched?.Invoke(this, null);

            }
        }

        public FormTheme Theme
        {
            get => _theme;
            set
            {
                _theme = value;
                ApperenceChanged?.Invoke(this, null);
            }
        }

        public FormStyle Style
        {
            get => _style;
            set
            {
                _style = value;
                ApperenceChanged?.Invoke(this, null);
            }
        }
    }
}
