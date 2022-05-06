//
// Created by wilk on 08.06.19.
//

#include "Waitingroom.h"

void Waitingroom::RoomEfect(Creature *creature) {
    creature->progress=0;
    creature->setRoom(this);
    std::this_thread::sleep_for(std::chrono::milliseconds(16));
}

Waitingroom::Waitingroom() {
    this->roomName="Waitingroom";
    x=20;
    y=5;
    sizeX=10;
    sizeY=10;
}

bool Waitingroom::Use(Creature *creature) {
    RoomEfect(creature);
    return true;
}

