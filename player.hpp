#include <string>
#include <iostream>
#include <vector>
#include <algorithm>
#include <cctype>

class Player
{
    public:
        Player(std::string name, int health);

        std::string dialogue(std::vector<std::string> choices, std::string message);

    private:
        std::string name;
        int health;
};