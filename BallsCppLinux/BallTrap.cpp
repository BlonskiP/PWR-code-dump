//
// Created by wilk on 27.04.19.
//

#include "BallTrap.h"

BallTrap::BallTrap(int xLeftUpCorner, int yLeftUpCorner, int wallSize, int capacity) {
    this->xLeftUpCorner=xLeftUpCorner;
    this->yLeftUpCorner=yLeftUpCorner;
    this->wallSize=wallSize;
    this->trapCapacity=capacity;
}

void BallTrap::drawItem() {
    const char wallSymbol='@';
    for(int x=xLeftUpCorner, y=yLeftUpCorner;x<(xLeftUpCorner+wallSize);x++)
    {
        move(x,y);
        addch(wallSymbol);
    }
    for(int x=xLeftUpCorner, y=yLeftUpCorner;y<(yLeftUpCorner+wallSize);y++)
    {
        move(x,y);
        addch(wallSymbol);
    }
    for(int x=xLeftUpCorner+wallSize, y=yLeftUpCorner; y<(yLeftUpCorner+wallSize);y++)
    {
        move(x,y);
        addch(wallSymbol);
    }
    for(int x=xLeftUpCorner, y=yLeftUpCorner+wallSize; x<=xLeftUpCorner+wallSize;x++)
    {
        move(x,y);
        addch(wallSymbol);
    }
  //  refresh();
}
// ball is you (the thread)
// lock mutex. check if queue is full.
// If queue isn't full add yourself to queue, unlock mutex.
// And wait until you're poped
// If queue is full. Pop somebody from queue

void BallTrap::colision(Ball &ball) {
    std::unique_lock<std::mutex> lck(mutBallTrap);
    
    ball.isTraped=true;

    int x=0;
    int y=0;
    if(ball.dir[0]>0)x++;
    else x--;
    if(ball.dir[1]>0)y++;
    else y--;
    for(int i=0;i<3;i++) {
        ball.moveForward(x, y);
        if(!isColliding(ball))
        {
            break;


        }
    }

    //////////////////

    ballQueue.push_back(&ball);
    if(ballQueue.size()<=trapCapacity)
    {
        ball.cvBallSleep.wait(lck,[this,&ball]{return !queueContains(&ball);});
        ball.isTraped=false;

    } else
    {
        freeBall();
        //while(isColliding(ball))
        ball.cvBallSleep.wait(lck,[this,&ball]{return !queueContains(&ball);});

    }
    lck.unlock();
}
bool BallTrap::isColliding(Ball &ball) {
    if(!ball.isTraped)
    if(ball.x>= xLeftUpCorner && ball.x<=(xLeftUpCorner+wallSize))
        if(ball.y>=yLeftUpCorner && ball.y<=(yLeftUpCorner+wallSize))
            return true;
    return false;
}

bool BallTrap::queueContains(Ball *ball) {

    for(auto ballInQueue : ballQueue)
    {
        if(ball==ballInQueue)
        {
            return true;
        }
    }
    return false;

}

void BallTrap::freeBall() {
    ballQueue[0]->isTraped = false;
    ballQueue[0]->dir[0]*=-1;
    ballQueue[0]->dir[1]*=-1;
    ballQueue[0]->cvBallSleep.notify_all();
    while (isColliding(*ballQueue[0]))
    {
        ballQueue[0]->moveForward(ballQueue[0]->dir[0],ballQueue[0]->dir[1]);
    }
    ballQueue.erase(ballQueue.begin());



}

