using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace SemniarPI
{
    [DataContract]
    public class Sastojci
    {
         [DataMember]
        private readonly long _id;
        [DataMember]
        private string _ime;
        [DataMember]
        private string _napomena;
        [DataMember]
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
        public static string Serilize()
        {
            var s = DateTime.Now.ToString("hh:mm:ss").Replace(":","") +"i" + new Random().Next(1, 10) + ".xml";
            var file = File.Create(s);
            var ser = new DataContractSerializer(typeof(List<Sastojci>));
            XmlWriterSettings set = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "   "
            };
            using (var xw = XmlWriter.Create(file, set))
            {
                ser.WriteObject(xw, DBaccess.MySastojcis);
                xw.Close();
                file.Close();
            }
            return s;
        }

        public static void Deserilize(FileInfo f)
        {
            if (f.Length <=1)
                return;
            FileStream file = File.OpenRead(f.Name);
            DataContractSerializer ser = new DataContractSerializer(typeof(List<Sastojci>));
            try
            {
                if (File.Exists(f.Name))
                {
                    DBaccess.MySastojcis = (List<Sastojci>)ser.ReadObject(file);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Greska prilikom otvaranja datoteke. Datoteka ne postoji!", "Greska 102", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Greska prilikom čitanja podataka! Ex poruka:\n" + e.Message + "\nIner Ex:\n" + e.InnerException?.Message, "Greska 101", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                file.Close();
            }
        }
    }

}
