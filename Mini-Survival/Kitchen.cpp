//
// Created by wilk on 08.06.19.
//

#include <unistd.h>
#include "Kitchen.h"
#include "Garden.h"

Kitchen::Kitchen() {
    this->roomName="Kitchen";
    x=9;
    y=5;
    sizeX=7;
    sizeY=4;
    this->pathFromWaitingRoom.push_back(new point(25,10));
    this->pathFromWaitingRoom.push_back(new point(25,9));
    for(int i=0;i<13;i++){
        this->pathFromWaitingRoom.push_back(new point(25-i,8));
    }
    this->pathFromWaitingRoom.push_back(new point(25-12,7));
}

void Kitchen::RoomEfect(Creature *creature) {
    if(creature->getHunger()>75)return;
    int prog=0;
    creature->setProgress(prog);
    if(creature->getHunger()<75)
    while((creature->getHunger()<creature->maxHunger && creature->getProgress()<5) && creature->isAlive )
    {
        // accesed.wait_for(*lck,std::chrono::seconds(1));
        prog++;
        std::this_thread::sleep_for(std::chrono::milliseconds(300));
        creature->setProgress(prog);
        if(Garden::getFood()>0) {
            int food = Garden::eatFood();
            creature->changeHungerBy(food);

        }
        else return;
    }
}
