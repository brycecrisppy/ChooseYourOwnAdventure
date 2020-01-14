using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SadConsole;
using SConsole = SadConsole.Console;
using SadConsole.Components;
using SadConsole.Input;
using MColor = Microsoft.Xna.Framework.Color;

namespace MapStructure 
{
    class Map: ContainerConsole
    {
        private static int size = 0;
        private static int maxSize = 100;
        private static int levelAmt = 0;

        private static Dictionary<string, List<List<Cell>>> levelCollection = new Dictionary<string, List<List<Cell>>>();

        private static Dictionary<string, Dictionary<string, int>> entityPositions = new Dictionary<string, Dictionary<string, int>>();

        public static SConsole parentMapConsole;

        public static List<List<Cell>> GetMap(string mapName) {return levelCollection[mapName];}

        public static int GetXPosition(string entityName) {return entityPositions[entityName]["x"];}

        public static int GetYPosition(string entityName) {return entityPositions[entityName]["y"];}

        static public void AddCustomMap(string mapName, List<List<Cell>> map)
        {
            try
            {
                levelCollection[mapName] = map;
            }
            catch (KeyNotFoundException e)
            {
                System.Console.Write(e);
                levelCollection.Add(mapName, map);
            }

        }

        static public void PrintMap(List<List<Cell>> map)
        {
            for (int i=0; i<map.Count; i++)
            {
                for (int j=0; j<map[0].Count; j++)
                {
                    map[i][j].CopyAppearanceTo(parentMapConsole[i, j]);
                }
                //Console.WriteLine("");
            }
        }

        static public bool WallCollision(int entityX, int entityY, int mapWidth, int mapHeight)
        {
            if (entityX >= mapWidth-1 || entityX < 1) 
            {
                return true;
            } 
            else if (entityY >= mapHeight-1 || entityY < 1) 
            {
                return true;
            } 
            else 
            {
                return false;
            }
        }

        static public bool ObjectCollision(List<List<Cell>> map, int x, int y, Cell symbol)
        {
            if (map[x][y] == symbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public List<List<Cell>> DrawEntity(string entityName, List<List<Cell>> map, int x, int y, Cell symbol, bool initialDraw)
        {
            if (!initialDraw) 
            {
                // TODO Draw entity using cell
                map[entityPositions[entityName]["x"]][entityPositions[entityName]["y"]] = new Cell(MColor.White, MColor.Black, 0);
                map[x][y] = symbol;
                entityPositions[entityName]["x"] = x;
                entityPositions[entityName]["y"] = y;
            } 
            else 
            {
                map[x][y] = symbol;
                entityPositions.Add(entityName, new Dictionary<string, int>());
                entityPositions[entityName].Add("x", x);
                entityPositions[entityName].Add("y", y);
            }

            return map;
        }
        
        public override bool ProcessKeyboard(Keyboard info)
        {
            int modX, modY;

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.W))
            {
                modX = -1;
                modY = 0;
            }
            else if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D))
            {
                modX = 0;
                modY = 1;
            }
            else if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.S))
            {
                modX = 1;
                modY = 0;
            }
            else if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.A))
            {
                modX = 0;
                modY = -1;
            }
            else
            {
                modX = 0;
                modY = 0;
            }

            int playerX = Map.GetXPosition("player");
            int playerY = Map.GetYPosition("player");

            List<List<Cell>> mapList = new List<List<Cell>>();
            mapList = Map.DrawEntity("player", mapList, playerX+modX, playerY+modY, new Cell(MColor.White, MColor.Black, 2), false);
            Map.AddCustomMap("customLevel1", mapList);

            System.Console.WriteLine(info);

            return true;
        }

        public Map()
        {
            List<List<Cell>> customLevel1 = new List<List<Cell>>();

            Cell e = new Cell(MColor.White, MColor.Black, 0);
            Cell w = new Cell(MColor.White, MColor.Black, 192);

            customLevel1.Add(new List<Cell>() {w, e, w, w, w, w, w, w, w, w});
            customLevel1.Add(new List<Cell>() {w, e, e, e, w, e, w, e, e, w});
            customLevel1.Add(new List<Cell>() {w, e, e, e, w, e, e, e, e, w});
            customLevel1.Add(new List<Cell>() {w, e, e, e, w, e, w, e, e, w});
            customLevel1.Add(new List<Cell>() {w, e, e, e, w, e, w, e, w, w});
            customLevel1.Add(new List<Cell>() {w, e, w, w, w, e, w, e, w, w});
            customLevel1.Add(new List<Cell>() {w, e, w, e, e, e, w, e, w, w});
            customLevel1.Add(new List<Cell>() {w, e, e, e, e, e, w, e, w, w});
            customLevel1.Add(new List<Cell>() {w, e, w, e, e, e, w, e, e, e});
            customLevel1.Add(new List<Cell>() {w, w, w, w, w, w, w, w, w, w});

            AddCustomMap("customLevel1", customLevel1);

            parentMapConsole = new SConsole(80, 25);
            parentMapConsole.Parent = this;
        }
    }
}