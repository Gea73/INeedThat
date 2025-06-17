using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INeedThat
{
    public class Market
    {

        public int lastDice = 0;
        public int lastQuantity = 0;
        public bool AlreadyOpenMarket = false;
        public bool AlreadyBought = false;
        public void GunMarket(Game game, Player player)
        {
            if (AlreadyBought == true)
            {
                Console.WriteLine("You already bought this turn");
            }
            else
            {
                int lastGunId = Gun.LastGunIdUsed(player);
                int quantity = 0;
                Random rand = new Random();
                int dice = 0;
                int cost = 0;
                Console.WriteLine("Gun available in the market");
                quantity = rand.Next(1, 20 + 1);
                dice = rand.Next(1, 10 + 1);

                if (AlreadyOpenMarket == true)
                {
                    dice = lastDice;
                    quantity = lastQuantity;
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
                            AlreadyOpenMarket = true;
                            lastDice = dice;
                            lastQuantity = quantity;
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
                            AlreadyOpenMarket = true;
                            lastDice = dice;
                            lastQuantity = quantity;
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
                            AlreadyOpenMarket = true;
                            lastDice = dice;
                            lastQuantity = quantity;
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
                            AlreadyOpenMarket = true;
                            lastDice = dice;
                            lastQuantity = quantity;
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
                            AlreadyOpenMarket = true;
                            lastDice = dice;
                            lastQuantity = quantity;
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
                            AlreadyOpenMarket = true;
                            lastDice = dice;
                            lastQuantity = quantity;
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
                            AlreadyOpenMarket = true;
                            lastDice = dice;
                            lastQuantity = quantity;
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
                            AlreadyOpenMarket = true;
                            lastDice = dice;
                            lastQuantity = quantity;
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
                            AlreadyOpenMarket = true;
                            lastDice = dice;
                            lastQuantity = quantity;
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
                            AlreadyOpenMarket = true;
                            lastDice = dice;
                            lastQuantity = quantity;
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
