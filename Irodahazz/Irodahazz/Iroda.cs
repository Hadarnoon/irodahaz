using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irodahazz
{
    internal class Iroda
    {
        public string Kod { get; set; }
        public int Kezdet { get; set; }
        public List<int> Letszamok { get; set; }

        public Iroda(string sor)
        {
            var v = sor.Split(' ');
            this.Kod = v[0];
            this.Kezdet = int.Parse(v[1]);
            this.Letszamok = new List<int>();
            for (int i = 2; i < v.Length; i++)
            {
                Letszamok.Add(int.Parse(v[i]));
            }
        }

        public override string ToString()
        {
            return $"{Kod} | {Kezdet} | {string.Join(" ", Letszamok)}";
        }
    }
}
