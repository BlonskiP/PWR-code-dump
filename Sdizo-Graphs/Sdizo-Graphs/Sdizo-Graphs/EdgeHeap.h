#pragma once
#include <iostream>
struct Edge
{
public:
	Edge(int f, int t, int c)
	{
		from = f;
		to = t;
		cost = c;
		next = nullptr;
	}
	Edge() { cost = 0; };
	unsigned int number;
	int cost = 0;
	int from;
	int to;
	Edge *next;
};
class EdgeHeap
{
public:
	int heapSize = 0;
	int maxSize = 0;
	Edge *heap;
	
	EdgeHeap(int edges);
	~EdgeHeap();
	void push(Edge edge);
	void pushHeap(EdgeHeap *edges);
	Edge pop();
	int parent(int i) { return (i - 1) / 2;}
	int left(int i) { return (2 * i + 1); }
	int right(int i) { return (2 * i + 2); }
	void swap(Edge x, Edge y);
	void heapify(int i);
	void printHeap();
	bool heapCheck();
	void printEdges();
	void extendHeap();
};
