#include <string>

class Player
{
    public:
        Player(std::string name, int health);

    private:
        std::string name;
        int health;
};