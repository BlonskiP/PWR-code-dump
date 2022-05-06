//
// Created by wilk on 08.06.19.
//

#include <cstring>
#include <unistd.h>
#include "ConsoleManager.h"
#include "Kitchen.h"
#include "Bedroom.h"
#include "Waitingroom.h"
#include "Garden.h"

using namespace std;
vector<Creature*> ConsoleManager::creatureList;
vector<Room*> ConsoleManager::roomList;
bool ConsoleManager::survivalIsActive;
void ConsoleManager::addNewCreature(Creature *creature) {

}

ConsoleManager::ConsoleManager() {

    Garden::food=50;
    //CreateRooms
    ConsoleManager::roomList.push_back(new Kitchen());
    ConsoleManager::roomList.push_back(new Waitingroom());
    ConsoleManager::roomList.push_back(new Bedroom());
    ConsoleManager::roomList.push_back(new Garden());
    //CreateCreatures//
    ConsoleManager::creatureList.push_back(new Creature("Janek",'$'));
    ConsoleManager::creatureList.push_back(new Creature("Baltazar",'&'));
    ConsoleManager::creatureList.push_back(new Creature("Bartlomiej",'*'));
    ConsoleManager::creatureList.push_back(new Creature("Mikołaj",'O'));
    ConsoleManager::creatureList.push_back(new Creature("Pawelek",'K'));
    ConsoleManager::creatureList.push_back(new Creature("Michal",'M'));
    ConsoleManager::creatureList.push_back(new Creature("Mateusz",'?'));
    ConsoleManager::creatureList.push_back(new Creature("Stefan",'!'));
    ConsoleManager::creatureList.push_back(new Creature("Janusz",'%'));
    ConsoleManager::creatureList.push_back(new Creature("Andrzej",'+'));

    ///////////////////
    initscr();
    noecho();
    curs_set(0);
}

void ConsoleManager::BeginSurvival() {
    ConsoleManager::survivalIsActive=true;
    for(int i=0;i<ConsoleManager::creatureList.size();i++)
    {
        ConsoleManager::creatureList[i]->beginSurvival();
    }
    timeThread=thread(&ConsoleManager::TimeIsPassing,this);
    escapeThread=std::thread(&ConsoleManager::EscapeListen,this);


}

void ConsoleManager::printCreatureStats() {
    int y=25; //starting y;
    int creatureCount=(int)ConsoleManager::creatureList.size();
    move(y,0);
    addstr("Food in storage: ");
    string food= to_string(Garden::food).c_str();
    addstr(food.c_str());
    y++;
    for(int i=0; i<creatureCount;i++) {
        move(y+i,0);
        Creature *& creature = ConsoleManager::creatureList[i];
        string name= creature->name;
        addch(creature->symbol);
        addch(' ');
        addstr(name.c_str());
        move(y+i,10);
        Room * room = creature->getRoom();
        string roomName=room->roomName;
        if(!creature->isAlive) roomName="dead";
        addstr(roomName.c_str());
        for(int j=0;j<creature->getProgress();j++){
            move(y+i,25+j);
            addch('*');
        }
        move(y+i,38);
        addstr("Hunger: ");
        addstr(to_string(creature->getHunger()).c_str());
        move(y+i,49);
        addstr(" Energy: ");
        addstr(to_string(creature->getEnergy()).c_str());
    }
}

void ConsoleManager::reprint() {
    std::this_thread::sleep_for(std::chrono::milliseconds(16));
    erase();
    printAllRooms();
    printCorridors();
    printAllCreatures();
    printCreatureStats();
    refresh();
}

void ConsoleManager::TimeIsPassing() {
    while(ConsoleManager::survivalIsActive) {
        for (int i = 0; i < ConsoleManager::creatureList.size(); i++) {
            ConsoleManager::creatureList[i]->changeEnergyBy(-1);
            ConsoleManager::creatureList[i]->changeHungerBy(-1);
            ConsoleManager::creatureList[i]->CheckIfIsAlive();
        }
        sleep(2);
    }
}

void ConsoleManager::printAllRooms() {
    for(int i=0; i<ConsoleManager::roomList.size();i++)
    {
        ConsoleManager::roomList[i]->print();
    }
}

void ConsoleManager::printCorridors() {
    int x=16;
    int y=7;
    for(int k=0;k<3;k+=2){
    for(int i=0;i<5;i++)
    {
        move(y+k,x+i);
        addch('^');
    }}
    x=31;
    for(int k=0;k<3;k+=2){
        for(int i=0;i<5;i++)
        {
            move(y+k,x+i);
            addch('^');
        }}
    y=13;
    for(int k=0;k<3;k+=2){
        for(int i=0;i<5;i++)
        {
            move(y+k,x+i);
            addch('^');
        }}

}

void ConsoleManager::printAllCreatures() {
    for(int i=0;i<ConsoleManager::creatureList.size();i++)
    {
        if(creatureList[i]->isAlive) {
            move(creatureList[i]->y, creatureList[i]->x);
            addch(creatureList[i]->symbol);
        }
    }

}

void ConsoleManager::EscapeListen() {
    while(ConsoleManager::survivalIsActive)
    {
        if(getch()=='q')
        {
            ConsoleManager::survivalIsActive=false;
        }
    }

}
