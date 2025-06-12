using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INeedThat
{
    public class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();
            //create the players
            game.CreatePlayers(game);
            //create the hoods
            game.CreateMap(game);
            //start the loop game menu
            game.Menu(game);

        }
    }
}
