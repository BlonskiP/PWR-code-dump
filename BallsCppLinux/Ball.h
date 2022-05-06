//
// Created by wilk on 24.03.19.
//

#ifndef THREADBALLS_BALL_H
#define THREADBALLS_BALL_H

#include <unistd.h>
#include <thread>
#include <vector>
#include "Map.h"
#include <condition_variable>


class BallTrap;
class Map;
class Ball {
public:
    Ball(int x, int y, Map *map,int sleepTime);
public: int x;
public: int y;
    int sleepTime;
    char symbol='o';
    std::thread movThread;
public: bool isTraped=false;
    std::condition_variable cvBallSleep;
    std::vector<int> dir;
    Map *map;
    void moveForward(int xForward, int yForward);

private:
    void move();

    void checkDirections();
};


#endif //THREADBALLS_BALL_H
