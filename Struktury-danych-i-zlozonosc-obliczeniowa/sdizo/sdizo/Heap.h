#pragma once
#include <iostream>
#include <string>
#include "Structure.h"
class Heap : public Structure
{//Fast Reminder
//  Root is on top and is the biggest int (1st index in array)
//  Left child of 'i' node is 2*i
// Right child of 'i' node is 2*i+1


private:
	std::string cr, cl, cp;
	int *array;
	int maxSize;
	
public:
	Heap(int startingSize);
	Heap();
	~Heap();
	//ADD Methods
	void addElement(int x); // add int to heap
	void addElementOnBeginning(int x);
	void addElementOnIndex(int x, int index);
	//DEl
	void deleteIndex(int index);

	int pop(); // return root 
	void clearAll(); //deletes array
	void deleteLastElement();
	void deleteFirst();
	void printAll(); // no parameter version of print for easy use
	int getVaule(int index);
	void massHeapSort();
	bool contains(int value); //checks if 'value' is in heap
	void deleteInt(int x);
protected:
	void heapSort(int index); // sorting
	void extendHeap(); // more space for heap
	int getParent(int index); // return parent id
	int getLeftChild(int index); // return left child id
	int getRightChild(int index); //returns right child id
	void print(std::string sp, std::string sn, int index);
	bool IsAHeap(); //tests if its a heap. compare parents with theis childern
	
};

