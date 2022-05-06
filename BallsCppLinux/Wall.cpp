//
// Created by wilk on 16.04.19.
//

#include "Wall.h"
#include <algorithm>
using namespace std;
 void Wall::colision(Ball &ball) {

     //To do mathematic collision. Random colisoin as placehoder

      if(this->startY==this->endY) //vertical wall
      {
          int y=this->endY;
          if(ball.dir[1]>0)
              ball.dir[1]*=-1;
          else
          if(ball.dir[1]<0)
              ball.dir[1]*=-1;
      }
      if(this->startX==this->endX)
      {
          int x= this->endX;
          if(ball.dir[0]>0)
              ball.dir[0]*=-1;
          else
              if(ball.dir[0]<0)
                  ball.dir[0]*=-1;
      }


}
 bool Wall::isColliding(Ball &ball) {
    int det =
            (startX*endY)+(startY*ball.x)+(endX*ball.y)
            -(ball.x*endY)-(ball.y*startX)-(endX*startY);
    if(det!=0) return false;
        if((min(startX,endX) <= ball.x)&&(ball.x<=max(startX,endX))&&
                (min(startY,endY) <= ball.y)&&(ball.y<=max(startY,endY))){
            int x=0;
            int y=0;
            if(ball.dir[0]>0)x=-1;
            if(ball.dir[1]>0)y=-1;
            if(ball.dir[0]<0)x=1;
            if(ball.dir[1]<0)y=1;
            ball.moveForward(x,y);
     return true;}
     else
     return false;

//http://www.algorytm.org/geometria-obliczeniowa/przynaleznosc-punktu-do-odcinka.html



}

Wall::Wall(int startX, int endX, int startY, int endY) {
    this->startX=startX;
    this->endX=endX;
    this->startY=startY;
    this->endY=endY;
}

void Wall::drawItem() {
    const char wallSymbol='=';
    for(int xPos=startX, yPos=startY;xPos<endX || yPos<endY;   )
    {
        move(xPos,yPos);
        addch(wallSymbol);
        if(xPos<endX){xPos++;};
        if(yPos<endY){yPos++;};

    }
        refresh();
}
