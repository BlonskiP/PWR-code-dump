
#include "Map.h"

Map::Map(int x, int y) { // @suppress("Class members should be properly initialized")
	this->sizeX=x;
	this->sizeY=y;
	symbolsInit();

}

Map::~Map() {

}

void Map::symbolsInit(){
	symbols=new char*[sizeX];
		for(int i=0;i<sizeX;i++)
			symbols[i]=new char[sizeX];

		for(int x=0;x<sizeX;x++)
			for(int y=0;y<sizeY;y++)
			{
				symbols[x][y]='x';
			}
}
