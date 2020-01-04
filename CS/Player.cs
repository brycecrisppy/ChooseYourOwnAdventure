using System;

namespace Entity
{
    class Player
    {   
        public string name;
        public char symbol;
        int health;

        public Player(string iname, char isymbol, int ihealth)
        {
            name = iname;
            symbol = isymbol;
            health = ihealth;
        }
    }
    
}