using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositieEnAggregatie
{
    class RPG
    {
        private static readonly Random rnd = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return rnd.Next(min, max);
            }
        }
    }
    class Dungeon : RPG
    {
        public string Naam { get; set; }
        public List<Room> Rooms = new List<Room>();
        public List<Character> Characters = new List<Character>();
        public List<Monster> Monsters = new List<Monster>();

    }
    class Room : Dungeon
    {
        private int afstand;
        private byte deuren;
        public int Level { get; set; }
        public int MinAfstand { get; set; }
        public int MaxAfstand { get; set; }
        public byte MinAantalDeuren { get; set; }
        public byte MaxAantalDeuren { get; set; }
        public byte GevaarteLvl { get; set; }
        public byte BeloningLvl { get; set; }
        public byte Deuren
        {
            get { return deuren; }
            set { deuren = value; }
        }
        public int Afstand
        {
            get { return afstand; }
            set { afstand = value; }
        }
        public string ShowFullStats(bool bShowOnScreen = true)
        {
            string temp = string.Format(    "Name: {0,10} " +
                                            "Deuren: {1,2} " +
                                            "Afstand: {2,3} " +
                                            "Gevaarte: {3,4} " +
                                            "Beloning: {4,4} "
                                            , Naam, Deuren, Afstand, GevaarteLvl, BeloningLvl);
            if (bShowOnScreen) Console.WriteLine(temp);
            return temp;
        }

    }
    class Small_Room : Room
    {
        public Small_Room(string naam = "Small Room", int lvl = 1)
        {
            Naam = naam;
            Level = lvl;
            MinAfstand = 6;
            MaxAfstand = 20;
            MinAantalDeuren = 1;
            MaxAantalDeuren = 5;
            Deuren = (byte)RandomNumber(MinAantalDeuren, MaxAantalDeuren);
            Afstand = RandomNumber(MinAfstand, MaxAfstand);
            GevaarteLvl = (byte)RandomNumber(1, Level);
            BeloningLvl = (byte)RandomNumber(1, Level);
        }
    }
    class Character : RPG
    {
        public string Naam { get; set; }
        private int level = 1;
        private int hp_base;
        private int attack_base;
        private int defense_base;
        private int speed;
        private int experience = 0;
        private int gewicht = 0;
        private int maxGewicht = 0;
        private double geld = 0;
        public int VolgendeLvL { get { return level * 10; } }
        public double HP_Full { get { return (((hp_base + 50) * level) / 50) + 10; } }
        public double Attack_Full { get { return (((attack_base + 50) * level) / 50) + 10; } }
        public double Defense_Full { get { return (((defense_base + 50) * level) / 50) + 10; } }
        public double Speed_Full { get { return (((speed + 50) * level) / 50) + 10; } }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public List<Item> Inventory = new List<Item>();
        public Item[] Handen = new Item[2];
        public Item[] Lichaam = new Item[7];
        public int MaxGewicht
        {
            get { return maxGewicht; }
            set { maxGewicht = value; }
        }
        public int Gewicht
        {
            get { return gewicht; }
            set { gewicht = value; }
        }        
        public double Geld
        {
            get { return geld; }
            set { geld = value; }
        }
        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        public int Defense_base
        {
            get { return defense_base; }
            set { defense_base = value; }
        }
        public int Attack_base
        {
            get { return attack_base; }
            set { attack_base = value; }
        }
        public int Hp_base
        {
            get { return hp_base; }
            set { hp_base = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public void HandenSlotVullen(Wapen wapen)
        {
            bool bInSlot = false;
            for (int i = 0; i < Handen.Length; i++)
            {
                if (Handen[i] == null)
                {
                    if (gewicht + wapen.Gewicht < maxGewicht+1)
                    {
                        Handen[i] = wapen;
                        attack_base += (int)wapen.Attack_Full;
                        defense_base += (int)wapen.Attack_Full;
                        bInSlot = true;
                    }
                }
            }
        }
        public void LichaamSlotVullen(Item wapen)
        {
            bool bInSlot = false;
            for (int i = 0; i < Handen.Length; i++)
            {
                if (Handen[i] == null)
                {
                    if (gewicht + wapen.Gewicht < maxGewicht + 1)
                    {
                        Handen[i] = wapen;
                        //attack_base += (int)wapen.Attack_Full;
                        //defense_base += (int)wapen.Attack_Full;
                        bInSlot = true;
                    }
                }
            }
        }
        public void VerhoogLevel()
        {
            level++;
        }
        public string ShowFullStats(bool bShowOnScreen = true)
        {
            string temp = string.Format(    "Name: {4,10} " +
                                            "Health Points: {0,4:0} ({5,2})" +
                                            "Attack: {1,4:0} ({6,2})" +
                                            "Defense: {2,4:0} ({7,2})" +
                                            "Speed: {3,4:0} ({8,2})", +
                                                HP_Full, Attack_Full, Defense_Full, Speed_Full, Naam,Hp_base,attack_base,defense_base,speed);
            if (bShowOnScreen) Console.WriteLine(temp);
            return temp;
        }
        public override string ToString()
        {
            return ShowFullStats();
        }
        public void KrijgXp(int xpVerdient)
        {
            int nieuwXp;
            experience += xpVerdient;
            if (experience>VolgendeLvL-1)
            {
                nieuwXp = VolgendeLvL - experience;
                experience = nieuwXp;
                VerhoogLevel();
            }
        }


    }
    class Player : Character
    {
        private static Random rnd;

        public Player(string naam = "Player")
        {
            rnd = new Random();
            Naam = naam;
            Level = 1;
            Hp_base = 10* RandomNumber(1,20);
            Attack_base = 10 * RandomNumber(1, 15);
            Defense_base = 10 * RandomNumber(1, 10);
            MaxGewicht = 10 * RandomNumber(1, 10);
            Speed = 2*RandomNumber(1, 10);
        }
    }
    class Monster : Character
    {

        public Monster(string naam, int level = 1)
        {
            Random rnd = new Random();
            Naam = naam;
            Level = level;
            Hp_base = 2 * RandomNumber(1, 10);
            Attack_base = 1 * RandomNumber(1, 10);
            Defense_base = 1 * RandomNumber(1, 10);
            MaxGewicht = 5 * RandomNumber(1, 20);
        }
    }
    class Item : RPG
    {

        private int waarde_base;

        public int Waarde_base
        {
            get { return waarde_base; }
            set { waarde_base = value; }
        }

        public string Naam { get; set; }
        public double Waarde_Full { get { return (((waarde_base + 50) * Level) / 50); } }
        public int Level { get; set; }
        public int Gewicht { get; set; }
    }
    class Wapen : Item
    {
        private int attack_base;
        private int defense_base;

        public int Defense_base
        {
            get { return defense_base; }
            set { defense_base = value; }
        }

        public int Attack_base
        {
            get { return attack_base; }
            set { attack_base = value; }
        }
        public double Attack_Full { get { return (((attack_base + 50) * Level) / 50) + 10; } }
        public double Defense_Full { get { return (((defense_base + 50) * Level) / 50) + 10; } }

        public string ShowFullStats(bool bShowOnScreen = true)
        {
            string temp = string.Format("Attack: {0,4:0} " +
                                                "Defense: {1,4:0} " +
                                                "Waarde: {2,4:0} " +
                                                "Gewicht: {3,4:0} ", +
                                                 Attack_Full, Defense_Full, Waarde_Full,Gewicht);
            if (bShowOnScreen) Console.WriteLine(temp);
            return temp;
        }


    }
    class Zwaard : Wapen
    {

        Zwaard()
        {
            Attack_base = 3* RandomNumber(1,10);
            Level = 1;
            Defense_base = 1 * RandomNumber(1, 10);
            Gewicht = 1 * RandomNumber(1, 10);
            Waarde_base = 2 * RandomNumber(1, 10);
        }
    }
    class Shield : Wapen
    {
        Shield()
        {
            Attack_base = 1 * RandomNumber(1, 10);
            Level = 1;
            Defense_base = 4 * RandomNumber(1, 10);
            Gewicht = 3 * RandomNumber(1, 10);
            Waarde_base = 3 * RandomNumber(1, 10);
        }
    }
}
