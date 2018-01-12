using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace SemniarPI
{
    public class Sastojci
    {
        private readonly long _id;
        private string _ime;
        private string _napomena;
        private byte[] _slika;
        public Sastojci(object[] arr)
        {
            var i = 0;
            _id = (long)arr[i++];
            _ime = (string)arr[i++];
            _napomena = arr[i++] is DBNull ? null : (string)arr[i - 1];
            _slika = (byte[])arr[i];
        }
        public string Ime { get => _ime; set => _ime = value; }
        public string Napomena { get => _napomena; set => _napomena = value; }
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
        public long Id => _id;
        public static List<Sastojci> CreateSastojciList(List<object[]> rawInput)
        {
            if (rawInput is null)
                throw new ArgumentNullException(nameof(rawInput));
            var list = new List<Sastojci>();
            foreach (object[] t in rawInput)
            {
                var item = new Sastojci(t);
                list.Add(item);
            }
            return list;
        }
    }

}
