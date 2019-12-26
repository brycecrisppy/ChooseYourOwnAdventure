#include <iostream>
#include <vector>

class Map
{
    public:
        bool createMap(std::vector<char> level, int height, int width);

        void printMap(int index);

    private:
        size_t size = 0;
        size_t maxSize = 100;

        int levelAmt = 0;

        std::vector<std::vector<char>> levelCollection;
};