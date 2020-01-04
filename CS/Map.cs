using System;
using System.Collections.Generic;

namespace MapStructure 
{
    class Map
    {
        private int size = 0;
        private int maxSize = 100;
        private int levelAmt = 0;

        Dictionary<string, List<List<char>>> levelCollection = new Dictionary<string, List<List<char>>>();

        Dictionary<string, Dictionary<string, int>> entityPositions = new Dictionary<string, Dictionary<string, int>>();

        public void AddCustomMap(string mapName, List<List<char>> map)
        {
            levelCollection[mapName] = map;
        }

        public void PrintMap(List<List<char>> map)
        {
            for (int i=0; i<map.Count; i++)
            {
                for (int j=0; j<map[0].Count; i++)
                {
                    Console.WriteLine(map[i][j]);
                }
                Console.WriteLine("\n");
            }
        }

        public bool WallCollision(int entityX, int entityY, int mapWidth, int mapHeight)
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

        public bool ObjectCollision(List<List<char>> map, int x, int y, char symbol)
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

        public List<List<char>> DrawEntity(string entityName, List<List<char>> map, int x, int y, char symbol, bool initialDraw)
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
                entityPositions[entityName]["x"] = x;
                entityPositions[entityName]["y"] = y;
            }

            return map;
        }
    }
}