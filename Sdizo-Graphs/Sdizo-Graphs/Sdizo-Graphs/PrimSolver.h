#ifndef PRIM_H
#pragma once
#define PRIM_H
#include "Graph.h"
#include "EdgeHeap.h"
class Graph;
class PrimSolver
{
public:
	PrimSolver(int V, int E, Graph *start);
	void solve();
	Graph *graf;
	bool *visited;
	void printTree();
	unsigned short int maxEdges;
	unsigned short int edges;
	EdgeHeap * startingHeap;
	EdgeHeap * endHeap;
	Edge *tmp;
	~PrimSolver();
};
#endif
