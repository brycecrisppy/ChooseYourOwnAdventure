#include "player.cpp"
#include "map.cpp"
#include "tools.cpp"
#include <stdlib.h>

int main()
{
   Player player("Bryce", 'B', 10);
   Map map;

   std::vector<std::vector<char>> customLevel1 = {
      {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
      {'#', '.', '.', '.', '.', '.', '.', '.', '.', '#'},
      {'#', '.', '.', '.', '.', '.', '.', '.', '.', '#'},
      {'#', '.', '.', '.', '.', '.', '.', '.', '.', '#'},
      {'#', '.', '.', '.', '.', '.', '.', '.', '.', '#'},
      {'#', '.', '.', '.', '.', '.', '.', '.', '.', '#'},
      {'#', '.', '.', '.', '.', '.', '.', '.', '.', '#'},
      {'#', '.', '.', '.', '.', '.', '.', '.', '.', '#'},
      {'#', '.', '.', '.', '.', '.', '.', '.', '.', '#'},
      {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
   };

   map.addCustomMap("customLevel1", customLevel1);

   customLevel1 = map.drawEntity(player.name, customLevel1, 2, 2, player.symbol, true);
   map.addCustomMap("customLevel1", customLevel1);

   int x, y;
   for (;;) {
      map.printMap(customLevel1);
      std::vector<std::string> answers = {"North", "East", "South", "West"};
      std::string answer = dialogue(answers, "Which direction would you like to walk: ");

      if (answer == "north") {
         x = -1;
         y = 0;
      } else if (answer == "east") {
         x = 0;
         y = 1;
      } else if (answer == "south") {
         x = 1;
         y = 0;
      } else if (answer == "west") {
         x = 0;
         y = -1;
      }

      int playerX = map.getXPosition(player.name);
      int playerY = map.getYPosition(player.name);

      std::vector<std::vector<char>> mapCopy = map.getMap("customLevel1");
      int mapWidth = mapCopy[0].size();
      int mapHeight = mapCopy.size();

      std::cout << "Player X: " << playerX << " Player Y: " << playerY << "\n";

      if (playerX + x > mapWidth || playerX + x < 1) {
         std::cout << "Sorry, you cannot move this way." << "\n";
      } else if (playerY + y > mapHeight || playerY + y < 1) {
         std::cout << "Sorry, you cannot move this way." << "\n";
      } else {
         customLevel1 = map.drawEntity(player.name, customLevel1, playerX+x, playerY+y, player.symbol, false);

         std::cout << "Moved " << answer <<  " x: " << x << " y: " << y << "\n";
      }

      //printf("\033c");
   }

   return 0;
}