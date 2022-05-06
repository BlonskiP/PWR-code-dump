#pragma once
#include <cstdlib>
#include <stdio.h>
#include <iostream>
#include <string.h>
#include "Structure.h"
class Array : public Structure
{
private:
	int maxSize = 0;
	int* arrayPointer;
public:
	//Contructors
	Array();
	Array(int size);
	~Array();
	//Add fuctions
	void addElement(int x);
	void addElementOnBeginning(int x);
	void addElementOnIndex(int x, int index);
	void deleteInt(int x);

	
	
	//Searching
	bool contains(int x);
	
	int getVaule(int index);
	void printAll();
	//Delete form array
	void deleteLastElement();
	void deleteFirst();
	void deleteIndex(int index);
	void clearAll();
	//Private array fuctions
private:
	void extendArray(); //Extends and reloc array
	void GetIndexes(int x); // test method
	
};

