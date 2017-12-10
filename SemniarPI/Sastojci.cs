using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemniarPI
{
    class Sastojci
    {
        private string _ime;
        private string _napomena;
        private byte[] _slika;

        public string Ime { get => _ime; set => _ime = value; }
        public string Napomena { get => _napomena; set => _napomena = value; }
        public byte[] Slika { get => _slika; set => _slika = value; }
    }

}
