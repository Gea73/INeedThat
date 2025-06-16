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

        public static void Market(Game game, Player player)
        {
            if (game.AlreadyBought == true)
            {
                Console.WriteLine("You already bought this turn");
            }
            else
            {
                int lastGunId = LastGunIdUsed(player);
                int quantity = 0;
                Random rand = new Random();
                int dice = 0;
                int cost = 0;
                Console.WriteLine("Gun available in the market");
                quantity = rand.Next(1, 20 + 1);
                dice = rand.Next(1, 10 + 1);

                if (game.AlreadyOpenMarket == true)
                {
                    dice = game.lastDice;
                    quantity = game.lastQuantity;
                }
                switch (dice)
                {

                    case 1:
                        Console.WriteLine($"{quantity} :Revolver .22");
                        cost = quantity * 500;
                        Console.WriteLine("Costing:$" + cost);
                        Console.WriteLine("Buy?");
                        int choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= cost)
                        {
                            player.Cash -= cost;
                            for (int i = 1; i <= quantity; i++)
                            {
                                Gun gun = new Gun("Revolver .22", 2, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                            Console.WriteLine("Guns bought");
                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                            game.AlreadyOpenMarket = true;
                            game.lastDice = dice;
                            game.lastQuantity = quantity;
                        }
                        break;

                    case 2:
                        Console.WriteLine($"{quantity} :Taurus G2 9mm");
                        cost = quantity * 1500;
                        Console.WriteLine("Costing:$" + cost);
                        Console.WriteLine("Buy?");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= cost)
                        {

                            player.Cash -= cost;
                            for (int i = 1; i <= quantity; i++)
                            {
                                Gun gun = new Gun("Taurus G2 9mm", 4, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                            Console.WriteLine("Guns bought");
                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                            game.AlreadyOpenMarket = true;
                            game.lastDice = dice;
                            game.lastQuantity = quantity;
                        }


                        break;

                    case 3:
                        Console.WriteLine($"{quantity} :G19");
                        cost = quantity * 2000;
                        Console.WriteLine("Costing:$" + cost);
                        Console.WriteLine("Buy?");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= cost)
                        {
                            player.Cash -= cost;
                            for (int i = 1; i <= quantity; i++)
                            {
                                Gun gun = new Gun("G19", 5, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                            Console.WriteLine("Guns bought");
                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                            game.AlreadyOpenMarket = true;
                            game.lastDice = dice;
                            game.lastQuantity = quantity;
                        }
                        break;

                    case 4:
                        Console.WriteLine($"{quantity} :Revolver .38");
                        cost = quantity * 1000;
                        Console.WriteLine("Costing:$" + cost);
                        Console.WriteLine("Buy?");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= cost)
                        {

                            player.Cash -= cost;
                            for (int i = 1; i <= quantity; i++)
                            {
                                Gun gun = new Gun("Revolver .38", 3, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                            Console.WriteLine("Guns bought");
                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                            game.AlreadyOpenMarket = true;
                            game.lastDice = dice;
                            game.lastQuantity = quantity;
                        }

                        break;

                    case 5:
                        Console.WriteLine($"{quantity} :Shotgun 12");
                        cost = quantity * 3000;
                        Console.WriteLine("Costing:$" + cost);
                        Console.WriteLine("Buy?");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= cost)
                        {
                            player.Cash -= cost;
                            for (int i = 1; i <= quantity; i++)
                            {
                                Gun gun = new Gun("Shotgun 12", 7, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                            Console.WriteLine("Guns bought");


                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                            game.AlreadyOpenMarket = true;
                            game.lastDice = dice;
                            game.lastQuantity = quantity;
                        }

                        break;

                    case 6:

                        Console.WriteLine($"{quantity} :Knife");
                        cost = quantity * 50;
                        Console.WriteLine("Costing:$" + cost);
                        Console.WriteLine("Buy?");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= cost)
                        {

                            player.Cash -= cost;
                            for (int i = 1; i <= quantity; i++)
                            {
                                Gun gun = new Gun("Knife", 1, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                            Console.WriteLine("Guns bought");

                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                            game.AlreadyOpenMarket = true;
                            game.lastDice = dice;
                            game.lastQuantity = quantity;
                        }

                        break;

                    case 7:
                        Console.WriteLine($"{quantity} :Rifle T4 5.56mm");
                        cost = quantity * 10000;
                        Console.WriteLine("Costing:$" + cost);
                        Console.WriteLine("Buy?");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= cost)
                        {

                            player.Cash -= cost;
                            for (int i = 1; i <= quantity; i++)
                            {
                                Gun gun = new Gun("Rifle T4 5.56mm", 12, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                            Console.WriteLine("Guns bought");

                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                            game.AlreadyOpenMarket = true;
                            game.lastDice = dice;
                            game.lastQuantity = quantity;
                        }

                        break;

                    case 8:

                        Console.WriteLine($"{quantity} :FAL 7.62");
                        cost = quantity * 15000;
                        Console.WriteLine("Costing:$" + cost);
                        Console.WriteLine("Buy?");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= cost)
                        {
                            player.Cash -= cost;
                            for (int i = 1; i <= quantity; i++)
                            {
                                Gun gun = new Gun("FAL 7.62", 14, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                            Console.WriteLine("Guns bought");

                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                            game.AlreadyOpenMarket = true;
                            game.lastDice = dice;
                            game.lastQuantity = quantity;
                        }

                        break;

                    case 9:

                        Console.WriteLine($"{quantity} :AK-47");
                        cost = quantity * 20000;
                        Console.WriteLine("Costing:$" + cost);
                        Console.WriteLine("Buy?");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= cost)
                        {
                            player.Cash -= cost;
                            for (int i = 1; i <= quantity; i++)
                            {
                                Gun gun = new Gun("AK-47", 16, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                            Console.WriteLine("Guns bought");
                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                            game.AlreadyOpenMarket = true;
                            game.lastDice = dice;
                            game.lastQuantity = quantity;
                        }

                        break;

                    case 10:

                        Console.WriteLine($"{quantity} :MP5");
                        cost = quantity * 7000;
                        Console.WriteLine("Costing:$" + cost);
                        Console.WriteLine("Buy?");
                        choice = Input.YesorNoInput();
                        if (choice == 1 && player.Cash >= cost)
                        {
                            player.Cash -= cost;
                            for (int i = 1; i <= quantity; i++)
                            {
                                Gun gun = new Gun("MP5", 9, lastGunId + i);
                                player.GunStock.Add(gun);
                            }
                            Console.WriteLine("Guns bought");

                        }
                        else
                        {
                            Console.WriteLine("Nothing done");
                            game.AlreadyOpenMarket = true;
                            game.lastDice = dice;
                            game.lastQuantity = quantity;
                        }

                        break;
                    default:
                        Console.WriteLine("Error in the dice");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
