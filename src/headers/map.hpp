#include <iostream>
#include <vector>

class Map
{
    public:
        Map();

        std::vector<std::vector<char>> createMap(int rows, int cols);

        void printMap(std::vector<std::vector<char>> map);

    private:
        size_t size = 0;
        size_t maxSize = 100;

        int levelAmt = 0;

        std::vector<std::vector<std::vector<char>>> levelCollection;
};