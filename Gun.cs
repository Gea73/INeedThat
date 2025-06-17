using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INeedThat
{
    public class Gun
    {
        public int GunID { get; private set; }
        public string Name { get; private set; }
        public int Firepower { get; private set; }
        public Crew UsedBy { get; set; }
        //who is the crew using it
       
        public Gun(string name, int firepower, int gunid)
        {
            Name = name;
            Firepower = firepower;
            UsedBy = null;
            GunID = gunid;
        }

        public override string ToString()
        {
            string usedBy = "Nobody";

            if (UsedBy != null)
            {
                usedBy = UsedBy.Name;
            }

            return $"{Name} FIR:{Firepower} USED:{usedBy}\n";
        }

        public static int LastGunIdUsed(Player player)
        {
            int lastUsed = 0;
            foreach (Gun gun in player.GunStock)
            {
                if (gun.GunID > lastUsed)
                {
                    lastUsed = gun.GunID;
                }
            }
            return lastUsed;
        }

      
    }
}
