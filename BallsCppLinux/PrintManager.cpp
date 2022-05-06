//
// Created by wilk on 24.03.19.
//


#include <iostream>
#include "PrintManager.h"
bool PrintManager::run=true;
std::condition_variable PrintManager::cv_run;
std::mutex PrintManager::runMutex;
PrintManager::PrintManager(int amount) {
    initscr();
    noecho();
    //set cursor na 0
    curs_set(0);
    map=new Map(20,50);
    int randX;
    int randY;
    escapeThread=std::thread(&PrintManager::escapeListen,this);
    for(int i=0;i<amount;i++)
    {  randX=rand() % 17 +2;

       randY=rand() % 47 +2;
          //randX=15;
        //  randY=20;
    balls.push_back(new Ball(randX,randY,map,i));

    }
    //balls.push_back(new Ball(15,20,map,0));//test balls
    //balls.push_back(new Ball(16,15,map,1));




    print(100);
}

void PrintManager::printMap() {
    erase();
    for(auto colItem : map->colItemsVector)
    {
        colItem->drawItem();
    }
}

void PrintManager::drawBalls() {
    for(int i=0;i<balls.size();i++)
    {
        int x=balls[i]->x;
        int y=balls[i]->y;
        move(x,y);
        addch(balls[i]->symbol);
    }

}
    void PrintManager::print(int fresh) {
        while(PrintManager::run)
        {
            usleep(40000);
        printMap();
        drawBalls();
        //move(0,0);
        refresh();

        }

        escapeThread.join();
        for(int i=0;i<balls.size();i++) {
            balls[i]->movThread.join();
        }
        erase();
        refresh();
        printw("Threads joined. \n Press any key");
        getch();
        endwin();
    }

void PrintManager::escapeListen() {
    while(run)
    {
        if(getch()=='q')
        {
        run=false;
        PrintManager::cv_run.notify_all();
        for(Ball *& ball: balls)
        {
            ball->cvBallSleep.notify_all();
        }
        }
    }
}



