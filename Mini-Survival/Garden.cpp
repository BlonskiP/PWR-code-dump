//
// Created by wilk on 08.06.19.
//

#include <unistd.h>
#include "Garden.h"
#include "ConsoleManager.h"

int Garden::food;
mutex Garden::foodAcces;
void Garden::RoomEfect(Creature *creature) {
    creature->progress=0;
    int prog=0;
    while(creature->isAlive && creature->progress<5 && creature->getHunger()>25 && creature->getEnergy()>25)
    {
        prog++;
        creature->setProgress(prog);
        Garden::gatherFood(creature);
        std::this_thread::sleep_for(std::chrono::milliseconds(300));
        if(creature->getHunger()<15 || creature->getEnergy()<15)return;

    }

}

void Garden::gatherFood(Creature *creature) {
    std::unique_lock<std::mutex> lck(Garden::foodAcces);
    Garden::food+=5;
    creature->changeHungerBy(-1);
    creature->changeEnergyBy(-1);
}

int Garden::eatFood() {
    std::unique_lock<std::mutex> lck(Garden::foodAcces);
    int foodToEat;
    if(Garden::food>5)foodToEat=5;
    else foodToEat=Garden::food;
    Garden::food-=foodToEat;
    return foodToEat;
}

int Garden::getFood() {
    std::unique_lock<std::mutex> lck(Garden::foodAcces);
    return  Garden::food;
}

Garden::Garden() {
    this->roomName="Garden";
    x=35;
    y=10;
    sizeX=5;
    sizeY=10;
    for(int i=0;i<5;i++) {
        this->pathFromWaitingRoom.push_back(new point(25, 10+i));
    }
    for(int i=0;i<13;i++){
        this->pathFromWaitingRoom.push_back(new point(25+i,14));
    }
    this->pathFromWaitingRoom.push_back(new point(25+12,14));

}

