//
// Created by wilk on 24.03.19.
//

#ifndef THREADBALLS_PRINTMANAGER_H
#define THREADBALLS_PRINTMANAGER_H

#include <ncurses.h>
#include "Map.h"
#include "Ball.h"
#include <unistd.h>
#include <vector>
#include <thread>
#include <condition_variable>

class PrintManager {

public:
    PrintManager(int amount);
    Map *map;
    std::vector<Ball*> balls;
    static bool run;
    static std::condition_variable cv_run;
    std::thread escapeThread;
    static std::mutex runMutex;
    int nBalls;
    void printMap();
    void drawBalls();
    void print(int fresh);
    void escapeListen();
};


#endif //THREADBALLS_PRINTMANAGER_H
