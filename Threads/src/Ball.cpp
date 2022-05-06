/*
 * Ball.cpp
 *
 *  Created on: Mar 24, 2019
 *      Author: wilk
 */

#include "Ball.h"

Ball::Ball(int xSpeed, int ySpeed , int xPos, int yPos) {
	x=xPos;
	y=yPos;
	moveVector.insert(moveVector.begin(),xSpeed);
	moveVector.insert(moveVector.end(),ySpeed);
	std::cout<<xSpeed;



}

Ball::~Ball() {
	// TODO Auto-generated destructor stub
}

void Ball::move() {
}
