#include "stdafx.h"
#include "KruskalSolver.h"


KruskalSolver::KruskalSolver(int V, int E, Graph *start)
{
	start->directed;
	maxEdges = V-1;
	edges = E;
	startingHeap = new EdgeHeap(E);
	for (int i = 0; i < V; i++) {
		startingHeap->pushHeap(start->getVerticeEdges(i));
	}
	endHeap = new EdgeHeap(maxEdges);
	nodes = new NodeFamily(V);
	for (int i = 0; i < V; i++)
		nodes->makeSet(i);
}
KruskalSolver::~KruskalSolver()
{
	//std::cout << "KRUSKAL DELETE TEST";
	delete startingHeap;
	delete endHeap;
	delete nodes;
}

void KruskalSolver::solve()
{
	for (int i = 0; i < maxEdges; i++)
	{

		
			do
			{
				tmp = &startingHeap->pop();              // Pobieramy z kolejki krawêdz
			} 
			while (nodes->findSet(tmp->from) == nodes->findSet(tmp->to));
			endHeap->push(*tmp);                 // Dodajemy krawêdŸ do drzewa
			nodes->unionSet(*tmp);               // Zbiory z wierzcho³kami ³¹czymy ze sob¹
		


	}
}

void KruskalSolver::printTree()
{
	int treeCost = 0;
	for (int i = 0; i < maxEdges; i++) {
		std::cout << "From: " << endHeap->heap[i].from << " TO: " << endHeap->heap[i].to << " cost:" << endHeap->heap[i].cost << std::endl;
		treeCost += endHeap->heap[i].cost;
	}
	std::cout << " Koszt calkowity: " << treeCost << std::endl;

}

NodeFamily::~NodeFamily()
{
	delete[] nodePointer;
}

NodeFamily::NodeFamily(int x)
{
	nodePointer = new Node[x];
}

void NodeFamily::makeSet(int x)
{
	nodePointer[x].up = x;
	nodePointer[x].rank = 0;
}

int NodeFamily::findSet(int x)
{
	if (nodePointer[x].up != x)
		nodePointer[x].up = findSet(nodePointer[x].up);
	return nodePointer[x].up;
}

void NodeFamily::unionSet(Edge x)
{
	int from, to;
	from = findSet(x.from);
	to = findSet(x.to);

	if (from != to)
	{
		if (nodePointer[from].rank > nodePointer[to].rank)
			nodePointer[to].up = from;
		else
		{
			nodePointer[from].up = to;
				if(nodePointer[from].rank == nodePointer[to].rank) 
					nodePointer[to].rank++;
		}
	}
}
