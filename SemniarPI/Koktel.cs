using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace SemniarPI
{
    public class Koktel
    {
        private readonly long _id;
        private readonly string _ime;
        private readonly string _opis;
        private readonly string _upute;
        private readonly byte[] _slika;

        public Koktel(object[] arr)
        {
            var i = 0;
            _id = (long)arr[i++];
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
                if (_slika is null)
                    return null;
                var ms = new MemoryStream(_slika);
                return Image.FromStream(ms);
            }
        }

        public long ID => _id;

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