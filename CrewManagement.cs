using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace INeedThat
{
    public class CrewManagement
    {
        Random random = new Random();
        public bool AlreadyOpenReports = false;
        public void LieutenantReports(Player player)
        {
            bool AnyLieutenant = false;
            foreach (Crew crew in player.PlayerCrew)
            {
                if (crew.Lieutenant)
                {
                    Reports(crew, player);
                    AnyLieutenant = true;
                }
            }
            if (AnyLieutenant == false)
            {
                Console.WriteLine("You dont have lieutenants");
                Console.ReadKey();
            }
            AlreadyOpenReports = true;
        }
        private void Reports(Crew crewmember, Player player)
        {
            if (AlreadyOpenReports == true)
            {
                Console.WriteLine("Reports already solved");
                Console.ReadKey();
            }
            else
            {

                Console.Write($"Lieutenant:{crewmember.Name} \n");
                int dice = random.Next(1, 10 + 1);


                switch (dice)
                {
                    case 1:
                        Console.WriteLine("We can burn some houses to make the witness");
                        int choice = Input.YesorNoInput();
                        if (choice == 1)
                        {
                            foreach (Crew crew in player.PlayerCrew)
                            {
                                if (crew.Heat > 4)
                                {
                                    crew.Heat -= 5;
                                    Console.Write($"{crew.Name} Heat reduced to {crew.Heat} :");
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Nothing Done");
                        }


                        break;
                    case 2:
                        Console.WriteLine("We can make some stacks in a robbery");
                        List<Crew> RobberyTeam = new List<Crew>();

                        foreach (Crew crew in player.PlayerCrew)
                        {
                            if (crew.Heat == 0)
                            {
                                RobberyTeam.Add(crew);
                                Console.WriteLine(crew.Name + " is on the team");
                            }
                            else if (crew.CrewID == Crew.LastCrewIdUsed(player) - 2 && crew.Heat < 5)
                            {
                                RobberyTeam.Add(crew);
                                Console.WriteLine(crew.Name + "is on the team");
                            }

                        }
                        if (RobberyTeam.Count < 1)
                        {
                            Console.WriteLine("Nobody can do this now they are all heated");
                        }
                        else
                        {
                            choice = Input.YesorNoInput();

                            if (choice == 1)
                            {
                                int robberyProfit = 1500 * RobberyTeam.Count;
                                foreach (Crew crew in RobberyTeam)
                                {
                                    crew.Heat += 5;
                                }
                                Console.WriteLine($"We got {robberyProfit} from the heist boss but our team get some heat");
                                player.Cash += robberyProfit;
                            }
                            else
                            {
                                Console.WriteLine("Nothing Done");
                            }
                        }

                        break;
                    case 3:
                        List<Crew> traitorsList = new List<Crew>();
                        if (crewmember.Loyalty > 4)
                        {
                            foreach (Crew crew in player.PlayerCrew)
                            {
                                if (crew.Loyalty <= 1)
                                {
                                    traitorsList.Add(crew);
                                }
                            }
                            if (traitorsList.Count > 0)
                            {
                                Console.WriteLine("I find these bastards betraying us kill them?");
                                foreach (Crew crew in traitorsList)
                                {
                                    Console.WriteLine(crew.Name);

                                }
                                choice = Input.YesorNoInput();
                                if (choice == 1)
                                {
                                    foreach (Crew crew in traitorsList.ToList())
                                    {
                                        Console.WriteLine($"We killed {crew.Name}");
                                        player.PlayerCrew.Remove(crew);

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Okay lets give them one more chance");
                                }
                            }
                            else
                            {
                                Console.WriteLine("I looking for some rats in our crew");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Nothing happen at all");
                        }
                        break;
                    case 4:
                        Crew crewToRelease = null;
                        foreach (Crew crew in player.InPrisonCrew)
                        {
                            if (crewToRelease == null && crew.Heat < 7)
                            {
                                crewToRelease = crew;
                            }
                        }
                        if (crewToRelease != null)
                        {
                            Console.WriteLine($"I founded a attorney that can release out {crewToRelease.Name} for a pack");
                            Console.WriteLine("$15.000 to release");
                            choice = Input.YesorNoInput();

                            if (choice == 1 && player.Cash >= 15000)
                            {
                                crewToRelease.MonthsInPrison = 0;
                                player.Cash -= 15000;
                                Console.WriteLine($"{crewToRelease.Name} will be released");
                            }
                            else
                            {
                                Console.WriteLine("Nothing done");
                            }
                        }
                        else
                        {
                            Console.WriteLine("I founded a attorney that can clean some registers");
                            {
                                crewToRelease = CrewSelection(player);
                                if (crewToRelease.Heat > 5)
                                {
                                    Console.WriteLine($"$15.000 to clean {crewToRelease.Name}");
                                    choice = Input.YesorNoInput();
                                    if (choice == 1 && player.Cash >= 15000)
                                    {
                                        Console.WriteLine("Register cleaned");
                                        crewToRelease.Heat = 0;
                                        player.Cash -= 15000;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nothing done");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"$7.000 to clean {crewToRelease.Name}");
                                    choice = Input.YesorNoInput();
                                    if (choice == 1 && player.Cash >= 7000)
                                    {
                                        Console.WriteLine("Register cleaned");
                                        crewToRelease.Heat = 0;
                                        player.Cash -= 7000;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nothing done");
                                    }
                                }
                            }
                        }

                        break;
                    case 5:
                        Console.WriteLine("I got a contact that have some sticks to sell");
                        Console.WriteLine("5 .38 revolvers for $3.500");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= 3500)
                        {
                            player.Cash = player.Cash - 3500;
                            int lastGunId = Gun.LastGunIdUsed(player);
                            for (int i = 1; i <= 5; i++)
                            {
                                Gun gun = new Gun("Revolver .38", 3, lastGunId + i);
                                player.GunStock.Add(gun);

                            }
                            Console.WriteLine("Added to our arsenal");
                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                        }

                        break;
                    case 6:
                        Console.WriteLine("Hey boss maybe you can give some money to us,we deserve a bonus for all our work");
                        Console.Write("Give $20.000? ");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= 20000)
                        {
                            foreach (Crew crew in player.PlayerCrew)
                            {
                                crew.Loyalty += 1;
                            }
                            Console.WriteLine("Loyalty increased for all members");
                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                        }



                        break;
                    case 7:
                        Console.WriteLine("Sup boss i found a Armenian that want to show something you maybe want");
                        Console.Write("3 MP5 for $15.000? ");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= 15000)
                        {
                            int lastGunId = Gun.LastGunIdUsed(player);

                            for (int i = 1; i <= 3; i++)
                            {
                                Gun gun = new Gun("MP5", 9, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                            Console.WriteLine("Guns bought");
                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                        }


                        break;
                    case 8:
                        Console.WriteLine("Boss maybe we can send some gifs to make our guys behind bars more loyal");
                        Console.Write("$15.000 ");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= 15000)
                        {
                            player.Cash -= 15000;
                            foreach (Crew crew in player.InPrisonCrew)
                            {
                                crew.Loyalty += 1;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                        }


                        break;
                    case 9:
                        Console.WriteLine("Sup boss i found a guy wanting to buy some guns");
                        Console.Write("He is offering $1.000 for low caliber guns and $5.000 ");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.GunStock.Count > 0)
                        {
                            int gunSellProfit = 0;
                            foreach (Gun gun in player.GunStock.ToList())
                            {

                                if (gun.Firepower >= 7)
                                {
                                    player.Cash += 5000;
                                    player.GunStock.Remove(gun);
                                    gunSellProfit += 5000;
                                }
                                else
                                {
                                    player.Cash += 1000;
                                    player.GunStock.Remove(gun);
                                    gunSellProfit += 1000;
                                }
                            }
                            Console.WriteLine("We earned a stack:" + gunSellProfit);
                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                        }


                        break;
                    case 10:
                        int averageLoyalty = 0;
                        foreach (Crew crew in player.PlayerCrew)
                        {
                            averageLoyalty += crew.Loyalty;

                        }
                        averageLoyalty = averageLoyalty / player.PlayerCrew.Count;

                        if (averageLoyalty > 5)
                        {
                            Console.WriteLine("We are always ride for you boss");
                        }
                        else
                        {
                            Console.WriteLine("I think we have some snakes in the gang");
                        }

                        break;

                }
                Console.ReadKey();


            }
        }
        public void EquipGun(Player player, Crew crewmember)
        {
            //if the crew have a gun
            if (crewmember.GunEquip != null)
            {
                Console.WriteLine($"Gun equipped{crewmember.GunEquip.Name}");
                Console.WriteLine("Remove it?");
                int choice = Input.YesorNoInput();

                if (choice == 1)
                {
                    Gun gunRemoved = crewmember.GunEquip;
                    crewmember.GunEquip = null;
                    gunRemoved.UsedBy = null;
                    player.GunStock.Add(gunRemoved);
                    Console.WriteLine($"Gun {gunRemoved.Name} back to the stock");

                }
                //have changed the mind
                else
                {

                    Console.WriteLine("Nothing done");

                }

            }
            //if dont have a gun equipped
            else
            {
                if (player.GunStock.Count < 1)
                {
                    Console.WriteLine("None guns in stock");
                }
                else
                {
                    Console.WriteLine("Guns Avaliable:");
                    //show guns in stock
                    foreach (Gun gun in player.GunStock)
                    {
                        Console.WriteLine($"{gun.GunID}." + gun);
                    }

                    int gunIdSelected = Input.ReadInt("Type the index of the gun or -1 to cancel:");
                    if (gunIdSelected == -1)
                    {
                        Console.WriteLine("Exiting");
                    }
                    else
                    {
                        //guarante right input
                        Gun selectedGun = player.GunStock.FirstOrDefault(g => g.GunID == gunIdSelected);

                        if (selectedGun != null)
                        {
                            selectedGun.UsedBy = crewmember;
                            crewmember.GunEquip = selectedGun;
                            player.GunStock.Remove(selectedGun);
                            Console.WriteLine($"{crewmember.Name} equipped {crewmember.GunEquip.Name}.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid gun ID or gun not found in stock. Nothing done.");
                        }
                    }
                }
            }
            Console.ReadKey();
        }
        public void Promote(Crew crewmember)
        {
            //check if is already promoted
            if (crewmember.Captain || crewmember.Lieutenant)
            {

                Console.WriteLine("This crew member is already a higher rank");
            }
            //is a soldier
            else
            {
                Console.WriteLine("Really want to promote?");
                Console.WriteLine(crewmember.Name);
                int choice = Input.YesorNoInput();
                //guarantee right input

                //promote
                if (choice == 1)
                {
                    crewmember.Lieutenant = true;
                    Console.WriteLine($"{crewmember.Name} is a lieutenant now");

                }
                //changed mind
                else
                {
                    Console.WriteLine("Nothing done");

                }

            }
            Console.ReadKey();
        }
        public void RecruitCrew(Game game, Player player)
        {
            int lastCrewID = Crew.LastCrewIdUsed(player);
            Crew crew1 = new Crew(NameRandom(), player, null, AttributeRandom(), AttributeRandom(), AttributeRandom(), 5, lastCrewID + 1);
            Crew crew2 = new Crew(NameRandom(), player, null, AttributeRandom(), AttributeRandom(), AttributeRandom(), 5, lastCrewID + 2);
            Crew crew3 = new Crew(NameRandom(), player, null, AttributeRandom(), AttributeRandom(), AttributeRandom(), 5, lastCrewID + 3);

            if (player.Respect <= 0 || player.Cash <= 3000)
            {
                Console.WriteLine("Nobody want to join our gang");
            }
            else if (player.Respect <= 3)
            {
                Console.WriteLine("These boy want to join our crew");
                Console.WriteLine(crew1.Name);
                Console.WriteLine("Recruit?");
                int choice = Input.YesorNoInput();
                if (choice == 1)
                {
                    player.PlayerCrew.Add(crew1);
                    Console.WriteLine(crew1 + "Added to our crew");
                }
                else
                {
                    Console.WriteLine("Nothing done");
                }
            }
            else if (player.Respect <= 5)
            {
                Console.WriteLine("These boys want to join our crew");
                Console.WriteLine(crew1.Name);
                Console.WriteLine(crew2.Name);
                Console.WriteLine("Recruit?");
                int choice = Input.YesorNoInput();
                if (choice == 1)
                {
                    player.PlayerCrew.Add(crew1);
                    player.PlayerCrew.Add(crew2);
                    Console.WriteLine(crew1 + "Added to our crew");
                    Console.WriteLine(crew2 + "Added to our crew");
                }
                else
                {
                    Console.WriteLine("Nothing done");
                }

            }
            else
            {
                Console.WriteLine("These boys want to join our crew");
                Console.WriteLine(crew1.Name);
                Console.WriteLine(crew2.Name);
                Console.WriteLine(crew3.Name);
                Console.WriteLine("Recruit?");
                int choice = Input.YesorNoInput();
                if (choice == 1)
                {
                    player.PlayerCrew.Add(crew1);
                    player.PlayerCrew.Add(crew2);
                    player.PlayerCrew.Add(crew3);
                    Console.WriteLine(crew1 + "Added to our crew");
                    Console.WriteLine(crew2 + "Added to our crew");
                    Console.WriteLine(crew3 + "Added to our crew");
                }
                else
                {
                    Console.WriteLine("Nothing done");
                }
            }
            Console.ReadKey();
        }
        private string NameRandom()
        {
            string newName = null;
            string name1, name2;
            List<string> names = new List<string>  {
        "João", "Carlos", "Mateus", "Rafael", "Marcos",
        "Lucas", "Pedro", "Bruno", "André", "Tiago",
        "Gustavo", "Fernando", "Vinícius", "Henrique", "Eduardo",
        "Paulo", "Felipe", "Igor", "Diego", "Renan","Silva", "Santos", "Oliveira", "Souza", "Lima",
        "Ferreira", "Costa", "Rodrigues", "Almeida", "Nascimento",
        "Gomes", "Barbosa", "Martins", "Araujo", "Pereira",
        "Cardoso", "Ribeiro", "Melo", "Moreira", "Teixeira"
                    };

            List<string> nicknames = new List<string>
    {
        "Piloto", "Madruga", "Do Morro", "Caveira", "Bala Torta",
        "Zero Um", "Cabeça", "Perninha", "X1", "Tranquilo",
        "R3", "Jacaré", "Tubarão", "Urso", "Fumaça",
        "Maozinha", "Coringa", "Branquelo", "Zóio", "Doido", "da Vila Ipê","da Vila Esperança", "do Castelo","do Reolon",
                "da Antena", "do Serrano", "do Desvio Rizzo"
    };
            int dice = random.Next(3);
            switch (dice)
            {
                case 0: // nickname + name
                    name1 = GetRandom(nicknames, random);
                    name2 = GetRandom(names, random);
                    newName = $"{name1} {name2}";
                    break;
                case 1: // name + name
                    name1 = GetRandom(names, random);
                    name2 = GetRandom(names, random);
                    newName = $"{name1} {name2}";
                    break;
                case 2: // nickname + nickname
                    name1 = GetRandom(nicknames, random);
                    name2 = GetRandom(nicknames, random);
                    newName = $"{name1} {name2}";
                    break;
                default:
                    Console.WriteLine("erro na lista");
                    break;
            }
            return newName;
        }
        private static string GetRandom(List<string> list, Random random)
        {
            return list[random.Next(list.Count)];
        }
        private int AttributeRandom()
        {
            int att = 0;
            att = random.Next(1, 11);
            return att;
        }
        public void MoveCrew(Game game, Player player)
        {

            Crew selectedCrew = CrewSelection(player);

            Console.WriteLine("Where you want to move?");
            //if the crew selected dont have position
            if (selectedCrew.Location == null)
            {
                //show all hoods in the game
                foreach (Hood hood in game.GameMap.MapHoods)
                {
                    Console.WriteLine($"{hood.HoodID}.{hood.Name}");
                }


                int moveTo = Input.ReadInt("Type the index of the hood or -1 to exit:");

                if (moveTo == -1)
                {
                    Console.WriteLine("Exiting");
                    Console.ReadKey();
                }
                else
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

        public void SelectCrewMenu(Game game, Player player)
        {


            Crew selectedCrew = CrewSelection(player);


            Console.WriteLine(selectedCrew);
            Console.WriteLine("1.Move Crew");
            Console.WriteLine("2.Equip Gun or remove");
            if (selectedCrew.Lieutenant == false && selectedCrew.Captain == false)
            {
                Console.WriteLine("3.Promote");
            }
            Console.WriteLine("4.Cancel");

            int option = Input.ReadInt("Type the option");
            //guarante right input
            while (option < 1 || option > 4)
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
                    EquipGun(player, selectedCrew);
                    break;

                case 3:
                    Promote(selectedCrew);
                    break;
                case 4:
                    Console.WriteLine("Exiting");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Invalid Value");
                    break;
            }

        }
        public Crew CrewSelection(Player player)
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

            return selectedCrew;
        }
    }
}
