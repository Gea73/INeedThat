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
        public int Loyalty { get; private set; }
        public int Heat { get; private set; }
        public bool Lieutenant { get; set; }
        public bool Captain { get; set; }
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
                return $"Captain:{Name} Aff:{Aff.Name} Gun:{gun} BRU:{Brutality} HUS:{Hustle} SNO:{Snoop} LOY:{Loyalty} LOC:{location} HEAT:{Heat}\n";
            }


            //string if its a lieutenant
            if (Lieutenant == false)
            {
                return $"{Name} Aff:{Aff.Name} Gun:{gun} BRU:{Brutality} HUS:{Hustle} SNO:{Snoop} LOY:{Loyalty} LOC:{location} HEAT:{Heat}\n";
            }
            //string if its a soldier
            else
            {
                return $"Lieutenant:{Name} Aff:{Aff.Name} Gun:{gun} BRU:{Brutality} HUS:{Hustle} SNO:{Snoop} LOY:{Loyalty} LOC:{location} HEAT:{Heat}\n";
            }
        }





    }
}
