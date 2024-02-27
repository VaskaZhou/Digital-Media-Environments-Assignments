#include <iostream>
#include <conio.h>
#include <thread>
#include <chrono>

int main() {
    char symbol;

    std::cout << "Enter the character to print: ";
    std::cin >> symbol;

    std::cout << "Press any key to stop printing." << std::endl;

    int row = 1;

    // Print the pattern until a key is pressed
    while (!_kbhit()) {
        // Print characters
        for (int i = 1; i <= row; ++i) {
            std::cout << symbol;
        }

        // Move to the next line
        std::cout << std::endl;

        // Increase the row count
        ++row;

        // Pause for one second
        //std::this_thread::sleep_for(std::chrono::seconds(1));
        std::this_thread::sleep_for(std::chrono::milliseconds(200));
    }

    // Clear the input buffer
    while (_kbhit()) {
        _getch();
    }

    return 0;
}
