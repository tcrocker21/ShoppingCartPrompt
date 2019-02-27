using System;
using System.Collections.Generic;

namespace ShoppingCartPrompt
{
    class Program
    {        

        static void Main(string[] args)
        {
            Cart c;
            string input;

            Console.WriteLine("Enter your selection or type 'exit' to close.");

            while ((input = Console.ReadLine()) != "exit")
            {                              
                c = new Cart(input);

                Console.WriteLine("Order total: " + c.getTotal().ToString());

                Console.WriteLine("Enter next order or type 'exit' to close.");
            }
            
        }
    }
}
