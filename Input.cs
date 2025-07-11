﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INeedThat
{
    public class Input
    {

        public static int ReadInt(string text)
        {
            int result = 0;

            Console.WriteLine(text);
            string input = Console.ReadLine();
            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("Invalid Value");
                input = Console.ReadLine();
            }
            // dont exit until get a valid int
            return result;
        }

        public static string ReadString(string text)
        {


            Console.WriteLine(text);
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Null or empty");
                input = Console.ReadLine();
            }

            return input;
        }


        public static int YesorNoInput()
        {
            int choice = ReadInt("1.Yes 2.No");
            //guarantee right input
            while (choice < 1 || choice > 2)
            {
                Console.WriteLine("Invalid Input");
                choice = ReadInt("1.Yes 2.No");
            }
            return choice;
        }
    }
}
