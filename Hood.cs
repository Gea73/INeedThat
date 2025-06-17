using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INeedThat
{
    public class Hood
    {
        public int HoodID { get; private set; }
        public string Name { get; private set; }
        public int Value { get; private set; }
        public Hood AdjTop { get; set; }
        public Hood AdjBot { get; set; }
        public Hood AdjRig { get; set; }
        public Hood AdjLef { get; set; }


        public Hood(string name, int value, int hoodid)
        {
            Name = name;
            Value = value;
            HoodID = hoodid;
            AdjTop = null;
            AdjBot = null;
            AdjRig = null;
            AdjLef = null;

        }

        public override string ToString()
        {
            if (AdjTop == null || AdjRig == null || AdjLef == null || AdjLef == null)
            {
                return "Error in hood ajacency";
            }
            else
            {
                return $"{Name} ${Value} TOP:{AdjTop.Name} BOT:{AdjBot.Name} RIG:{AdjRig.Name} LEF:{AdjLef.Name}\n";
            }
        }
    }
}
