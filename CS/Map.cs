using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SadConsole;
using SConsole = SadConsole.Console;
using MColor = Microsoft.Xna.Framework.Color;

namespace MapStructure 
{
    static class Map
    {
        private static int size = 0;
        private static int maxSize = 100;
        private static int levelAmt = 0;

        public static SConsole parentMapConsole = new SConsole(80, 25);

        private static Dictionary<string, List<List<Cell>>> levelCollection = new Dictionary<string, List<List<Cell>>>();

        private static Dictionary<string, Dictionary<string, int>> entityPositions = new Dictionary<string, Dictionary<string, int>>();

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
    }
}