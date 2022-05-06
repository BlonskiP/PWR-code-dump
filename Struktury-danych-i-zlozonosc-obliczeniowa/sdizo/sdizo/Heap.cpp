#include "Heap.h"



Heap::Heap(int startingSize)
{
	if (startingSize > 0) {
		size = 0;
		maxSize = startingSize;
		array = new int[maxSize];
	}
	else
	{
		size = 0;
		maxSize = 1;
		array = new int[maxSize];
	}
}

Heap::Heap()
{
	size = 0;
	maxSize = 1;
	array = new int[maxSize];
}


Heap::~Heap()
{
	delete[] array;
}

void Heap::heapSort(int index)
{
	int leftChild = getLeftChild(index);
	int rightChild = getRightChild(index);
	int largest = index;
	if (leftChild < size && array[leftChild]> array[largest])
		largest = leftChild;
	if (rightChild < size && array[rightChild] > array[largest])
		largest = rightChild;

	if (largest != index) //Typical swap algorithm
	{
		int temp = array[index];
		array[index] = array[largest];
		array[largest] = temp;
		heapSort(largest);
	}
}


void Heap::extendHeap()
{
	
	maxSize = maxSize * 2; //We will contain a lot of element so i want to make sure it's not so often used
	int *temp = new int[maxSize];
	for (int i = 0; i <= maxSize / 2; i++)
	{
		
		temp[i]= array[i];
	}
	array = temp;
} //DONE

void Heap::addElement(int x)
{
	if (size == maxSize) //make sure you have free space for new element. If not, increase max size and reloc array
	{
		extendHeap(); 
	}

	size++;
	
	int ElementIndex = size-1;
	array[ElementIndex] = x;
	int parentIndex = getParent(ElementIndex);
	while (ElementIndex > 0 && array[parentIndex] < array[ElementIndex]) //check if you are bigger than your parent
	{
		int temp = array[parentIndex]; //parent copy
		array[parentIndex] = array[ElementIndex]; //parent node is now child
		array[ElementIndex] = temp; //child node is now parent;
		ElementIndex = parentIndex;
		parentIndex= getParent(ElementIndex);
	}
}

void Heap::addElementOnBeginning(int x)
{
	
	int *temp = new int[maxSize+1];

	for (int i = 0; i <= size+1; i++)
	{

		temp[i+1] = array[i];
	}
	temp[0] = x;
	size++;
	array = temp;
	heapSort(0);
}

void Heap::addElementOnIndex(int x, int index)
{
	int *temp = new int[maxSize + 1];
	size++;
	for (int i = 0; i < index; i++)
	{
		temp[i] = array[i];
	}
	
	for (int i = index; i <= size ; i++)
	{

		temp[i+1] = array[i];
	}
	
	temp[index] = x;
	array = temp;
	contains(13);
	
	massHeapSort();
}

void Heap::deleteIndex(int index)
{
	int tmp = 0;
	for (int i = 0; i < size; i++) 
	{
		if (array[i] == index)
		{
			tmp = i;
		}
	}

for (int i = tmp; i <= size-1; i++)
		{

	array[i] = array[i + 1];
		}
	size--;	
	massHeapSort();
	
}

int Heap::pop()
{
	if (size == 1) 
	{
		size--;
		return array[0];
	}
	int root = array[0];
	array[0] = array[size - 1];
	size--;
	heapSort(0);
	return root;
}

void Heap::clearAll()
{
	delete[] array;
	size = 0;
	maxSize = 1;
	array = new int[maxSize];
}

void Heap::deleteLastElement()
{
	array[size - 1] = 0;
	size--;
}

void Heap::deleteFirst()
{
	pop();
}

void Heap::print(std::string sp, std::string sn, int index)
{
	

	cr = cl = cp = "  ";
	cr[0] = 218;
	cr[1] = 196;
	cl[0] = 192; 
	cl[1] = 196;
	cp[0] = 179;
	std::string s;
	if (index < size)
	{
		s = sp;
		if (sn == cr) s[s.length() - 2] = ' ';
		print(s + cp, cr, 2 * index + 2);

		s = s.substr(0, sp.length() - 2);

		std::cout << s << sn << " " <<array[index] << std::endl;

		s = sp;
		if (sn == cl) s[s.length() - 2] = ' ';
		print(s + cp, cl, 2 * index + 1);
	}

}

int Heap::getParent(int index)
{
	int parentIndex = (index - 1) / 2;
	return parentIndex;
}

int Heap::getLeftChild(int index)
{
	int leftChildIndex = 2 * index + 1;
	return leftChildIndex;
}

int Heap::getRightChild(int index)
{
	int rightChildIndex = 2 * index + 2;
	return rightChildIndex;
}

void Heap::printAll()
{
	print("", "", 0);
	IsAHeap();
}

int Heap::getVaule(int index)
{
	return array[index];
}


bool Heap::contains(int value)
{
	
	for (int i = 0; i < size; i++)
	{
		if (array[i] == value)
			return true;
	}
	
	return false;

	
}

void Heap::deleteInt(int x)
{
	int tmp = 0;
	for (int i = 0; i < size; i++)
	{
		if (array[i] == x)
		{
			tmp = i;
		}
	}

	for (int i = tmp; i <= size - 1; i++)
	{

		array[i] = array[i + 1];
	}
	size--;
	massHeapSort();
}

bool Heap::IsAHeap() {
	int parent;
	for (int i = 0; i < size; i++)
	{
		parent = getParent(i);
		if (array[i] > array[parent] ) {
		//	std::cout << "It's not a heap!ERROR" << std::endl;
			//std::cout << array[i] <<"is bigger than his parent: " << array[parent] << std::endl;
			return false;
		}
		
	}
	//std::cout << "It's  a heap! for sureee" << std::endl; //For debug
	return true;

}

void Heap::massHeapSort()
{
	for (int i = 0; i < size; i++) {
		heapSort(i);
		
	}
	IsAHeap();
}