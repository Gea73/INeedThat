using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INeedThat
{
    public class Player
    {
        public bool Human { get; private set; }
        public int PlayerID { get; private set; }
        public string Name { get; private set; }
        public int Cash { get; set; }
        public List<Crew> PlayerCrew { get; set; }
        public int Respect { get; set; }
        public List<Gun> GunStock { get; set; }
        public List<Crew> InPrisonCrew {  get; set; }

        public Player(string name, int playerid, bool human)
        {
            Name = name;
            Human = human;
            PlayerID = playerid;
            Cash = 10000;
            PlayerCrew = new List<Crew>();
            Respect = 0;
            GunStock = new List<Gun>();
            InPrisonCrew = new List<Crew>();

        }

        public override string ToString()
        {
            string playercrew = string.Empty;
            string gunstock = string.Empty;
            //defining the strings a list of to strings of crew and guns
            foreach (Crew crew in PlayerCrew)
            {
                playercrew += crew.ToString();
            }
            foreach (Gun gun in GunStock)
            {
                gunstock += gun.ToString();
            }


            return $"Name:{Name} Cash:{Cash} Respect:{Respect} CrewMembers:{playercrew} GunStock:{gunstock}";

        }

    }
}
