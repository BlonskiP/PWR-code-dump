#include "PrintManager.h"

PrintManager::PrintManager() {
	initscr(); //init ncurses
	map = new Map(10,10);
	printMapInit();
}

PrintManager::~PrintManager() {

	endwin();//end ncurses
}
void PrintManager::printMapInit(){
	while(true)
	{
		printMap();
	}
}

void PrintManager::printMap()
{
	printw( "Hello World !!!" ); //2
	printw(0,map->sizeX,map->symbols[0]);
}

