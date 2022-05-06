//
// Created by wilk on 08.06.19.
//

#ifndef SURVIVAL_WAITINGROOM_H
#define SURVIVAL_WAITINGROOM_H


#include "Room.h"

class Waitingroom : public Room{
public:
    void RoomEfect(Creature *creature) override;
    Waitingroom();
    bool Use(Creature *creature);

};


#endif //SURVIVAL_WAITINGROOM_H
