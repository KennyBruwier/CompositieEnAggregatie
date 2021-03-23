using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositieEnAggregatie
{
    class Land
    {
        public string Naam { get; set; }
        private const byte maxMinisters = 4;
        public List<Minister> ministers;
        public Minister EersteMinister;
        public President President;

        public Land(string naam)
        {
            Naam = naam;
        }

        public void MaakRegering(President president, List<Minister> ministers)
        {
            if (President != null)
                Console.WriteLine("Er is al een president. Tijd voor een coup!");
            else
            {
                President = president;
                if (ministers != null)
                    foreach (Minister minister in ministers)
                    {
                        if (EersteMinister == null)
                            EersteMinister = minister;
                        else
                        {
                            if (this.ministers == null) this.ministers = new List<Minister>();
                            if (this.ministers.Count < maxMinisters) this.ministers.Add(minister);
                        }
                    }
                else
                    Console.WriteLine("Regering zonder ministers! Eindelijk minder taxen");
            }
        }
        public void JaarVerder()
        {
            if (President != null)
            {
                President.JaarVerder();
                if (President.AantalJaren == 0)
                {
                    EersteMinister = null; 
                    ministers = new List<Minister>(); 
                    President = null; 
                }
            }
        }
    }
    class Minister
    {
        public string Naam { get; set; }
        public Minister(string naam)
        {
            Naam = naam;
        }
    }
    class President : Minister
    {
        private byte aantalJaren = 4;

        public byte AantalJaren
        {
            get { return aantalJaren; }
            private set { aantalJaren = value; }
        }

        public President(string naam) : base (naam)
        {
            Naam = naam;
        }

        public void JaarVerder()
        {
            aantalJaren--;
        }
    }
}
