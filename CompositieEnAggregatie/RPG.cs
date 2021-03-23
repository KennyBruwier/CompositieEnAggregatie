using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositieEnAggregatie
{
    class RPG
    {

    }
    class Dungeon
    {
        public string Naam { get; set; }
        public List<Room> rooms = new List<Room>();
    }
    class Room 
    {
        public string Naam { get; set; }
        public int Lengte { get; set; }
        public int Breedte { get; set; }
        public byte AantalDeuren { get; set; }
        public byte GevaarteLvl { get; set; }
        public byte BeloningLvl { get; set; }
    }
    class Character
    {
        public string Naam { get; set; }
        private int level = 0;
        private int hp_base;
        private int attack_base;
        private int defense_base;
        private int speed;
        private int experience = 0;
        private int gewicht = 0;
        private int maxGewicht = 0;
        private double geld = 0;


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

        public void VerhoogLevel()
        {
            level++;
        }
        public string ShowFullStats(bool showOnScreen = false)
        {
            string fullStats = string.Format(   "Health Points: {0,4:0} " +
                                                "Attack: {1,4:0} " +
                                                "Defense: {2,4:0} " +
                                                "Speed: {3,4:0} " +
                                                HP_Full, Attack_Full, Defense_Full, Speed_Full);
            if (showOnScreen) Console.WriteLine(fullStats);
            return fullStats;
        }

        public override string ToString()
        {
            return ShowFullStats();
        }


    }
    class Player : Character
    {

        Player()
        {
            Level = 0;
            Hp_base = 100;
            Attack_base = 10;
            Defense_base = 10;
            MaxGewicht = 20;
            
        }
    }
    class Item
    {
        private int waarde_base;

        public int Waarde_base
        {
            get { return waarde_base; }
            set { waarde_base = value; }
        }
        private int attack_base;
        private int defense_base;



        public string Naam { get; set; }
        public double Waarde_Full { get { return (((waarde_base + 50) * Level) / 50); } }
        public int Level { get; set; }
        public int Gewicht { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public double Attack_Full { get { return (((attack_base + 50) * level) / 50) + 10; } }
        public double Defense_Full { get { return (((defense_base + 50) * level) / 50) + 10; } }


    }
    class Zwaard : Item
    {

        Zwaard()
        {
            Attack = 3;
            level = 1;
            Defense = 1;
            
        }
    }
}
