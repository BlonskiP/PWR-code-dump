#include <iostream>
#include "Heap.h"
int main() {

	Heap testHeap(10);
	for (int i = 0; i <= 100; i++)
	{
		testHeap.push(i);
	}

	testHeap.pop();
	

	testHeap.print();
	testHeap.IsAHeap();
	system("Pause");
	return 0;
}