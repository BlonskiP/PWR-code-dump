#pragma once
#ifndef BELLMAN_H
#define BELLMAN_H
#include "Graph.h"
#include "EdgeHeap.h"
class Graph;
class Bellman
{
public:
	Bellman(int V, int E, Graph *graf);
	~Bellman();
	int *verticlesCost;
	int *preVerticle;
	Graph *G;
	EdgeHeap *tmpHeap;
	void solve(int startVerticle);
	void print();
	
};

#endif