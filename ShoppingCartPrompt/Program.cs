using System;
using System.Collections.Generic;

namespace ShoppingCartPrompt
{
    class Program
    {        

        static void Main(string[] args)
        {
            Cart c = new Cart();
            string input;

            Console.WriteLine("Enter your selection or type 'exit' to close.");

            while ((input = Console.ReadLine()) != "exit")
            {
                if (input == "clear")
                {
                    c.clearContents();

                    Console.WriteLine("Enter next order or type 'exit' to close.");
                }
                else if (input == "print")
                {
                    Console.WriteLine(c.printContents());

                    Console.WriteLine("Enter next order, type 'clear' to start a new cart, or type 'exit' to close.");

                }
                else
                {

                    c.addContents(input);

                    Console.WriteLine("Order total: " + c.getTotal().ToString());

                    Console.WriteLine("Enter next order, type 'print' to see contents, type 'clear' to start a new cart, or type 'exit' to close.");

                }
            }
            
        }
    }
}
