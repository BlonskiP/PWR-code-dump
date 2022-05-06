//
// Created by wilk on 08.06.19.
//

#ifndef SURVIVAL_ROOM_H
#define SURVIVAL_ROOM_H
#include <mutex>
#include <vector>
#include "Creature.h"
#include <condition_variable>
#include <ncurses.h>
using namespace std;
struct point{
    int x;
    int y;
    point(int x,int y)
    {
        this->x=x;
        this->y=y;
    }
};
class Creature;
class Room {
private:
public:
    Room();
// left corner
    int x;
    int y;
    int sizeX;
    int sizeY;
    string roomName="MissingName";
    vector<point*> pathFromWaitingRoom;
    void GoToRoom(Creature *creature, bool dir);
    mutex RoomAcces;
    condition_variable accesed;
    unique_lock<mutex> *lck;
    virtual bool Use(Creature *creature);
    virtual void RoomEfect(Creature *creature) = 0;
    void print();
};


#endif //SURVIVAL_ROOM_H
