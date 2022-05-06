//
// Created by wilk on 08.06.19.
//

#ifndef SURVIVAL_CONSOLEMANAGER_H
#define SURVIVAL_CONSOLEMANAGER_H
#include <vector>
#include "Creature.h"
#include "Room.h"
#include <ncurses.h>
using namespace std;
class Creature;

class ConsoleManager {
private:


    void printAllRooms();
    void printAllCreatures();
    void printCorridors();
    void EscapeListen();
public:
    thread timeThread;
    thread escapeThread;
    ConsoleManager();
    static vector<Creature*> creatureList;
    static vector<Room*> roomList;
    static bool survivalIsActive;
    void addNewCreature(Creature *creature);
    void printCreatureStats();
    void reprint();
    void TimeIsPassing();
    void BeginSurvival();
};


#endif //SURVIVAL_CONSOLEMANAGER_H
