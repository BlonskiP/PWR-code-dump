//
// Created by wilk on 14.04.19.
//

#ifndef THREADBALLS_COLLIDINGITEM_H
#define THREADBALLS_COLLIDINGITEM_H


#include "Ball.h"
class Ball;
class CollidingItem {
public:
    virtual bool isColliding(Ball &ball)=0;
    virtual void colision(Ball &ball)=0;
    virtual void drawItem()=0;
};


#endif //THREADBALLS_COLLIDINGITEM_H
