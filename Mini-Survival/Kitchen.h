//
// Created by wilk on 08.06.19.
//

#ifndef SURVIVAL_KITCHEN_H
#define SURVIVAL_KITCHEN_H


#include "Room.h"

class Kitchen : public Room {
public:
    Kitchen();
    void RoomEfect(Creature *creature);
};


#endif //SURVIVAL_KITCHEN_H
