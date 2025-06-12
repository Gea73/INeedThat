using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace INeedThat
{
    public class Game
    {
        public List<Player> Players { get; private set; }
        public Map GameMap { get; private set; }




        //method to create the players
        public void CreatePlayers(Game game)
        {

            Players = new List<Player>();
            int numPlayers = Input.ReadInt("How many do you want in the game?(Max:5)");
            //guaranteeing correct input
            while (numPlayers > 5 || numPlayers <= 1)
            {
                numPlayers = Input.ReadInt("How many do you want in the game?(Max:5)");
            }

            //for to create the numbers of players wanted
            for (int i = 0; i < numPlayers; i++)
            {
                string playerName = Input.ReadString("\nFaction Name:");

                Console.WriteLine("Player is human?");
                int ishuman = YesorNoInput();
                //guarante correct input

                //if the player is human he will be playable
                if (ishuman == 1)
                {
                    Player player = new Player(playerName, i, true);
                    Console.WriteLine(player);
                    game.Players.Add(player);

                    string captainName = Input.ReadString("Captain Name:");
                    Gun captainGun = new Gun("Colt 1911", 5, i);
                    Crew captain = new Crew(captainName, player, captainGun, 10, 10, 10, 10, i);
                    player.PlayerCrew.Add(captain);
                    captain.Captain = true;
                    Console.WriteLine(captain);
                }
                //npc ai creating
                else
                {
                    Player player = new Player(playerName, i, false);
                    Console.WriteLine(player);
                    game.Players.Add(player);
                    string captainName = Input.ReadString("Captain Name:");
                    Gun captainGun = new Gun("Colt 1911", 5, i);
                    Crew captain = new Crew(captainName, player, captainGun, 10, 10, 10, 10, i);
                    player.PlayerCrew.Add(captain);
                    captain.Captain = true;
                    Console.WriteLine(captain);
                }


            }
        }

        public void CreateMap(Game game)
        {
            Map map = new Map();

            int choice = Input.ReadInt("1:Caxias do Sul 2:New York 3:Chicago");
            //guarante correct input
            while (choice < 1 || choice > 3)
            {
                Console.WriteLine("Invalid city");
                choice = Input.ReadInt("1:Caxias do Sul 2:New York 3:Chicago");
            }

            switch (choice)
            {
                case 1:
                    //create all the hoods
                    Hood priMa = new Hood("1ºMaio", 4, 0);
                    Hood priJa = new Hood("1ºMaio Jd America", 3, 1);
                    Hood Burg = new Hood("Burgo", 3, 2);
                    Hood Anten = new Hood("Antena", 4, 3);
                    Hood Burac = new Hood("Buraco", 3, 4);
                    Hood Fatim = new Hood("Fatima Baixo", 3, 5);
                    Hood Pione = new Hood("Pioneiro", 2, 6);
                    Hood Cent = new Hood("Centenario", 2, 7);
                    Hood Cinq = new Hood("Cinquentenário", 4, 8);
                    Hood Reol = new Hood("Reolon", 3, 9);
                    Hood Cruze = new Hood("Cruzeiro", 2, 10);
                    Hood Pedr = new Hood("Pedreira", 2, 11);
                    Hood Pla = new Hood("Planalto", 3, 12);
                    Hood Vict = new Hood("São Victor", 2, 13);
                    Hood Chap = new Hood("Chapa", 3, 14);
                    Hood Charq = new Hood("Charqueadas", 1, 15);
                    Hood Mont = new Hood("Monte Carmelo", 2, 16);
                    Hood Diam = new Hood("Diamantino", 3, 17);
                    Hood Roci = new Hood("Rocinha", 3, 18);
                    Hood Pres = new Hood("Presidente Vargas", 1, 19);
                    Hood Camp = new Hood("Campos da Serra", 2, 20);
                    Hood StFe = new Hood("Santa Fé", 4, 21);
                    Hood Cany = new Hood("Canyon", 3, 22);
                    Hood Bel = new Hood("Belo Horizonte", 2, 23);
                    Hood Ipe = new Hood("Vila Ipê", 3, 24);
                    Hood Ser = new Hood("Serrano", 2, 25);
                    Hood Ira = new Hood("Jardim Iracema", 1, 26);
                    Hood Fil = new Hood("Filomena", 2, 27);
                    Hood Cast = new Hood("Castelo", 2, 28);
                    Hood Sec = new Hood("Seculo XX", 2, 29);
                    Hood Des = new Hood("Desvio Rizzo", 1, 30);
                    Hood Urb = new Hood("Região Urbana", 0, 31);

                    //define the adjacences of each hood
                    //prima prija
                    priMa.AdjTop = Fatim; priJa.AdjTop = Fatim;
                    priMa.AdjBot = Urb; priJa.AdjBot = Urb;
                    priMa.AdjRig = priJa; priJa.AdjRig = Burg;
                    priMa.AdjLef = Urb; priJa.AdjLef = priMa;
                    //burg anten burac
                    Burg.AdjTop = priJa; Anten.AdjTop = Burg; Burac.AdjTop = Anten;
                    Burg.AdjBot = Anten; Anten.AdjBot = Burac; Burac.AdjBot = Urb;
                    Burg.AdjRig = Pres; Anten.AdjRig = Burg; Burac.AdjRig = Anten;
                    Burg.AdjLef = priJa; Anten.AdjLef = Burg; Burac.AdjLef = Anten;
                    //fatim pione cent
                    Fatim.AdjTop = Cent; Pione.AdjTop = Cent; Cent.AdjTop = StFe;
                    Fatim.AdjBot = priMa; Pione.AdjBot = Urb; Cent.AdjBot = Fatim;
                    Fatim.AdjRig = Sec; Pione.AdjRig = Fatim; Cent.AdjRig = Sec;
                    Fatim.AdjLef = Pione; Pione.AdjLef = Urb; Cent.AdjLef = Pione;
                    //stfe cany ipe bel
                    StFe.AdjTop = Cany; Cany.AdjTop = Urb; Ipe.AdjTop = Cany; Bel.AdjTop = Cany;
                    StFe.AdjBot = Cent; Cany.AdjBot = StFe; Ipe.AdjBot = Cent; Bel.AdjBot = Cent;
                    StFe.AdjRig = Bel; Cany.AdjRig = Ser; Ipe.AdjRig = StFe; Bel.AdjRig = Ser;
                    StFe.AdjLef = Ipe; Cany.AdjLef = Ipe; Ipe.AdjLef = Urb; Bel.AdjLef = StFe;
                    // ser ira fil cast sec
                    Ser.AdjTop = Ira; Ira.AdjTop = Urb; Fil.AdjTop = Urb; Cast.AdjTop = Ser; Sec.AdjTop = Ser;
                    Ser.AdjBot = Sec; Ira.AdjBot = Ser; Fil.AdjBot = Ser; Cast.AdjBot = Diam; Sec.AdjBot = Urb;
                    Ser.AdjRig = Cast; Ira.AdjRig = Urb; Fil.AdjRig = Ira; Cast.AdjRig = Urb; Sec.AdjRig = Cast;
                    Ser.AdjLef = Fil; Ira.AdjLef = Fil; Fil.AdjLef = Urb; Cast.AdjLef = Sec; Sec.AdjLef = Fatim;
                    // diam cap roci pres
                    Diam.AdjTop = Cast; Camp.AdjTop = Cast; Roci.AdjTop = Diam; Pres.AdjTop = Diam;
                    Diam.AdjBot = Roci; Camp.AdjBot = Roci; Roci.AdjBot = Cruze; Pres.AdjBot = Cruze;
                    Diam.AdjRig = Camp; Camp.AdjRig = Urb; Roci.AdjRig = Camp; Pres.AdjRig = Roci;
                    Diam.AdjLef = Pres; Camp.AdjLef = Diam; Roci.AdjLef = Pres; Pres.AdjLef = Burg;
                    // plan vict chap
                    Pla.AdjTop = Urb; Vict.AdjTop = Pla; Chap.AdjTop = Pla;
                    Pla.AdjBot = Vict; Vict.AdjBot = Mont; Chap.AdjBot = Vict;
                    Pla.AdjRig = Cruze; Vict.AdjRig = Urb; Chap.AdjRig = Pla;
                    Pla.AdjLef = Chap; Vict.AdjLef = Chap; Chap.AdjLef = Urb;
                    // mont des charq reol
                    Mont.AdjTop = Vict; Des.AdjTop = Charq; Charq.AdjTop = Cinq; Reol.AdjTop = Urb;
                    Mont.AdjBot = Urb; Des.AdjBot = Urb; Charq.AdjBot = Des; Reol.AdjBot = Des;
                    Mont.AdjRig = Vict; Des.AdjRig = Mont; Charq.AdjRig = Urb; Reol.AdjRig = Cinq;
                    Mont.AdjLef = Des; Des.AdjLef = Reol; Charq.AdjLef = Des; Reol.AdjLef = Urb;
                    // cinq cruze pedr
                    Cinq.AdjTop = Urb; Cruze.AdjTop = Roci; Pedr.AdjTop = Urb;
                    Cinq.AdjBot = Charq; Cruze.AdjBot = Pla; Pedr.AdjBot = Urb;
                    Cinq.AdjLef = Reol; Cruze.AdjRig = Pedr; Pedr.AdjRig = Urb;
                    Cinq.AdjRig = Urb; Cruze.AdjLef = Pres; Pedr.AdjLef = Cruze;

                    //add hoods to the the list of hoods in the game map
                    map.MapHoods.Add(priMa); map.MapHoods.Add(priJa);
                    map.MapHoods.Add(Burg); map.MapHoods.Add(Anten); map.MapHoods.Add(Burac);
                    map.MapHoods.Add(Fatim); map.MapHoods.Add(Pione); map.MapHoods.Add(Cent);
                    map.MapHoods.Add(Cany); map.MapHoods.Add(StFe); map.MapHoods.Add(Ipe); map.MapHoods.Add(Bel);
                    map.MapHoods.Add(Ser); map.MapHoods.Add(Ira); map.MapHoods.Add(Fil); map.MapHoods.Add(Cast);
                    map.MapHoods.Add(Diam); map.MapHoods.Add(Camp); map.MapHoods.Add(Roci); map.MapHoods.Add(Pres);
                    map.MapHoods.Add(Pla); map.MapHoods.Add(Vict); map.MapHoods.Add(Chap);
                    map.MapHoods.Add(Mont); map.MapHoods.Add(Des); map.MapHoods.Add(Charq); map.MapHoods.Add(Reol);
                    map.MapHoods.Add(Cinq); map.MapHoods.Add(Sec); map.MapHoods.Add(Cruze); map.MapHoods.Add(Pedr);

                    break;

                case 2:
                    Console.WriteLine("Not avaliable");
                    break;
                case 3:
                    Console.WriteLine("Not avaliable");
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    break;

            }
            //define the map created as the gamemap
            GameMap = map;
            Console.WriteLine(GameMap);
        }


        public void Menu(Game game)
        {
            Console.WriteLine("Game Started Welcome Homie");
            Console.ReadLine();
            Console.Clear();
            //define if the game will keep looping menu
            bool gameRunning = true;
            Player actualPlayer = null;
            //look for a human player to define as a real player
            foreach (Player player in game.Players)
            {
                if (player.Human == true)
                {
                    actualPlayer = player;
                }
            }
            while (gameRunning)

            {
                //draw the map of hoods
                DrawMap(game);
                //show menu options
                Console.WriteLine("Menu:");
                Console.WriteLine("0:Move Crew:");
                Console.WriteLine("1:Select Hood:");
                Console.WriteLine("2:Select Crew:");
                Console.WriteLine("3:Lieutenant Reports :");
                Console.WriteLine("4:Black Market:");
                Console.WriteLine("5.End Turn:");
                Console.WriteLine("123:Exit:");
                int choice = Input.ReadInt("Type the choice:");
                switch (choice)
                {
                    case 0:
                        game.MoveCrew(game, actualPlayer);
                        break;
                    case 1:
                        game.SelectHood(game, actualPlayer);
                        break;
                    case 2:
                        game.SelectCrew(game, actualPlayer);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 123:

                        break;


                    default:
                        Console.WriteLine("Wrong Number");
                        break;
                }
            }




        }


        public void DrawMap(Game game)
        {

            Console.WriteLine("                                                             +--------+             +-------+                                ");
            Console.WriteLine("                                                             |Filomena|             |Iracema|                                ");
            Console.WriteLine("                                         +------+            +--------+             +-------+                                ");
            Console.WriteLine("                                         |Canyon|                           +-------+                                        ");
            Console.WriteLine("                                         +------+                           |Serrano|                                        ");
            Console.WriteLine("                                                                            +-------+                                        ");
            Console.WriteLine("                             +------+        +-----+    +----+                                                               ");
            Console.WriteLine("                             |Vl.Ipe|        |St.Fe|    |Belo|                                                               ");
            Console.WriteLine("                             +------+        +-----+    +----+                                                               ");
            Console.WriteLine("                                                                                                                             ");
            Console.WriteLine("                                           +----------+                                 +-------+                            ");
            Console.WriteLine("                                           |Centenário|                                 |Castelo|                            ");
            Console.WriteLine("                                           +----------+                                 +-------+                            ");
            Console.WriteLine("                             +--------+                                                                                      ");
            Console.WriteLine("                             |Pioneiro|                                                                                      ");
            Console.WriteLine("                             +--------+  +-------+                 +---------+                                               ");
            Console.WriteLine("                                         |Fatima |                 |Seculo XX|                                               ");
            Console.WriteLine("                                         +-------+                 +---------+                                 +------+      ");
            Console.WriteLine("                                                                                                               |Campos|      ");
            Console.WriteLine("               +--------------+                +------+     +-----------+                                      +------+      ");
            Console.WriteLine("               |Cinquentenário|                |1 Maio|     |1 MaioJd.Am|                          +----------+              ");
            Console.WriteLine("               +--------------+                +------+     +-----------+                          |Diamantino|              ");
            Console.WriteLine("                                                       +-----+                +-----------+        +----------+              ");
            Console.WriteLine("      +------+                                         |Burgo|                |Pres.Vargas|               +-------+          ");
            Console.WriteLine("      |Reolon|                                         +------+               +-----------+               |Rocinha|          ");
            Console.WriteLine("      +------+                                         |Antena|                                           +-------+          ");
            Console.WriteLine("                                                       +------+ +------+                                                     ");
            Console.WriteLine("                                                                |Buraco|                                                     ");
            Console.WriteLine("                     +-----------+                              +------+                                                     ");
            Console.WriteLine("                     |Charqueadas|                                                         +--------+         +--------+     ");
            Console.WriteLine("                     +-----------+                                                         |Cruzeiro|         |Pedreira|     ");
            Console.WriteLine("                                                                                           +--------+         +--------+     ");
            Console.WriteLine("                           +------------+                                                                                    ");
            Console.WriteLine("                           |Desvio Rizzo|                                                                                    ");
            Console.WriteLine("                           +------------+                            +--------+                                              ");
            Console.WriteLine("                                                                     |Planalto|                                              ");
            Console.WriteLine("                                                                     +--------+                                              ");
            Console.WriteLine("                                                           +-----+                                                           ");
            Console.WriteLine("                                                           |Chapa|                                                           ");
            Console.WriteLine("                                                           +-----+        +------+                                           ");
            Console.WriteLine("                                                                          |Victor|                                           ");
            Console.WriteLine("                                                                          +------+                                           ");
            Console.WriteLine("                                                                                                                             ");
            Console.WriteLine("                                                         +------------+                                                      ");
            Console.WriteLine("                                                         |Monte Camelo|                                                      ");
            Console.WriteLine("                                                         +------------+                                                      ");



        }

        public void MoveCrew(Game game, Player player)
        {
            //no one selected
            Crew selectedCrew = null;

            //show the list based in the list of player crew showing the id 
            Console.WriteLine("Crew List:");
            foreach (Crew crew in player.PlayerCrew)
            {
                Console.WriteLine($"{crew.CrewID}.{crew.Name}");
            }


            int choice = Input.ReadInt("Type the index of the crew member:");

            //guarante right input
            while (choice < 0 && choice > player.PlayerCrew.Count)
            {
                Console.WriteLine("Invalid choice.");
                choice = Input.ReadInt("Type the index of the crew member:");
            }
            //search in the list and define the crew with the same id selected as the selectedcrew
            foreach (Crew crew in player.PlayerCrew)
            {
                if (choice == crew.CrewID)
                {
                    selectedCrew = crew;

                }
            }


            Console.WriteLine("Where you want to move?");
            //if the crew selected dont have position
            if (selectedCrew.Location == null)
            {
                //show all hoods in the game
                foreach (Hood hood in game.GameMap.MapHoods)
                {
                    Console.WriteLine($"{hood.HoodID}.{hood.Name}");
                }


                int moveTo = Input.ReadInt("Type the index of the hood:");

                //guarante right input
                while (moveTo < 0 && moveTo > game.GameMap.MapHoods.Count)
                {
                    Console.WriteLine("Invalid choice.");
                    moveTo = Input.ReadInt("Type the index of the hood:");
                }

                //search in the list and define the location of the movement as moveto id 
                foreach (Hood hood in game.GameMap.MapHoods)
                {
                    if (moveTo == hood.HoodID)
                    {
                        selectedCrew.Location = hood;


                        Console.WriteLine($"{selectedCrew.Name} moved to {selectedCrew.Location.Name}");
                        Console.ReadKey();

                    }
                }


            }
            else
            {
                //show only adjacents hoods
                Console.WriteLine(selectedCrew.Location.HoodID == 31 ? "" : $"Top {selectedCrew.Location.AdjTop.HoodID}:{selectedCrew.Location.AdjTop.Name}");
                Console.WriteLine(selectedCrew.Location.HoodID == 31 ? "" : $"Bottom {selectedCrew.Location.AdjBot.HoodID}:{selectedCrew.Location.AdjBot.Name}");
                Console.WriteLine(selectedCrew.Location.HoodID == 31 ? "" : $"Right {selectedCrew.Location.AdjRig.HoodID}:{selectedCrew.Location.AdjRig.Name}");
                Console.WriteLine(selectedCrew.Location.HoodID == 31 ? "" : $"Left {selectedCrew.Location.AdjLef.HoodID}:{selectedCrew.Location.AdjLef.Name}");

                int moveTo = Input.ReadInt("Type the index of the hood:");
                //guaranteing right input
                while (moveTo == 31 || moveTo < 0 || moveTo > game.GameMap.MapHoods.Count())
                {
                    Console.WriteLine("Invalid value");
                    moveTo = Input.ReadInt("Type the index of the hood:");
                }
                //check if the hood want to move is valid in adjancency based on id
                if (moveTo == selectedCrew.Location.AdjTop.HoodID || moveTo == selectedCrew.Location.AdjBot.HoodID || moveTo == selectedCrew.Location.AdjRig.HoodID || moveTo == selectedCrew.Location.AdjLef.HoodID)
                {
                    foreach (Hood hood in game.GameMap.MapHoods)
                    {
                        if (moveTo == hood.HoodID)
                        {
                            selectedCrew.Location = hood;
                            Console.WriteLine($"{selectedCrew.Name} moved to {selectedCrew.Location.Name}");
                            Console.ReadKey();
                        }

                    }
                }
                //if the input is aint equal the ids adjacents
                else
                {
                    Console.WriteLine("Invalid index hood");
                    Console.ReadKey();

                }

            }
        }

        public void SelectCrew(Game game, Player player)
        {


            Crew selectedCrew = null;
            //show the crew based on the list of player crew
            Console.WriteLine("Crew List:");

            foreach (Crew crew in player.PlayerCrew)
            {

                Console.WriteLine($"{crew.CrewID}.{crew.Name}");

            }

            int choice = Input.ReadInt("Type the index of the crew member:");
            //guarante right input
            while (choice < 0 && choice > player.PlayerCrew.Count)
            {
                Console.WriteLine("Invalid choice.");
                choice = Input.ReadInt("Type the index of the crew member:");
            }
            //select the crew based in id
            foreach (Crew crew in player.PlayerCrew)
            {
                if (choice == crew.CrewID)
                {
                    selectedCrew = crew;

                }
            }

            Console.WriteLine(selectedCrew);
            Console.WriteLine("1.Move Crew");
            Console.WriteLine("2.Equip Gun or remove");
            Console.WriteLine("3.Promote");

            int option = Input.ReadInt("Type the option");
            //guarante right input
            while (option < 1 || option > 3)
            {
                Console.WriteLine("Invalid option");
                option = Input.ReadInt("Type the option");
            }

            //options
            switch (option)
            {
                case 1:
                    MoveCrew(game, player);
                    break;
                case 2:
                    EquipGun(selectedCrew, player);
                    break;

                case 3:
                    Promote(selectedCrew);
                    break;

                default:
                    Console.WriteLine("Invalid Value");
                    break;
            }

        }


        private void EquipGun(Crew selectedCrew, Player player)
        {
            //if the crew have a gun
            if (selectedCrew.GunEquip != null)
            {
                Console.WriteLine($"Gun equipped{selectedCrew.GunEquip.Name}");
                Console.WriteLine("Remove it?");
                int choice = YesorNoInput();

                if (choice == 1)
                {
                    Gun gunRemoved = selectedCrew.GunEquip;
                    selectedCrew.GunEquip = null;
                    player.GunStock.Add(gunRemoved);
                    Console.WriteLine($"Gun {gunRemoved.Name} back to the stock");
                    Console.ReadKey();
                }
                //have changed the mind
                else
                {

                    Console.WriteLine("Nothing done");
                    Console.ReadKey();
                }

            }
            //if dont have a gun equipped
            else
            {
                Console.WriteLine("Guns Avaliable:");
                //show guns in stock
                foreach (Gun gun in player.GunStock)
                {
                    Console.WriteLine($"{gun.GunID}.{gun.Name}");
                }

                int gunSelected = Input.ReadInt("Type the index of the gun:");

                //guarante right input
                while (gunSelected < 0 && gunSelected > player.GunStock.Count())
                {
                    Console.WriteLine("Invalid choice.");
                    gunSelected = Input.ReadInt("Type the index of the gun:");
                }
                //select the gun based in id
                foreach (Gun gun in player.GunStock)
                {
                    if (gunSelected == gun.GunID)
                    {
                        selectedCrew.GunEquip = gun;
                        Console.WriteLine($"{selectedCrew.Name} equipped {selectedCrew.GunEquip.Name}");
                        Console.ReadKey();

                    }
                }

            }



        }

        private void Promote(Crew selectedCrew)
        {
            //check if is already promoted
            if (selectedCrew.Captain == true || selectedCrew.Lieutenant == true)
            {

                Console.WriteLine("This crew member is already a higher rank");
            }
            //is a soldier
            else
            {
                Console.WriteLine("Really want to promote?");
                Console.WriteLine(selectedCrew);
                int choice = YesorNoInput();
                //guarantee right input

                //promote
                if (choice == 1)
                {
                    selectedCrew.Lieutenant = true;
                    Console.WriteLine($"{selectedCrew.Name} is a lieutenant now");
                    Console.ReadKey();
                }
                //changed mind
                else
                {
                    Console.WriteLine("Nothing done");
                    Console.ReadKey();
                }

            }
        }


        public void SelectHood(Game game, Player human)
        {
            //make a list of all the crewmembers in that hood
            List<Crew> CrewinHood = new List<Crew>();
            //hood selected to view
            Hood hoodSelected = null;
            //show all hoods
            Console.WriteLine("Hood List:");
            foreach (Hood hood in game.GameMap.MapHoods)
            {
                Console.WriteLine($"{hood.HoodID}.{hood.Name}");
            }


            int hoodSelect = Input.ReadInt("Type the index of the hood:");

            //guarantee right input

            while (hoodSelect < 0 && hoodSelect > game.GameMap.MapHoods.Count)
            {
                Console.WriteLine("Invalid choice.");
                hoodSelect = Input.ReadInt("Type the index of the hood:");
            }
            //select the hood based on id
            foreach (Hood hood in game.GameMap.MapHoods)
            {
                if (hoodSelect == hood.HoodID)
                {
                    hoodSelected = hood;

                    Console.WriteLine($"{hoodSelected.Name} selected");

                }
            }

            //add the crewmembers in that hood on the hoodcrew list based on id location
            foreach (Player player in game.Players)
            {
                foreach (Crew crewmember in player.PlayerCrew)
                {
                    if (crewmember.Location.HoodID == hoodSelected.HoodID)
                    {
                        CrewinHood.Add(crewmember);


                    }
                }
            }
            //player visibility on that hoof
            int playerVisibility = 1;

            //if the player have crew in that hood gains more visibility
            foreach (Crew crew in CrewinHood)
            {
                if (crew.Aff.Human == true)
                {
                    playerVisibility += crew.Snoop;
                }
            }

            Console.WriteLine($"{hoodSelected.Name} Crew in:");
            //write the list of crew in the hoof
            foreach (Crew crew in CrewinHood)
            {
                //if is a human crew will always be writed with the id for select after
                if (crew.Aff.Human == true)
                {
                    Console.WriteLine($"{crew.CrewID}. {crew}");
                }
                else
                {
                    //increase the info of non human crew based on intel that are based in the snoop of human crew
                    if (playerVisibility >= 20)
                    {
                        Console.WriteLine(crew);
                    }
                    else if (playerVisibility >= 15)
                    {
                        Console.WriteLine($"Name:{crew.Name} Aff:{crew.Aff.Name} Gun:{crew.GunEquip} ");
                    }
                    else if (playerVisibility >= 10)
                    {
                        Console.WriteLine($"Name:{crew.Name} Aff:{crew.Aff.Name} ");
                    }
                    else if (playerVisibility >= 5)
                    {
                        Console.WriteLine($"Affiliation{crew.Aff.Name}");
                    }
                    else
                    {
                        Console.WriteLine("???");
                    }
                }
            }

            /* Crew selectedCrew = null;   Selecting and make a action with the crew member inside the hood selection

              Console.WriteLine("Select a crew member: 1-Yes 2-No");
              int selectOrNo = YesorNoInput();

              if(selectOrNo == 1)
              {
                 Console.WriteLine("Select the crew");
                  int crewIndexSelected = Input.ReadInt("Type the index number");

                  while (crewIndexSelected < 0 && crewIndexSelected > human.PlayerCrew.Count)
                  {
                      Console.WriteLine("Invalid choice.");
                      crewIndexSelected = Input.ReadInt("Type the index of the crew member:");
                  }
                  foreach (Crew crew in human.PlayerCrew)
                  {
                      if (crewIndexSelected == crew.CrewID)
                      {
                          selectedCrew = crew;
                      }
                  }


              }
              else
              {
                  Console.WriteLine("Exiting selection");
                  Console.ReadKey();
              }


              */
        }


        public int YesorNoInput()
        {
            int choice = Input.ReadInt("1.Yes 2.No");
            //guarantee right input
            while (choice < 1 || choice > 2)
            {
                Console.WriteLine("Invalid Input");
                choice = Input.ReadInt("1.Yes 2.No");
            }
            return choice;
        }
    }

}
