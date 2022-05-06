#pragma once
#ifndef Dijkstra_H
#define Dijkstra_H
#include "Graph.h"
#include "EdgeHeap.h"
#include <math.h>
const int MAXINT = 2147483647;
class Graph;
class DijkstraSolver
{
public:
	DijkstraSolver(int V, int E, Graph *graf);
	~DijkstraSolver();
	int *verticlesCost;
	bool *verticles;
	int *preVerticle;
	Graph *G;
	EdgeHeap *tmpHeap;
	void solve(int startVerticle);
	void print();
	int findCheap();
};

#endif