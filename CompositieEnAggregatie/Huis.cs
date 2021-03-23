using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositieEnAggregatie
{
    class Huis
    {
        public List<Kamer> Kamers = new List<Kamer>();
        public Huis(Kamer kamer)
        {
            if (Kamers == null) Kamers = new List<Kamer>();
            Kamers.Add(kamer);
        }
        public Huis(List<Kamer> kamers)
        {
            if (Kamers == null) Kamers = new List<Kamer>();
            foreach (Kamer kamer in kamers)
            {
                Kamers.Add(kamer);
            }
        }
        public double BerekenPrijs()
        {
            double Totaal = 0;
            if (Kamers != null)
            {
                foreach (Kamer kamer in Kamers)
                {
                    Totaal += kamer.Prijs;
                }
            }
            return Totaal;
        }
    }
    class Kamer
    {
        public int Oppervlakte { get; set; }
        public string Naam { get; set; }
        public virtual double Prijs { get; set; }
        public Kamer (string naam, int oppervlakte = 0)
        {
            Naam = naam;
            Oppervlakte = oppervlakte;
            Prijs = 400;
        }
    }
    class Badkamer : Kamer
    {
        public override double Prijs { get => base.Prijs; set => base.Prijs = value; }

        public Badkamer(string naam, int oppervlakte = 0) : base(naam,oppervlakte)
        {
            Naam = naam;
            Oppervlakte = oppervlakte;
            Prijs = 500;
        }
    }
    class Gang : Kamer
    {
        private const byte prijsPerVierkanteMeter = 10;
        public override double Prijs { get => base.Prijs; set => base.Prijs = value; }
        public Gang(string naam, int oppervlakte) : base(naam,oppervlakte)
        {
            Oppervlakte = oppervlakte;
            Naam = naam;
            Prijs = Math.Round((double)oppervlakte * prijsPerVierkanteMeter);
        }
    }
    class Salon : Kamer
    {
        private bool SchouwAanwezig;
        public override double Prijs { get => base.Prijs; set => base.Prijs = value; }

        public Salon(string naam, int oppervlakte = 0, bool schouwAanwezig = false):base(naam,oppervlakte)
        {
            SchouwAanwezig = schouwAanwezig;
            Naam = naam;
            Oppervlakte = oppervlakte;
            if (schouwAanwezig) Prijs = 500;
            else Prijs = 300;
        }
    }
}
