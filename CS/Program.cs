using System;
using CoreTools;
using System.Collections.Generic;

namespace textAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> acceptableAnswers = new List<string>() {"Yes", "Yeah", "No", "Nah"};
            string answer = Core.Dialogue(acceptableAnswers, "Can you repeat the questions?", false);
            Console.WriteLine(answer);
        }
    }
}
