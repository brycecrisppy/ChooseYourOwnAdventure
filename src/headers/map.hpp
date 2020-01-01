#include <iostream>
#include <vector>
#include <unordered_map>

class Map
{
    public:
        std::vector<std::vector<char>> createRandomMap(std::string mapName, int rows, int cols);

        void addCustomMap(std::string mapName, std::vector<std::vector<char>> map);

        void printMap(std::vector<std::vector<char>> map);

        int getXPosition(std::string entityName) {return entityPositions[entityName]["x"];}

        int getYPosition(std::string entityName) {return entityPositions[entityName]["y"];}

        std::vector<std::vector<char>> getMap(std::string mapName) {return levelCollection[mapName];}

        std::vector<std::vector<char>> drawEntity(std::string entityName,  std::vector<std::vector<char>> map, int x, int y, char symbol, bool initialDraw);

    private:
        size_t size = 0;
        size_t maxSize = 100;

        int levelAmt = 0;

        std::unordered_map<std::string, std::vector<std::vector<char>>> levelCollection;

        std::unordered_map<std::string, std::unordered_map<std::string, int>> entityPositions;
};