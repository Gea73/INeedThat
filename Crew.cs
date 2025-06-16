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
        public int Loyalty { get; set; }
        public int Heat { get; set; }
        public bool Lieutenant { get; set; }
        public bool Captain { get; set; }
        public int MonthsInPrison { get; set; }
        Random random = new Random();
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


        public static void LieutenantReports(Game game, Player player)
        {
            bool AnyLieutenant = false;
            foreach (Crew crew in player.PlayerCrew)
            {
                if (crew.Lieutenant == true)
                {
                    crew.Reports(game, player);
                    AnyLieutenant = true;
                }
            }
            if(AnyLieutenant == false)
            {
                Console.WriteLine("You dont have lieutenants");
                Console.ReadKey();
            }
            game.AlreadyOpenReports = true;
        }
        private void Reports(Game game, Player player)
        {
            if (game.AlreadyOpenReports == true)
            {
                Console.WriteLine("Reports already solved");
                Console.ReadKey();
            }
            else
            {
                Random random = new Random();
                Console.Write($"Lieutenant:{Name} \n");
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
                            else if (crew.CrewID == LastCrewIdUsed(player) - 2 && crew.Heat < 5)
                            {
                                RobberyTeam.Add(crew);
                                Console.WriteLine(crew.Name + "is on the team");
                            }

                        }

                        choice = Input.YesorNoInput();
                        if (RobberyTeam.Count < 1)
                        {
                            Console.WriteLine("Nobody can do this now they are all heated");
                        }


                        else
                        {
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
                        if (Loyalty > 4)
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
                            Console.WriteLine("I founded a attorney that can release out one of our boys for a pack");
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
                                crewToRelease = game.CrewSelection(player);
                                if (crewToRelease.Heat > 5)
                                {
                                    Console.WriteLine($"$15.000 to clean {crewToRelease.Name}");
                                    choice = Input.YesorNoInput();
                                    if (choice == 1 && player.Cash >= 15000)
                                    {
                                        Console.WriteLine("Register cleaned");
                                        crewToRelease.Heat = 0;
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
        private static int LastCrewIdUsed(Player player)
        {
            int lastUsed = 0;
            foreach (Crew crew in player.PlayerCrew)
            {
                if (crew.CrewID > lastUsed)
                {
                    lastUsed = crew.CrewID;
                }
            }
            return lastUsed;
        }
        public void EquipGun(Player player)
        {
            //if the crew have a gun
            if (GunEquip != null)
            {
                Console.WriteLine($"Gun equipped{GunEquip.Name}");
                Console.WriteLine("Remove it?");
                int choice = Input.YesorNoInput();

                if (choice == 1)
                {
                    Gun gunRemoved = GunEquip;
                    GunEquip = null;
                    gunRemoved.UsedBy = null;
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

                    int gunSelected = Input.ReadInt("Type the index of the gun or -1 to cancel:");
                    if (gunSelected == -1)
                    {
                        Console.WriteLine("Exiting");
                    }
                    else
                    {
                        //guarante right input
                        while (gunSelected < 0 || gunSelected > player.GunStock.Count())
                        {
                            Console.WriteLine("Invalid choice.");
                            gunSelected = Input.ReadInt("Type the index of the gun:");
                        }
                        //select the gun based in id
                        foreach (Gun gun in player.GunStock.ToList())
                        {
                            if (gunSelected == gun.GunID)
                            {


                                gun.UsedBy = this;
                                GunEquip = gun;
                                player.GunStock.Remove(gun);
                                Console.WriteLine($"{Name} equipped {GunEquip.Name}");
                                Console.ReadKey();

                            }
                        }
                    }

                }
                Console.ReadKey();
            }

        }
        public void Promote()
        {
            //check if is already promoted
            if (Captain == true || Lieutenant == true)
            {

                Console.WriteLine("This crew member is already a higher rank");
            }
            //is a soldier
            else
            {
                Console.WriteLine("Really want to promote?");
                Console.WriteLine(this);
                int choice = Input.YesorNoInput();
                //guarantee right input

                //promote
                if (choice == 1)
                {
                    Lieutenant = true;
                    Console.WriteLine($"{Name} is a lieutenant now");

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
            int lastCrewID = LastCrewIdUsed(player);
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
    }
}
