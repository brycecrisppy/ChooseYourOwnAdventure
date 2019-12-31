#include <vector>
#include <string>

class Player
{
    public:
        std::string name;
        char symbol;
        Player(std::string name, char symbol, int health);

    private:
        int health; 
};