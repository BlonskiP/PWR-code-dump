#pragma once
#include <iostream>
#include <iomanip>
class Structure
{
public:
	//ADD METHODS
	virtual void addElement(int x) = 0;
	virtual void addElementOnIndex(int x, int index) = 0;
	virtual void addElementOnBeginning(int x) = 0;
	//DEL METHODS
	virtual void deleteLastElement() = 0;
	virtual void deleteIndex(int index) = 0;
	virtual	void deleteFirst() = 0;
	virtual	void printAll() = 0;
	virtual int getVaule(int index) = 0;
	virtual	void clearAll() = 0;
	virtual	bool contains(int x) = 0;
	virtual void deleteInt(int x) = 0;
	int size;
};

