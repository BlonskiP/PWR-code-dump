#include "stdafx.h"
#include "DijkstraSolver.h"

DijkstraSolver::DijkstraSolver(int V, int E, Graph *graf)
{
	G = graf;
	verticlesCost = new int[V];
	verticles = new bool[V];
	preVerticle = new int[V];
	for (int i = 0; i < V; i++) {
		verticlesCost[i] = MAXINT;
		preVerticle[i] = -1;
		verticles[i] = false;
	}
	tmpHeap = new EdgeHeap(3);
	
}

DijkstraSolver::~DijkstraSolver()
{
	//std::cout << " DIE DIJKSTRA";


	delete[] verticlesCost;
	delete[] verticles;
	delete[] preVerticle;
	delete tmpHeap;
}

void DijkstraSolver::solve(int startVerticle)
{
	int v = startVerticle;
	verticles[v] = true; //odwiedzilismy pierwszy wierzcho³ek
	verticlesCost[v] = 0;
	int heapSize = 0;
	int pathCost;
	int toPath;
	Edge *tmp;

	for (int i = 0; i < G->V - 1; i++)
	{
		tmpHeap->pushHeap(G->getVerticeEdgesPath(v)); // Wez wszystkie krawedzie wierzcholka i
		heapSize = tmpHeap->heapSize; //heapSize to ilosc wierzcholkow
		for (int k = 0; k < heapSize; k++) //Sprawdzaj krawedzie
		{
			tmp = &tmpHeap->pop();
			pathCost = verticlesCost[tmp->from] + tmp->cost;
			toPath = verticlesCost[tmp->to];
			if (pathCost < toPath) //jezeli koszt mniejszy to
			{
				verticlesCost[tmp->to] = pathCost;
				preVerticle[tmp->to] = tmp->from;
			}

		}
		int v1 = findCheap(); //Znajdz najtanszy wierzcholek ktorego nie bylo
		
			verticles[v1] = true; //teraz juz jest
			v = v1; //sprawdz go

	}
	
}

void DijkstraSolver::print()
{
	std::cout << "ALGORYTM DIJKSTRY \n";
	std::cout << "W: ";
	for (int i = 0; i < G->V; i++)
		std::cout << std::setw(3) << i;
	std::cout << std::endl;
	std::cout << "K: ";
	for (int i = 0; i < G->V; i++)
		std::cout << std::setw(3) << verticlesCost[i];
	std::cout << std::endl;
	std::cout << "P: ";
	for (int i = 0; i < G->V; i++)
		std::cout << std::setw(3) << preVerticle[i];
	std::cout << std::endl;
	std::cout << std::endl;
	std::cout << "G: ";
	for (int i = 0; i < G->V; i++)
		std::cout << std::setw(3) <<verticles[i];
	std::cout << std::endl;
	std::cout << std::endl;
}

int DijkstraSolver::findCheap()
{
	int numer = 0;
	int cheap = MAXINT;
	for (int i = 0; i <G->V; i++)
	{
		if(verticles[i]==false)
		if (verticlesCost[i] < cheap)
		{
			cheap = verticlesCost[i];
			numer = i;
		}
	}
	return numer;
}
