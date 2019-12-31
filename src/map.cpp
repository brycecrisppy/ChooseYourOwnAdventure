#include "./headers/map.hpp"

std::vector<std::vector<char>> Map::createRandomMap(std::string mapName, int rows, int cols) 
{
    std::vector<std::vector<char>> map;
    map.resize(rows, std::vector<char>(cols, '.'));

    levelCollection[mapName] = map;

    return map;
}

void Map::addCustomMap(std::string mapName, std::vector<std::vector<char>> map)
{
    levelCollection[mapName] = map;
}

void Map::printMap(std::vector<std::vector<char>> map)
{
    for (int i=0; i<map.size(); i++) {
        for (int j=0; j<map[0].size(); j++) {
            std::cout << map[i][j];
        }
        std::cout << "\n";
    }
}

std::vector<std::vector<char>> Map::drawEntity(std::string entityName, std::vector<std::vector<char>> map, int x, int y, char symbol, bool initialDraw)
{
    if (!initialDraw) {
        map[entityPositions[entityName]["x"]][entityPositions[entityName]["y"]] = '.';
        map[x][y] = symbol;
        entityPositions[entityName]["x"] = x;
        entityPositions[entityName]["y"] = y;
    } else {
        map[x][y] = symbol;
        entityPositions[entityName]["x"] = x;
        entityPositions[entityName]["y"] = y; 
    }

    return map;
}