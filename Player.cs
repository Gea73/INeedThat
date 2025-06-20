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
        public List<Crew> InPrisonCrew { get; set; }

        public List<Crew> InHospitalCrew { get; set; }
        Random random = new Random();
        public Player(string name, int playerid, bool human)
        {
            Name = name;
            Human = human;
            PlayerID = playerid;
            Cash = 100000;
            PlayerCrew = new List<Crew>();
            Respect = 5;
            GunStock = new List<Gun>();
            InPrisonCrew = new List<Crew>();
            InHospitalCrew = new List<Crew>();

        }

        public override string ToString()
        {
            string playercrew = string.Empty;
            string gunstock = string.Empty;
            //defining the strings a list of to strings of crew and guns
            foreach (Crew crew in PlayerCrew)
            {
                playercrew += crew.Name;
                playercrew += ",";
            }
            foreach (Gun gun in GunStock)
            {
                gunstock += gun.Name;
                gunstock += ",";
            }


            return $"Name:{Name} Cash:{Cash} Respect:{Respect} CrewMembers:{playercrew} GunStock:{gunstock}";

        }


        public void EnemyAiPlacement(Game game)
        {
            List<Player> EnemyAis = game.Players.Where(p => p.Human == false).ToList();

            foreach (Player enemy in EnemyAis)
            {
                int IdInitialPlace = random.Next(game.GameMap.MapHoods.Max(h => h.HoodID));
                while (EnemyAis.SelectMany(p => p.PlayerCrew).Where(c => c.Location != null).Any(c => c.Location.HoodID == IdInitialPlace))
                {
                    IdInitialPlace = random.Next(game.GameMap.MapHoods.Max(h => h.HoodID));
                }
                Hood hood = game.GameMap.MapHoods.FirstOrDefault(h => h.HoodID == IdInitialPlace);
                Crew captain = enemy.PlayerCrew.FirstOrDefault(c => c.Captain == true);
                captain.Location = hood;
                Console.WriteLine($"{enemy.Name} started on {hood.Name} with captain {captain.Name}");
            }
            Console.ReadKey();
        }

        public void EnemyAiTurn(Game game, CrewManagement crewManagement)
        {


            foreach (Player player in game.Players)
            {
                if (player.Human == false)
                {
                    if (!player.PlayerCrew.Any(c => c.Captain == true))
                    {
                        Console.WriteLine($"Captain of {player.Name} is gone");

                        Crew newCaptain = player.PlayerCrew.Where(c => c.Loyalty > 0).OrderByDescending(c => c.Loyalty).FirstOrDefault();
                        newCaptain.Captain = true;
                        Console.WriteLine($"{newCaptain.Name} is the new captain of {newCaptain.Aff.Name}");
                    }

                    if (player.Respect <= 3 && player.Cash >= 3000)
                    {
                        crewManagement.RecruitCrewAi(game, player);

                    }
                    else if (player.Respect <= 5)
                    {
                        crewManagement.RecruitCrewAi(game, player);
                        crewManagement.RecruitCrewAi(game, player);

                    }
                    else
                    {
                        crewManagement.RecruitCrewAi(game, player);
                        crewManagement.RecruitCrewAi(game, player);
                        crewManagement.RecruitCrewAi(game, player);
                    }




                }
            }


        }
    }
}
