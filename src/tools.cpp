#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
//#include <cctype>

std::string dialogue(std::vector<std::string> choices, std::string message)
{
    std::string selectedChoice;

    std::cout << message << "\n";

    for (int i=0; i<choices.size(); i++) {
        std::transform(choices[i].begin(), choices[i].end(), choices[i].begin(),
        [](unsigned char c) {
            return std::tolower(c);
            }
        );
    }

    while(true) {
        std::string inp;
        std::cin >> inp;

        std::transform(inp.begin(), inp.end(), inp.begin(),
        [](unsigned char c) {
            return std::tolower(c);
            }
        );

        std::vector<std::string> inpArray;

        for(int i=0; i<choices.size(); i++) {
            if (choices[i].find(inp) == 0) {
                inpArray.push_back(choices[i]);
            }
        }

        if (inpArray.size() == 0) {
            std::cout << "Invalid choice\n";
        } else if (inpArray.size() == 1) {
            selectedChoice = inpArray[0];
            break;
        } else {
            std::cout << "Which of the following did you mean: \n";
            for (int i=0; i<inpArray.size(); i++) {
                std::cout << inpArray[i] << "\n";
            }
        }
    }

    return selectedChoice;
}