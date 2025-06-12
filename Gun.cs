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

        private static int LastGunIdUsed(Player player)
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

        public static void Market(Game game, Player player)
        {
            int lastGunId = LastGunIdUsed(player);
            int quantity = 0;
            Random rand = new Random();
            int dice = 0;
            int cost = 0;
            Console.WriteLine("Gun available in the market");
            quantity = rand.Next(1, 20 + 1);
            dice = rand.Next(1, 10 + 1);
            switch (dice)
            {

                case 1:
                    Console.WriteLine($"{quantity} :Revolver .22");
                    Console.WriteLine("Costing:" + quantity * 500);
                    Console.WriteLine("Buy?");
                    int choice = game.YesorNoInput();
                    if (choice == 1)
                    {
                        if (player.Cash >= cost)
                        {

                            for (int i = 1; i < quantity; i++)
                            {
                                Gun gun = new Gun("Revolver .22", 2, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Insuficient funds");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nothing done");
                    }
                    break;

                case 2:
                    Console.WriteLine($"{quantity} :Taurus G2 9mm");
                    Console.WriteLine("Costing:" + quantity * 1500);
                    Console.WriteLine("Buy?");
                    choice = game.YesorNoInput();
                    if (choice == 1)
                    {
                        if (player.Cash >= cost)
                        {

                            for (int i = 1; i < quantity; i++)
                            {
                                Gun gun = new Gun("Taurus G2 9mm", 4, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Insuficient funds");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nothing done");
                    }


                    break;

                case 3:
                    Console.WriteLine($"{quantity} :G19");
                    Console.WriteLine("Costing:" + quantity * 2000);
                    Console.WriteLine("Buy?");
                    choice = game.YesorNoInput();
                    if (choice == 1)
                    {
                        if (player.Cash >= cost)
                        {
                            for (int i = 1; i < quantity; i++)
                            {
                                Gun gun = new Gun("G19", 5, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Insuficient funds");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nothing done");
                    }
                    break;

                case 4:
                    Console.WriteLine($"{quantity} :Revolver .38");
                    Console.WriteLine("Costing:" + quantity * 1000);
                    Console.WriteLine("Buy?");
                    choice = game.YesorNoInput();
                    if (choice == 1)
                    {
                        if (player.Cash >= cost)
                        {
                            for (int i = 1; i < quantity; i++)
                            {
                                Gun gun = new Gun("Revolver .38", 3, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Insuficient funds");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nothing done");
                    }

                    break;

                case 5:
                    Console.WriteLine($"{quantity} :Shotgun 12");
                    Console.WriteLine("Costing:" + quantity * 3000);
                    Console.WriteLine("Buy?");
                    choice = game.YesorNoInput();
                    if (choice == 1)
                    {
                        if (player.Cash >= cost)
                        {
                            for (int i = 1; i < quantity; i++)
                            {
                                Gun gun = new Gun("Shotgun 12", 7, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Insuficient funds");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nothing done");
                    }
                    break;

                case 6:

                    Console.WriteLine($"{quantity} :Knife");
                    Console.WriteLine("Costing:" + quantity * 50);
                    Console.WriteLine("Buy?");
                    choice = game.YesorNoInput();
                    if (choice == 1)
                    {
                        if (player.Cash >= cost)
                        {

                            for (int i = 1; i < quantity; i++)
                            {
                                Gun gun = new Gun("Knife", 1, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Insuficient funds");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nothing done");
                    }
                    break;
                case 7:
                    for (int i = 1; i < quantity; i++)
                    {
                        Gun gun = new Gun("Rifle T4 5.56mm", 12, lastGunId + i);
                    }
                    break;
                case 8:
                    for (int i = 1; i < quantity; i++)
                    {
                        Gun gun = new Gun("FAL 7.62", 14, lastGunId + i);
                    }
                    break;
                case 9:
                    for (int i = 1; i < quantity; i++)
                    {
                        Gun gun = new Gun("AK-47", 16, lastGunId + i);
                    }
                    break;
                case 10:
                    for (int i = 1; i < quantity; i++)
                    {
                        Gun gun = new Gun("MP5", 9, lastGunId + i);
                    }
                    break;
                default:
                    Console.WriteLine("Error in the dice");
                    break;
            }

        }
    }
}
