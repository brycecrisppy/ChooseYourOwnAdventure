#include "player.cpp"

int main()
{
   Player player("Bryce", 10);

   std::vector<std::string> answers = {"Yes", "YEah", "no", "maybe", "I don't know"};

   std::string answer = player.dialogue(answers, "Can you repeat the question? ");

   std::cout << "Your chosen answer was: " << answer << "\n";

   return 0;
}