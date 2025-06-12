using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INeedThat
{
    public class Map
    {
        public List<Hood> MapHoods { get; set; }

        public Map()
        {

            MapHoods = new List<Hood>();

        }
        //just to bear a the hood list

        public override string ToString()
        {
            string hoodlist = string.Empty;

            foreach (Hood hood in MapHoods)
            {
                hoodlist += hood.ToString();

            }
            //return every hood to string in a list
            return $"{hoodlist}";

        }

    }
}
