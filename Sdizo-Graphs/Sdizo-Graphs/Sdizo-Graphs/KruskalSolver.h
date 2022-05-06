#ifndef KRUSKAL_H
#pragma once
#define KRUSKAL_H
#include "Graph.h"
#include "EdgeHeap.h"
//extern class Graph;
struct Node //element zbioru
{
	int up, rank;
};
struct NodeFamily
{	public:
	Node *nodePointer;
	~NodeFamily();
	NodeFamily(int x); // tworzy strukture ze zbiorami konstruktor
	void makeSet(int x); // tworzy  zbior
	int findSet(int x);
	void unionSet(Edge x);
};
class Graph;
class KruskalSolver
{
public:
	unsigned short int maxEdges;
	unsigned short int edges;
	EdgeHeap * startingHeap;
	EdgeHeap * endHeap;
	NodeFamily * nodes;
	Edge *tmp;
	KruskalSolver(int V, int E, Graph *start);
	~KruskalSolver();
	void solve();
	void printTree();
	
};
#endif
