//
// Created by wilk on 08.06.19.
//

#include <unistd.h>
#include "Bedroom.h"

void Bedroom::RoomEfect(Creature *creature) {
    if(creature->getEnergy()>75)return;
    int prog=0;
    creature->setProgress(prog);
    if(creature->getEnergy()<75)
        while((creature->getEnergy()<creature->maxEnergy && creature->getProgress()<5) && creature->isAlive )
        {
            // accesed.wait_for(*lck,std::chrono::seconds(1));
            prog++;
            std::this_thread::sleep_for(std::chrono::milliseconds(300));
            creature->setProgress(prog);
            creature->changeEnergyBy(5);
        }
}

Bedroom::Bedroom() {
    this->roomName="Bedroom";
    x=35;
    y=5;
    sizeX=7;
    sizeY=4;
    this->pathFromWaitingRoom.push_back(new point(25,10));
    this->pathFromWaitingRoom.push_back(new point(25,9));
    for(int i=0;i<13;i++){
        this->pathFromWaitingRoom.push_back(new point(25+i,8));
    }
    this->pathFromWaitingRoom.push_back(new point(25+12,7));
}
