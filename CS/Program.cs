using System.Security.AccessControl;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using MapStructure;
using CoreTools;
using Entity;

using System;
using PConsole = System.Console; 
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using MRectangle = Microsoft.Xna.Framework.Rectangle;
using MColor = Microsoft.Xna.Framework.Color;

using SadConsole;
using SConsole = SadConsole.Console;

namespace SadConsoleGame
{
    class Program
    {
        static void ConsoleGame()
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
                
                List<string> answers = new List<string>() {"w", "d", "s", "a"};
                string answer = Core.Dialogue(answers, "Which direction would you like to walk?", true);

                PConsole.Write(answer);

                int modX; 
                int modY;

                if (answer == "w") 
                {
                    modX = -1;
                    modY = 0;
                } 
                else if (answer == "d") 
                {
                    modX = 0;
                    modY = 1;
                } 
                else if (answer == "s") 
                {
                    modX = 1;
                    modY = 0;
                } 
                else if (answer == "a") 
                {
                    modX = 0;
                    modY = -1;
                }
                else
                {
                    modX = 0;
                    modY = 0;
                }


                string xyPos = "X: {0} | Y: {1}";
                xyPos = string.Format(xyPos, modX, modY);
                PConsole.WriteLine(xyPos);

                int playerX = Map.GetXPosition(player.name);
                int playerY = Map.GetYPosition(player.name);
                string pos = "pX: {0} | pY: {1}";
                pos = string.Format(pos, playerX, playerY);
                PConsole.WriteLine(pos);

                List<List<char>> mapCopy = Map.GetMap("customLevel1");

                int mapWidth = mapCopy[0].Count;
                int mapHeight = mapCopy.Count;

                if (Map.WallCollision(playerX+modX, playerY+modY, mapWidth, mapHeight))
                {
                    PConsole.WriteLine("Wall! Sorry, you cannot move this way.");
                }
                else if (Map.ObjectCollision(customLevel1, playerX+modX, playerY+modY, '#'))
                {
                    PConsole.WriteLine("Object! Sorry, you cannot move this way.");
                }
                else 
                {
                    customLevel1 = Map.DrawEntity(player.name, customLevel1, playerX+modX, playerY+modY, player.symbol, false);
                    Map.AddCustomMap("customLevel1", customLevel1);
                }
            }   
        }

        static void Init()
        {
            SConsole sconsole = new SConsole(80, 25);
            sconsole.FillWithRandomGarbage();
            sconsole.Fill(
                new MRectangle(3, 3, 23, 3), MColor.Violet, MColor.Black, 0, 0 
            );
            sconsole.Print(4, 4, "Hello World!");

            SadConsole.Global.CurrentScreen = sconsole;
        }

        static void Main(string[] args)
        {
            // Run console version of the game.
            //ConsoleGame();

            // Run SadConsole version of the game.
            SadConsole.Game.Create(80, 25);

            SadConsole.Game.OnInitialize = Init;

            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();

        }
    }
}