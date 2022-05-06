#include <iostream>
#include "Creature.h"
#include "Room.h"
#include "ConsoleManager.h"

int main() {
    ConsoleManager CM;
    CM.BeginSurvival();
    CM.reprint();
    while(ConsoleManager::survivalIsActive)CM.reprint();
    CM.timeThread.join();
    CM.escapeThread.join();
    for(int i=0;i<ConsoleManager::creatureList.size();i++)
    {
        ConsoleManager::creatureList[i]->creatureThread.join();
    }
    endwin();
    return 0;
}