#pragma once
#include <iostream>
#include <ctime>
#include <Windows.h>
#include <iomanip>
#include <fstream>
#include <string>
#include <limits> //for only int input
//My structures
#include "Structure.h"
#include "List.h"
#include "Array.h"
#include "Heap.h"
#include "RBTree.h"

class Manager
{
private:
	
	Structure *structure;
	List * listPointer;
	Heap * heapPointer;
	Array * arrayPointer;
	RBTree * treePointer;
	enum type {
		list, heap, array,redBlackTree
	}structureType;
	bool structureExist;
	bool found;
	bool exit;
	int index, givenInt, choice;
	int structureSize = 10;
	int measurement;
	int *measurementTab;
	int numberMeasurments=0;
	enum addSub {
		indexType, beginning, end
	}operationType = indexType;

public:
	int *elementsArray; // Contains random Ints to be put in structure
	//Constructor&Destructor
	Manager();
	~Manager();
	//Menus
	void mainMenu();
	void structureMenu();
	void manualMode();
	void treesMenu();
	void manualMenu();
	int makeChoice();
	void manualModeCheckIfIntExist();
	void manualModeStructureChange();
	void manualModeStructureFromFile();
	void manualModeFillStructure();
	//Counter
	int timeCount(void (Manager::*function)(void)); //counts time for target funtion
	//Creation
	void setStructurePointer();
	void createStructure();
	void fillWithRandom();
	void addOnEnd();
	void fillOnRandomIndex();
	void addOnBeginning();
	void deleteRandom();
	void deleteFirst();
	void deleteLast();
	void containsRandom();
	void IsOnIndex();
	//Utility
	void createArrayOfElements();
	void outPutStars();
	int getNumber();
	int getIndex();
	void ManualModeAddIndexChoose();
	void ManualModeSubIndexChoose();
	void rewriteStructure(enum type);
	//Measure
	void measureADD();
	void measureADDEND();
	void measureADDINDEX();
	void measureDEL();
	void measureDELEND();
	void measureFindIndex();
	void measureContains();
	void setMeasureTabSize();
	void setStructureSize();
	void countMeasure();
	void setaddSubType();
	void treeMeasureMenu();
	void measureDELINDEX();
	void normMeasureMenu();
	void changeMeasureStructure();
};

