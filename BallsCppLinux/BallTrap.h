//
// Created by wilk on 27.04.19.
//

#ifndef THREADBALLS_BALLTRAP_H
#define THREADBALLS_BALLTRAP_H


#include "CollidingItem.h"
#include <vector>
#include <ncurses.h>
#include <thread>
#include <condition_variable>
#include <algorithm>

class BallTrap : public CollidingItem {
    int xLeftUpCorner;
    int yLeftUpCorner;
    int wallSize;
    int trapCapacity;
    
public:  std::vector<Ball*> ballQueue;
public:  std::mutex mutBallTrap;

    bool isColliding(Ball &ball) override;
    void colision(Ball &ball) override;
    void drawItem() override;
    bool queueContains(Ball *ball);
    void freeBall();

public:
    BallTrap(int xLeftUpCorner, int yLeftUpCorner, int wallSize , int capacity);
};


#endif //THREADBALLS_BALLTRAP_H
