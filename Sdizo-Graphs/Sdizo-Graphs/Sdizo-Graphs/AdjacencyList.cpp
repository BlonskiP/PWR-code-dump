#include "stdafx.h"
#include "AdjacencyList.h"




AdjacencyList::AdjacencyList(bool dir)
{
	loadFromFile();
	directed = dir;
	if (directed == true)changeToDirected();
	else changeToNotDirected();
}

AdjacencyList::AdjacencyList(int size, int edge)
{	
	setSize(size);
	setEdges(edge);
	list = new Edge *[V];
	for (int i = 0; i < V; i++) addVertex(i);
	
}

AdjacencyList::~AdjacencyList()
{
	//std::cout << "LIST IS DEAD";
	for (int i = 0; i < V; i++)
	{
		p = list[i];
		while (p)
		{
			r = p;
			p = p->next;
			delete r;
		}
	}
	delete[] list;
	delete heap;
	



}


void AdjacencyList::addEdge(int start, int end, int cost, int number)
{
	
	p = new Edge(start,end,cost);
	p->number = number;
	p->next = list[start];
	list[start] = p;
	
}

void AdjacencyList::addVertex(int i)
{
	list[i] = nullptr;
}

void AdjacencyList::print()
{
	for (int i = 0; i < V; i++)
	{
		std::cout << "Wierzcholek: " << i << " :" << std::endl;
		p = list[i];
		while (p)
		{
			std::cout << " Waga: " << p->cost << " do " << p->to << " numer" << p->number << std::endl;
			p = p->next;
		}
		std::cout << std::endl;
	}
}

void AdjacencyList::changeRep()
{
}



EdgeHeap * AdjacencyList::getVerticeEdgesPath(int verticle)
{
	return getVerticeEdges(verticle);
}

EdgeHeap * AdjacencyList::getVerticeEdges(int verticle)
{
	EdgeHeap* tmpHeap = new EdgeHeap(3);
	Edge *tmp;
	
		tmp = list[verticle];
		while (tmp != nullptr)
		{
			tmpHeap->push(*tmp);

			tmp = tmp->next;
		}

	
	return tmpHeap;
}

void AdjacencyList::changeToDirected()
{
	int start, end, weight;
	
	
	list = new Edge *[V];
	for (int i = 0; i < V; i++) addVertex(i);
	int n = 2;
	for (int i = 0; i < E; i++)
	{

		start = graphArray[n];
		end = graphArray[n + 1];
		weight = graphArray[n + 2];
		addEdge(start, end, weight, i);
		n = n + 3;
	}
	
}

void AdjacencyList::changeToNotDirected()
{
	int start, end, weight;

	
	list = new Edge *[V];
	for (int i = 0; i < V; i++) addVertex(i);
	int n = 2;
	for (int i = 0; i < E; i++)
	{

		start = graphArray[n];
		end = graphArray[n+1];
		weight= graphArray[n+2];
		addEdge(start, end, weight, i);
		addEdge(end, start, weight, i);
		n = n + 3;

	}
	
}

void AdjacencyList::ABS()
{

}

