using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositieEnAggregatie
{
    class Moederbord
    {
        private static byte maxAantalRam = 4;
        private static byte maxAGP = 2;
        private static byte maxPCI = 6;
        private static byte maxUSB = 10;
        public List<Ram> rams = new List<Ram>();
        public CPU cpu;
        public AGP[] AGPS = new AGP[maxAGP];
        public PCI[] PCIS = new PCI[maxPCI];
        public USB[] USBS = new USB[maxUSB];

        public byte MaxAantalRam
        {
            get { return maxAantalRam; }
            private set { maxAantalRam = value; }
        }
        public byte MaxAGP
        {
            get { return maxAGP; }
            private set { maxAGP = value; }
        }

        public byte MaxPCI
        {
            get { return maxPCI; }
            private set { maxPCI = value; }
        }

        public byte MaxUSB
        {
            get { return maxUSB; }
            set { maxUSB = value; }
        }



        public void VoegRamToe(Ram ram)
        {
            if (rams != null)
            {
                rams = new List<Ram>();
                rams.Add(ram);
            }else
            {
                if (rams.Count < MaxAantalRam) rams.Add(ram);
            }
        }
        public void VoegAGPToe(AGP agp)
        {
            bool bToegevoegd = false;
            for (int i = 0; i < AGPS.Length; i++)
            {
                if (AGPS[i] == null)
                {
                    AGPS[i] = agp;
                    bToegevoegd = true;
                    break;
                }
            }
            if (!bToegevoegd) Console.WriteLine("AGP slots zitten vol");
        }
        public void VoegUSBToe(USB usb)
        {
            bool bToegevoegd = false;
            for (int i = 0; i < USBS.Length; i++)
            {
                if (USBS[i] == null)
                {
                    USBS[i] = usb;
                    bToegevoegd = true;
                    break;
                }
            }
            if (!bToegevoegd) Console.WriteLine("AGP slots zitten vol");
        }
        public void VoegPCIToe(PCI pci)
        {
            bool bToegevoegd = false;
            for (int i = 0; i < PCIS.Length; i++)
            {
                if (PCIS[i] == null)
                {
                    PCIS[i] = pci;
                    bToegevoegd = true;
                    break;
                }
            }
            if (!bToegevoegd) Console.WriteLine("AGP slots zitten vol");
        }
        public void TestMoederbord()
        {
            byte count = 0;
            Console.WriteLine("Openslotten van het moederbord:");
            if (cpu == null) Console.WriteLine("CPU slot is leeg");
            if (rams == null) Console.WriteLine("Geen ram gevonden");
            else
                Console.WriteLine(maxAantalRam - rams.Count + $"/{maxAantalRam} RAM slots over");
            for (int i = 0; i < AGPS.Length; i++)
            {
                if (AGPS[i] == null) count++;
            }
            Console.WriteLine(count + $"/{maxAGP} AGP slots over");
            count = 0;
            for (int i = 0; i < PCIS.Length; i++)
            {
                if (PCIS[i] == null) count++;
            }
            Console.WriteLine(count + $"/{maxPCI} PCI slots over");
            count = 0;
            for (int i = 0; i < USBS.Length; i++)
            {
                if (USBS[i] == null) count++;
            }
            Console.WriteLine(count + $"/{maxUSB} USB slots over");
        }

    }
    class Ram
    {
        private string naam;

        public Ram(string naam)
        {
            this.naam = naam;
        }
    }
    class AGP
    {
        private string naam;
        public AGP(string naam)
        {
            this.naam = naam;
        }
    }
    class CPU
    {
        private string naam;
        public CPU(string naam)
        {
            this.naam = naam;
        }
    }
    class USB
    {
        private string naam;
        public USB(string naam)
        {
            this.naam = naam;
        }
    }
    class PCI
    {
        private string naam;
        public PCI(string naam)
        {
            this.naam = naam;
        }
    }
}
