//
// Created by wilk on 08.06.19.
//

#ifndef SURVIVAL_GARDEN_H
#define SURVIVAL_GARDEN_H


#include "Room.h"

class Garden : public Room {
public:
    Garden();
    static int food;
    static mutex foodAcces;
    static int getFood();
    static int eatFood();
    void RoomEfect(Creature *creature);
    void gatherFood(Creature *creature);
};


#endif //SURVIVAL_GARDEN_H
