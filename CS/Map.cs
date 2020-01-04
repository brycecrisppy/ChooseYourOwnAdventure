using System;
using System.Collections.Generic;

namespace MapStructure 
{
    static class Map
    {
        private static int size = 0;
        private static int maxSize = 100;
        private static int levelAmt = 0;

        private static Dictionary<string, List<List<char>>> levelCollection = new Dictionary<string, List<List<char>>>();

        private static Dictionary<string, Dictionary<string, int>> entityPositions = new Dictionary<string, Dictionary<string, int>>();

        public static List<List<char>> GetMap(string mapName) {return levelCollection[mapName];}

        public static int GetXPosition(string entityName) {return entityPositions[entityName]["x"];}

        public static int GetYPosition(string entityName) {return entityPositions[entityName]["y"];}

        static public void AddCustomMap(string mapName, List<List<char>> map)
        {
            try
            {
                levelCollection[mapName] = map;
            }
            catch (KeyNotFoundException e)
            {
                Console.Write(e);
                levelCollection.Add(mapName, map);
            }

        }

        static public void PrintMap(List<List<char>> map)
        {
            for (int i=0; i<map.Count; i++)
            {
                for (int j=0; j<map[0].Count; j++)
                {
                    string mapChar = " {0} ";
                    mapChar = string.Format(mapChar, map[i][j]);
                    Console.Write(mapChar);
                }
                Console.WriteLine("");
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

        static public bool ObjectCollision(List<List<char>> map, int x, int y, char symbol)
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

        static public List<List<char>> DrawEntity(string entityName, List<List<char>> map, int x, int y, char symbol, bool initialDraw)
        {
            if (!initialDraw) 
            {
                map[entityPositions[entityName]["x"]][entityPositions[entityName]["y"]] = '.';
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