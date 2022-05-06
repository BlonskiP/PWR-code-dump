#pragma once

#ifndef GRAPH_H
#define GRAPH_H
#include "KruskalSolver.h"
#include "EdgeHeap.h"
#include "PrimSolver.h"
#include <fstream>
#include <iostream>
#include <iomanip>
#include "DijkstraSolver.h"
#include "Bellman.h"
class DijkstraSolver;
class KruskalSolver;
class PrimSolver;
class Bellman;

class Graph
{
public:
	std::fstream file;
	Edge * *list;
	EdgeHeap * heap;
	Edge *p, *r; // Pointery pomocnicze
	KruskalSolver *kruskal;
	PrimSolver *prim;
	DijkstraSolver *dij;
	Bellman *bellman;
	int V = 0;
	int E = 0;
	int *graphArray;
	Graph();
	virtual ~Graph();
	bool directed;
	virtual void addEdge(int start, int end, int cost, int number) = 0;
	virtual void addVertex(int i) = 0;
	virtual void print() = 0; //prints
	virtual void changeRep() = 0; //changes representaion
	bool loadFromFile();
	void setSize(int size) {
		V = size;
	}
	void setEdges(int edge)
	{
		E = edge;
	}
	void createEdgeHeap();
	void kruskalSolver();
	virtual EdgeHeap* getVerticeEdges(int verticle) = 0;
	virtual EdgeHeap* getVerticeEdgesPath(int verticle) = 0;
	void primSolver();
	void dijSolver();
	void bellSolver();
	void MST();
	void path();
	virtual void changeToDirected() = 0;
	virtual void changeToNotDirected() = 0;
	void generate(int W, int E);
	bool checkBools(bool *ar);
	void changeDir();
	void printArray();
	virtual void ABS() = 0;
	void toFile();
};

#endif
