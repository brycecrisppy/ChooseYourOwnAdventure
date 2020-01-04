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
            customLevel1 = Map.DrawEntity(player.name, customLevel1, 1, 1, player.symbol, true);
            Map.AddCustomMap("customLevel1", customLevel1);

            while (true)
            {
                Map.PrintMap(customLevel1);
                
                List<string> answers = new List<string>() {"N", "E", "S", "W"};
                string answer = Core.Dialogue(answers, "Which direction would you like to walk?", true);

                Console.Write(answer);

                int modX; 
                int modY;

                if (answer == "n") 
                {
                    modX = -1;
                    modY = 0;
                } 
                else if (answer == "e") 
                {
                    modX = 0;
                    modY = 1;
                } 
                else if (answer == "s") 
                {
                    modX = 1;
                    modY = 0;
                } 
                else if (answer == "w") 
                {
                    modX = 0;
                    modY = -1;
                }
                else
                {
                    modX = 5;
                    modY = 5;
                }


                string xyPos = "X: {0} | Y: {1}";
                xyPos = string.Format(xyPos, modX, modY);
                Console.WriteLine(xyPos);

                int playerX = Map.GetXPosition(player.name);
                int playerY = Map.GetYPosition(player.name);
                string pos = "pX: {0} | pY: {1}";
                pos = string.Format(pos, playerX, playerY);
                Console.WriteLine(pos);

                List<List<char>> mapCopy = Map.GetMap("customLevel1");

                int mapWidth = mapCopy[0].Count;
                int mapHeight = mapCopy.Count;

                if (Map.WallCollision(playerX+modX, playerY+modY, mapWidth, mapHeight))
                {
                    Console.WriteLine("Wall! Sorry, you cannot move this way.");
                }
                else if (Map.ObjectCollision(customLevel1, playerX+modX, playerY+modY, '#'))
                {
                    Console.WriteLine("Object! Sorry, you cannot move this way.");
                }
                else 
                {
                    customLevel1 = Map.DrawEntity(player.name, customLevel1, playerX+modX, playerY+modY, player.symbol, false);
                    Map.AddCustomMap("customLevel1", customLevel1);
                }
            }   
        }
    }
}
