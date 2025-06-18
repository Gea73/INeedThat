using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INeedThat
{
    public class Combat
    {

        public void StartCombat(Game game, Hood hoodDisputed, Player attacker)
        {

            List<Player> playersInHood = game.Players
    .Where(player => player.PlayerID != attacker.PlayerID && player.PlayerCrew.Any(crew => crew.Location?.HoodID == hoodDisputed.HoodID)).ToList();

            if (!playersInHood.Any())
            {
                Console.WriteLine($"The {attacker.Name} take the hood without a fight!");
                Console.ReadKey();
                return;
            }

            Player defender = playersInHood
                  .OrderByDescending(p => p.PlayerCrew
                      .Where(c => c.Location?.HoodID == hoodDisputed.HoodID)
                      .Sum(c => c.Brutality + (c.GunEquip?.Firepower ?? 0))) // Safely handle null guns
                  .FirstOrDefault();

            if (defender == null)
            {
                Console.WriteLine("No opponent found in this hood.");
                Console.ReadKey();
                return;
            }

            List<Crew> attackerCrewInHood = attacker.PlayerCrew.Where(c => c.Location?.HoodID == hoodDisputed.HoodID).ToList();
            List<Crew> defenderCrewInHood = defender.PlayerCrew.Where(c => c.Location?.HoodID == hoodDisputed.HoodID).ToList();

            if (!attackerCrewInHood.Any() || !defenderCrewInHood.Any())
            {
                Console.WriteLine("One of the sides has no crew in the hood to fight. Combat cancelled.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine($"--- COMBAT START: {attacker.Name} vs. {defender.Name} in {hoodDisputed.Name} ---");
            Console.WriteLine($"{attacker.Name} forces: {attackerCrewInHood.Count} | {defender.Name} forces: {defenderCrewInHood.Count}\n");

            List<Crew> smallerSide = attackerCrewInHood.Count <= defenderCrewInHood.Count ? attackerCrewInHood : defenderCrewInHood;
            List<Crew> largerSide = attackerCrewInHood.Count > defenderCrewInHood.Count ? attackerCrewInHood : defenderCrewInHood;

            int largerSideIndex = 0;
            var casualties = new List<Crew>();
            int baseOpponents = largerSide.Count / smallerSide.Count;
            int extraOpponents = largerSide.Count % smallerSide.Count;

            foreach (Crew crew in smallerSide)
            {

                if (largerSideIndex >= largerSide.Count) break;


                int opponentsToFace = baseOpponents + (extraOpponents > 0 ? 1 : 0);
                extraOpponents = Math.Max(0, extraOpponents - 1);

                var opponents = new List<Crew>();
                for (int i = 0; i < opponentsToFace && largerSideIndex < largerSide.Count; i++)
                {
                    opponents.Add(largerSide[largerSideIndex]);
                    largerSideIndex++;
                }


                int powerSide1 = crew.Brutality + (crew.GunEquip?.Firepower ?? 0);
                int powerSide2 = opponents.Sum(c => c.Brutality + (c.GunEquip?.Firepower ?? 0));
                crew.Heat++;
                opponents.ForEach(c => c.Heat++);

                Console.WriteLine($" {crew.Name} with a {crew.GunEquip.Name ?? "Unarmed"} {powerSide1} fighting against");
                foreach (Crew opponent in opponents)
                {
                    Console.Write($" {opponent.Name} with a {opponent.GunEquip?.Name ?? "Unarmed "} ");
                }
                Console.WriteLine($" with {powerSide2} ");

                int PowerDiference = Math.Abs(powerSide1 - powerSide2);

                if (PowerDiference == 0)
                {
                    Console.WriteLine("They exchange shoots but missed ");
                }
                else if (PowerDiference < 2)
                {
                    Console.WriteLine("He got hitted with a grazing shot ");
                    if (powerSide1 > powerSide2)
                    {
                        foreach (Crew opponent in opponents)
                        {
                            opponent.MonthsWounded += 1;
                        }
                    }
                    else
                    {
                        crew.MonthsWounded += 1;
                    }
                }
                else if (PowerDiference < 3)
                {
                    Console.WriteLine("He got hitted in the foot ");
                    if (powerSide1 > powerSide2)
                    {
                        foreach (Crew opponent in opponents)
                        {
                            opponent.MonthsWounded += 2;
                        }
                    }
                    else
                    {
                        crew.MonthsWounded += 2;
                    }
                }
                else if (PowerDiference < 4)
                {
                    Console.WriteLine("He got hitted in the arm ");
                    if (powerSide1 > powerSide2)
                    {
                        foreach (Crew opponent in opponents)
                        {
                            opponent.MonthsWounded += 3;
                        }
                    }
                    else
                    {
                        crew.MonthsWounded += 3;
                    }
                }
                else
                {
                    Console.WriteLine("He got shotted multiple times");
                    if (powerSide1 > powerSide2)
                    {

                        casualties.AddRange(opponents);
                        opponents.ForEach(op => Console.WriteLine($" {op.Name} is gone."));


                    }
                    else
                    {
                        casualties.Add(crew);
                        Console.WriteLine($"{crew.Name} is gone.");
                    }
                    Console.ReadKey();
                }
            }
            if (casualties.Any())
            {
                foreach (Crew casualty in casualties)
                {
                    // Find the player who owns the casualty and remove them from their crew.
                    Player owner = game.Players.FirstOrDefault(p => p.PlayerID == casualty.Aff.PlayerID);
                    if (owner != null)
                    {
                        owner.PlayerCrew.Remove(casualty);
                    }
                }
            }
            var remainingAttackers = attacker.PlayerCrew.Count(c => c.Location?.HoodID == hoodDisputed.HoodID);
            var remainingDefenders = defender.PlayerCrew.Count(c => c.Location?.HoodID == hoodDisputed.HoodID);

            if (remainingAttackers > 0 && remainingDefenders == 0)
            {
                Console.WriteLine($"The {attacker.Name} have won the battle and taken the hood!");
            }
            else if (remainingDefenders > 0 && remainingAttackers == 0)
            {
                Console.WriteLine($"The {defender.Name} have successfully defended their turf!");
            }
            else
            {
                Console.WriteLine("The battle ends in a bloody stalemate. Neither side could secure the hood.");
            }

            Console.ReadKey();
        }

    }

}




