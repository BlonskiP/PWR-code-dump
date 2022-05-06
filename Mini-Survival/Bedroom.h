//
// Created by wilk on 08.06.19.
//

#ifndef SURVIVAL_BEDROOM_H
#define SURVIVAL_BEDROOM_H


#include "Room.h"

class Bedroom : public Room {
public:
    void RoomEfect(Creature *creature);
    Bedroom();
};


#endif //SURVIVAL_BEDROOM_H
