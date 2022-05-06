/*
 * Ball.h
 *
 *  Created on: Mar 24, 2019
 *      Author: wilk
 */

#ifndef BALL_H_
#define BALL_H_
#include <vector>
#include <iostream>
using namespace std;
class Ball {
public:
	Ball(int xSpeed, int ySpeed, int xPos, int yPos);
	virtual ~Ball();
	int x;
	int y;
	void move();
	vector<int> moveVector;
};

#endif /* BALL_H_ */
