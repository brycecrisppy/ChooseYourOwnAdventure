using MapStructure;
using CoreTools;
using Entity;
using System;
using System.Collections.Generic;

namespace textAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Bryce", 'B', 10);

            List<List<char>> customLevel1 = new List<List<char>>();
            customLevel1.Add(new List<char>() {'#', '.', '#', '#', '#', '#', '#', '#', '#', '#'});
            customLevel1.Add(new List<char>() {'#', '.', '.', '.', '#', '.', '#', '.', '.', '#'});
            customLevel1.Add(new List<char>() {'#', '.', '.', '.', '#', '.', '.', '.', '.', '#'});
            customLevel1.Add(new List<char>() {'#', '.', '.', '.', '#', '.', '#', '.', '.', '#'});
            customLevel1.Add(new List<char>() {'#', '.', '.', '.', '#', '.', '#', '.', '#', '#'});
            customLevel1.Add(new List<char>() {'#', '.', '#', '#', '#', '.', '#', '.', '#', '#'});
            customLevel1.Add(new List<char>() {'#', '.', '#', '.', '.', '.', '#', '.', '#', '#'});
            customLevel1.Add(new List<char>() {'#', '.', '.', '.', '.', '.', '#', '.', '#', '#'});
            customLevel1.Add(new List<char>() {'#', '.', '#', '.', '.', '.', '#', '.', '.', '.'});
            customLevel1.Add(new List<char>() {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'});

            Map.AddCustomMap("customLevel1", customLevel1);
            customLevel1 = Map.DrawEntity(player.name, customLevel1, 0, 1, player.symbol, true);
            Map.AddCustomMap("customLevel1", customLevel1);

            int x = 0;
            int y = 0;
            while (true)
            {
                Map.PrintMap(customLevel1);
                List<string> answers = new List<string>() {"N", "E", "S", "W"};
                string answer = Core.Dialogue(answers, "Which direction would you like to walk?", true);

                if (answer == "north") 
                {
                    x = -1;
                    y = 0;
                } 
                else if (answer == "east") 
                {
                    x = 0;
                    y = 1;
                } 
                else if (answer == "south") 
                {
                    x = 1;
                    y = 0;
                } 
                else if (answer == "west") 
                {
                    x = 0;
                    y = -1;
                }

                int playerX = Map.GetXPosition(player.name);
                int playerY = Map.GetYPosition(player.name);

                List<List<char>> mapCopy = Map.GetMap("customLevel1");

                int mapWidth = mapCopy[0].Count;
                int mapHeight = mapCopy.Count;

                if (Map.WallCollision(playerX+x, playerY+y, mapWidth, mapHeight))
                {
                    Console.WriteLine("Sorry, you cannot move this way.");
                }
                else if (Map.ObjectCollision(customLevel1, playerX+x, playerY+y, '#'))
                {
                    Console.WriteLine("Sorry, you cannot move this way.");
                }
                else 
                {
                    customLevel1 = Map.DrawEntity(player.name, customLevel1, playerX+x, playerY+y, player.symbol, false);
                    Map.AddCustomMap("customLevel1", customLevel1);
                }
            }   
        }
    }
}
