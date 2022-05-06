#include "stdafx.h"
#include "PrimSolver.h"



PrimSolver::PrimSolver(int V, int E, Graph * start)
{
	visited = new bool[V];
	endHeap = new EdgeHeap(V-1);
	startingHeap = new EdgeHeap(E);
	graf = start;
	maxEdges = V - 1;
	edges = E;
	for (int i = 0; i < V; i++)
		visited[i] = false;

}

void PrimSolver::solve()
{
	EdgeHeap *tmpHeap;
	int v = 0;
	int heapSize;
	visited[v] = true;
	for (int i = 0; i < maxEdges; i++)
	{
		
		tmpHeap = graf->getVerticeEdges(v);
		heapSize = tmpHeap->heapSize;
		for (int k = 0; k < heapSize; k++)
		{
			tmp = &tmpHeap->pop();
			if (!visited[tmp->to])
			{
				startingHeap->push(*tmp);
			}

		}
		do {
			tmp = &startingHeap->pop();
		
		} while (visited[tmp->to]);
		endHeap->push(*tmp);
		visited[tmp->to] = true;
		v = tmp->to;
	}
}

void PrimSolver::printTree()
{
	int treeCost = 0;
	for (int i = 0; i < maxEdges; i++) {
		std::cout << "From: " << endHeap->heap[i].from << " TO: " << endHeap->heap[i].to << " cost:" << endHeap->heap[i].cost << std::endl;
		treeCost += endHeap->heap[i].cost;
	}
	std::cout << " Koszt calkowity: " << treeCost << std::endl;
}

PrimSolver::~PrimSolver()
{
	//std::cout << "DIE PRIM";
	delete startingHeap;
	delete endHeap;
	delete[] visited;
}
