using System;
using System.IO;
using MetroFramework.Components;

namespace SemniarPI
{
    class SettingsObject
    {
        private static SettingsObject me;
        public static SettingsObject GetSettings()
        {
            return me is null ? new SettingsObject() : me;
        }

        private SettingsObject()
        {
            StyleManager = new MetroStyleManager();
            Tolerance = 0;
        }

        public MetroStyleManager StyleManager;
        public int Tolerance = 0;
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
            Teral,
            White,
            Green,
            Red
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
