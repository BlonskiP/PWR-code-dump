//
// Created by wilk on 24.03.19.
//

#include "Map.h"
#include "Wall.h"
#include "BallTrap.h"

Map::Map(int x, int y) {
    sizeX= x;
    sizeY= y;
    charMap=new char*[x];
    for(int i=0;i<x;i++) {
        charMap[i] = new char[y];
    }
    for(int i=0;i<x;i++)
        for(int k=0;k<y;k++)
        {
            if(i==0 || i==x-1)
                charMap[i][k]='-';
            else if(k==0 || k==y-1)
                charMap[i][k]='|';
            else
                charMap[i][k]=' ';
        }

      CollidingItem* ballTrap = new BallTrap(10,40,10,6);
      CollidingItem* rightWall = new Wall(0,20,50,50);
      CollidingItem* leftWall = new Wall(0,20,0,0);
      CollidingItem* upWall = new Wall(0,0,0,50);
      CollidingItem* downWall = new Wall(20,20,0,50);
      colItemsVector.push_back(rightWall);
      colItemsVector.push_back(leftWall);
      colItemsVector.push_back(upWall);
      colItemsVector.push_back(downWall);
      colItemsVector.push_back(ballTrap);
}

void Map::collisionCheck(Ball &ball) {
    for(auto colidingItem : colItemsVector)
    {
        if(colidingItem->isColliding(ball))
        {
            colidingItem->colision(ball);
        }
    }
}
