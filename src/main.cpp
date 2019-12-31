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

   std::vector<std::vector<char>> randLevel2 = map.createRandomMap("blankMap1", 10, 10);

   customLevel1 = map.drawEntity(player.name, customLevel1, 2, 2, player.symbol, true);

   for (int i=0; i<=5; i++) {
      printf("\033c");
      customLevel1 = map.drawEntity(player.name, customLevel1, 3, 3, player.symbol, false);

      map.printMap(customLevel1);
      printf("\033c");

      customLevel1 = map.drawEntity(player.name, customLevel1, 4, 4, player.symbol, false);

      map.printMap(customLevel1);
   }



   /*
   General usage of the dialogue function:
   std::vector<std::string> answers = {"Yes", "YEah", "no", "maybe", "I don't know"};
   std::string answer = dialogue(answers, "Can you repeat the question? ");
   std::cout << "Your chosen answer was: " << answer << "\n";
   */

   return 0;
}