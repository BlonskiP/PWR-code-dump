//
// Created by wilk on 16.04.19.
//

#ifndef THREADBALLS_WALL_H
#define THREADBALLS_WALL_H


#include "CollidingItem.h"
#include <ncurses.h>
#include <algorithm>
#include  <cstdlib>

class Wall : public CollidingItem {

public:
    Wall(int startX, int endX, int startY, int endY);
    int startX;
    int endX;
    int startY;
    int endY;
    bool isColliding(Ball &ball) override;
    void colision(Ball &ball) override;
    void drawItem() override;
};


#endif //THREADBALLS_WALL_H
