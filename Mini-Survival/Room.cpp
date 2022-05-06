//
// Created by wilk on 08.06.19.
//

#include <unistd.h>
#include "Room.h"
#include "ConsoleManager.h"

using namespace std;



Room::Room() {}

bool Room::Use(Creature *creature) {
    unique_lock<std::mutex> lck(RoomAcces,defer_lock);
    bool succes = lck.try_lock();
    if(succes) {
        this->lck=&lck;

        creature->setRoom(this);
        GoToRoom(creature,true);
        RoomEfect(creature);
        GoToRoom(creature,false);

    }
    return succes;
}

void Room::print() {
    int tempX= this->x;
    int tempY=this->y;
    move(tempY,tempX);
    addstr(this->roomName.c_str());

    for(int x=this->x;x<=(this->x+sizeX);x++)
    {
        move(y+sizeY,x);
        addch('@');
    }
    for(int y=this->y+1;y<=(this->y+sizeY);y++)
    {
        move(y,x);
        addch('@');
        move(y,x+sizeX);
        addch('@');

    }

}

void Room::GoToRoom(Creature *creature, bool dir) {


    if(dir)
    for(int i=0;i<this->pathFromWaitingRoom.size();i++)
    {
        creature->y=pathFromWaitingRoom[i]->y;
        creature->x=pathFromWaitingRoom[i]->x;
        std::this_thread::sleep_for(std::chrono::microseconds(50000));
    }
    else
    for(int i=(int)pathFromWaitingRoom.size()-1;i>0;i--)
    {
        creature->y=pathFromWaitingRoom[i]->y;
        creature->x=pathFromWaitingRoom[i]->x;
        std::this_thread::sleep_for(std::chrono::microseconds(50000));
    }



}
