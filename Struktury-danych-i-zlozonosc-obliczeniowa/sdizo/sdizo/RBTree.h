#pragma once
#include "Structure.h"
#include <string>
#include <windows.h> //for coloring console
enum nodeColor {
	black, red

};

struct Node 
{
	Node *parent;
	Node *left;
	Node *right;
	int value;
	nodeColor color;
};




class RBTree : public Structure
{


public:
	//ADD METHODS
	void addElement(int x); //done
	void addElementOnIndex(int x, int index);
	void addElementOnBeginning(int x);
	//DEL METHODS
	void deleteLastElement();
	void deleteIndex(int index);
	void deleteInt(int x);
	void deleteFirst();
	void printAll();
	int getVaule(int index);
	void clearAll();
	bool contains(int x);
	RBTree();
	~RBTree();
private:
	HANDLE hOut;//console handle for colors
	Node guard;
	Node * root;
	std::string cr, cl, cp;
	void print(std::string sp, std::string sn, Node * p); //Same in heap
	void rotateRight(Node *node);
	void rotateLeft(Node *node);
	void deleteNode(Node *node);
	Node  *succesor(Node *node);
	Node  *minNode(Node *node); //finds lowest node
	Node  *findNodeWithValue(int index);
	void clearNode(Node *node);
};

