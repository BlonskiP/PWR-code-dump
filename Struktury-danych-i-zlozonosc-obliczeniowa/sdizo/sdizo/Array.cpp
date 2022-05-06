#include "Array.h"



Array::Array()
{
	arrayPointer = (int*)calloc(0, sizeof(int));
}
Array::Array(int size)
{
	maxSize = size;
	arrayPointer = (int*)calloc(size, sizeof(int));
}

Array::~Array()
{
	free(arrayPointer);
}

void Array::addElement(int x) 
{
	size++;
	extendArray(); //increase size by 1 and relocate the array
	
	arrayPointer[size - 1] = x;
}

void Array:: printAll() 
{
	
		for (int ArrayIndex = 0; ArrayIndex < size; ArrayIndex++)
		{
			printf("%i ", arrayPointer[ArrayIndex]);
		}
		printf("\n");
	

}
void Array::extendArray()
{
	if (maxSize <= size) //Check if extension and relocation is nessesery
	arrayPointer = (int*)realloc(arrayPointer, size * sizeof(int)); //memory block changes size. 
	if(maxSize<size)
	maxSize++;
}

void Array::addElementOnBeginning(int x)
{
	size++;
	extendArray();
	
	memmove(arrayPointer + 1, arrayPointer, (size - 1) * sizeof(int)); //Copies, moves the table leaves space for one int at the start
	*arrayPointer = x;
	
}
void Array::addElementOnIndex(int x, int index) 
{
	if (index < size && index >= 0) 
	{
		size++;
		extendArray();
		
		memmove(arrayPointer + index + 1, arrayPointer + index, (size - 1 - index) * sizeof(int));
		*(arrayPointer + index) = x;

	}
	else
		if (index == size)
		{
			addElement(x);
		}
		else if (index == 0)
		{
			addElementOnBeginning(x);
		}
		else {}
		//std::cout << "ERROR AT 'addOnIndex' method. Array is not large enough" << std::endl;
}
void Array::deleteInt(int x)
{
	for (int i = 0; i < size; i++)
	{
		if (*(arrayPointer + i) == x)
		{
			size--;
			maxSize--;
			memmove(arrayPointer + i, arrayPointer + i + 1, (size - i) * sizeof(int));
			arrayPointer = (int*)realloc(arrayPointer, size * sizeof(int));
			break;
		}

	}
	
}
bool Array::contains(int x) 
{
	for (int i = 0; i < size; i++) 
	{
		if (*(arrayPointer + i) == x)
		{
		//	std::cout << "found " << x << " Retured true" << std::endl;
			return true;
		}
	
	}
	//std::cout << "Coudn't find " << x << " Retured false" << std::endl;
	return false;
}
void Array::GetIndexes(int x) 
{
	if (contains(x))
		
	{
		std::cout << x << " found on indexes: ";
		for (int i = 0; i < size; i++) {
			if (*(arrayPointer + i) == x) 
			{
				std::cout << i << " ";
			}
			
		}
		std::cout << std::endl;

	}
	else
		std::cout << "THERE IS NO " << x << std::endl;

}
int Array::getVaule(int index) 
{
			return *(arrayPointer + index);
	
	
}

void Array::deleteLastElement()
{
	if (size > 0) {
		maxSize--;
		size--;
		arrayPointer = (int*)realloc(arrayPointer, size * sizeof(int));
	}
	else
	std::cout << "ERROR on delLast method. Array is empty" << std::endl;
}

void Array::deleteFirst()
{
	if (size > 0) {
		memmove(arrayPointer, arrayPointer + 1, (size * sizeof(int)));
		size--;
		maxSize--;
		arrayPointer = (int*)realloc(arrayPointer, size * sizeof(int));
	}
	else
	std::cout << "ERROR on delFirst method. Array is empty" << std::endl;
}

void Array::deleteIndex(int index)
{
	if (index < size && index >= 0)
	{
		size--;
		maxSize--;
	

		memmove(arrayPointer + index , arrayPointer + index+1, (size  - index) * sizeof(int));
		arrayPointer = (int*)realloc(arrayPointer, size * sizeof(int));

	}
	else if (size == 1 || index > size) { deleteLastElement(); }
			//std::cout << "ERROR AT 'dekOnIndex' method. Array is not large enough" << std::endl;

}

void Array::clearAll()
{
	if (size != 0) {
		free(arrayPointer);
		size = 0;
		maxSize = 0;
		arrayPointer = (int*)calloc(size+1, sizeof(int));
	}
}
