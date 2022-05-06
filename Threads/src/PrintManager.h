#ifndef PRINTMANAGER_H_
#define PRINTMANAGER_H_
#include <ncurses.h>
#include "Map.h"

class PrintManager {
public:
	PrintManager();
	virtual ~PrintManager();

private:
	void printMap();
	void printMapInit();
	Map *map;
};

#endif /* PRINTMANAGER_H_ */
