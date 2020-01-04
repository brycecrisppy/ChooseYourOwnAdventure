using System;
using System.Collections.Generic;
using System.Threading;

namespace CoreTools
{
    static class Core 
    {
        public static string Dialogue(List<string> choices, string message, bool continuousInp)
        {
            Console.WriteLine(message);

            string selectedChoice;

            while (true)
            {
                string inp;
                if (continuousInp) 
                {
                    ConsoleKeyInfo cki = new ConsoleKeyInfo();
                    while (Console.KeyAvailable == false) 
                    {
                        Thread.Sleep(250);
                    }

                    cki = Console.ReadKey(true);

                    inp = cki.Key.ToString();
                }
                else 
                {
                    inp = Console.ReadLine();
                }
                Console.WriteLine(inp);
                
                List<string> inpArray = new List<string>();
 
                for (int i=0; i<choices.Count; i++)
                {
                    if (choices[i].ToLower().StartsWith(inp.ToLower()))
                    {
                        inpArray.Add(choices[i]);
                    }
                }

                if (inpArray.Count == 0)
                {
                    Console.WriteLine("Invalid choice");
                }
                else if (inpArray.Count == 1)
                {
                    selectedChoice = inpArray[0].ToLower();
                    break;
                }
                else
                {
                    Console.WriteLine("Which of the following did you mean: ");
                    for (int i=0; i<inpArray.Count; i++)
                    {
                        Console.WriteLine(inpArray[i]);
                    }
                }
            }
            return selectedChoice;
        }
    }   
}