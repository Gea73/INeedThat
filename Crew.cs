using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INeedThat
{
    public class Crew
    {
        public int CrewID { get; private set; }
        public string Name { get; private set; }
        public Player Aff { get; set; }
        public Gun GunEquip { get; set; }
        public Hood Location { get; set; }
        public int Brutality { get; private set; }
        public int Hustle { get; private set; }
        public int Snoop { get; private set; }
        private int _loyalty;
        public int Loyalty
        {
            get { return _loyalty; }
            set { _loyalty = Math.Max(0, value); }
        }
        private int _heat;
        public int Heat
        {
            get { return _heat; }
            set { _heat = Math.Max(0, value); }
        }
        public bool Lieutenant { get; set; }
        public bool Captain { get; set; }
        public int MonthsInPrison { get; set; }
        public int MonthsWounded { get; set; }

        public bool AlreadyMovedThisTurn = false;
        public Crew(string name, Player aff, Gun gunEquip, int brutality, int hustle, int snoop, int loyalty, int crewid)
        {
            Name = name;
            Aff = aff;
            GunEquip = gunEquip;
            Brutality = brutality;
            Hustle = hustle;
            Snoop = snoop;
            Loyalty = loyalty;
            Heat = 0;
            Lieutenant = false;
            Location = null;
            CrewID = crewid;
        }

        public override string ToString()
        {
            string location = "Unassigned";
            string gun = "Unarmed";
            string rank = "";
            //Determining generic strings if the crew its unassigned
            if (Location != null)
            {
                location = Location.Name;
            }
            if (GunEquip != null)
            {
                gun = GunEquip.Name;
            }

            //string if its a captain
            if (Captain == true)
            {
                rank = "Captain:";

            }


            //string if its a lieutenant
            else if (Lieutenant == true)
            {
                rank = "Lieutenant:";

            }
            //string if its a soldier


            return $"{rank}{Name} Aff:{Aff.Name} Gun:{gun} BRU:{Brutality} HUS:{Hustle} SNO:{Snoop} LOY:{Loyalty} LOC:{location} HEAT:{Heat}\n";

        }

        public static int LastCrewIdUsed(Player player)
        {
            int lastUsed = 0;
            foreach (Crew crew in player.PlayerCrew)
            {
                if (crew.CrewID > lastUsed)
                {
                    lastUsed = crew.CrewID;
                }
            }
            return lastUsed;
        }

    }
}
