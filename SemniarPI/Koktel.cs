using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SemniarPI
{
    class Koktel
    {
        private string _ime;
        private string _opis;
        private string _upute;
        private byte[] _slika;

        public Koktel(object[] arr)
        {
            var i = 0;
            _ime = (string)arr[i++];
            _opis = (string)arr[i++];
            _upute = (string)arr[i++];
            _slika = (byte[])arr[i];
        }

        public string Ime => _ime;

        public string Opis => _opis;

        public string Upute => _upute;

        public Image Slika
        {
            get
            {
                var ms = new MemoryStream(_slika);
                return Image.FromStream(ms);
            }
        }

        public static List<Koktel> CreateKoktailList(List<object[]> rawInput)
        {
            if (rawInput is null)
                throw new ArgumentNullException(nameof(rawInput));
            var list = new List<Koktel>();
            foreach (object[] t in rawInput)
            {
                var item = new Koktel(t);
                list.Add(item);
            }
            return list;
        }
    }
}