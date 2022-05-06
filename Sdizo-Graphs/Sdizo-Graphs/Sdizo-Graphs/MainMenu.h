#pragma once
#include "Graph.h"
#include "AdjacencyList.h"
#include "IncidenceMatrix.h"
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>

#include <string>
using namespace std;
class MainMenu
{
public:
	bool end;
	int W; //wierzcholki
	int E; //gestosc
	enum structureGraph {
		AdjList, InciMatrix
	}structure;
	enum mesType {
		treeM,pathM
	}measureType;
	Graph *graph;
	int GivenChoice;
	double* measureTab;
	double measurement;
	MainMenu();
	~MainMenu();
	//Menus
	void start();
	void tree();
	void path();
	void clearAndPause();
	void clear();
	void countAll();
	void count(structureGraph type,int verticles, int edges);
	int choice();
	void countMeasure();
	void measure(void(MainMenu::* function)(void));
	double timeCount(void(MainMenu::* function)(void));

	void kruskal();
	void prim();
	void dij();
	void bell();
	void reloadStructure();
	
};

