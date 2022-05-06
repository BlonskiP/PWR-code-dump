#include <iostream>
#include "Array.h"
int main() {
	Array *testArray=new Array();
	Array *sizeTestArray=new Array(5);
	testArray->addInt(21);
	testArray->addInt(32);
	testArray->addInt(32);
	testArray->addInt(32);
	testArray->addInt(32);
	testArray->addInt(32);
	testArray->addInt(12);
	testArray->addInt(55);
	testArray->addInt(32);
	testArray->printAll();
	
	testArray->delFirst();
	testArray->printAll();
	testArray->delOnIndex(3);
	testArray->printAll();
	testArray->delLast();
	testArray->printAll();

	

	system("PAUSE");
}