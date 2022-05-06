#include "Manager.h"

void Manager::mainMenu()
{

#undef max
	outPutStars();
	std::cout << "Welcome. Its a project made by Piotr Blonski" << std::endl;
	std::cout << "It will measure speed of operations on data structures which I implemented" << std::endl;
	std::cout << "Which one do you want to check?" << std::endl;
	std::cout << "1. Array" << std::endl;
	std::cout << "2. List" << std::endl;
	std::cout << "3. Heap" << std::endl;
	std::cout << "4. Red Black Tree" << std::endl;
	std::cout << "0. EXIT" << std::endl;
	outPutStars();
	std::cout << std::endl;
	while (!(std::cin >> choice)) {
		std::cin.clear();
		std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
		std::cout << "Invalid input.  Try again: ";
	}
	switch (choice)
	{
	case 1:structureType = array;  break;
	case 2:structureType = list; break;
	case 3:structureType = heap; break;
	case 4:structureType = redBlackTree; break;
	case 0: exit = true; break;
	default:
	{system("cls");
	std::cout << "ERROR. Give me 1, 2 or 3 to precede" << std::endl;
	mainMenu();
	}
	}
	if (exit == false)
		structureMenu();


}

void Manager::structureMenu()
{
	system("cls");
	delete measurementTab;
	measurementTab = new int[numberMeasurments]; //clear table
#undef max
	outPutStars();
	std::cout << "It will measure speed of operations on data structures which I implemented" << std::endl;

	if (structureExist == true) {
		structure->clearAll();
		if (structureType == redBlackTree || structureType == heap) treeMeasureMenu();
		else normMeasureMenu();
	}
	else {
		std::cout << "We will create Structure now." << std::endl;
		setStructurePointer();
	}




}

void Manager::manualMode()
{
	system("cls");
	structureSize = structure->size;
	if (structureExist == false) {
		switch (structureType)
		{
		case list: { listPointer = new List(); structure = listPointer;  break; }
		case heap: { heapPointer = new Heap(); structure = heapPointer;  break; }
		case array: { arrayPointer = new Array(); structure = arrayPointer;  break; }
		case redBlackTree: {treePointer = new RBTree(); structure = treePointer;  break; }
		}
		structureSize = 0;
		structureExist = true;
	}
	std::cout << "Welcome to Manual Mode" << std::endl;
	std::cout << "Here you wil be able to manipulate the structure!" << std::endl;
	std::cout << "Your structure is: " << std::endl;
	switch (structureType)
	{
	case list: {std::cout << "List" << std::endl; break; }
	case array: {std::cout << "Array" << std::endl; break; }
	case heap: {std::cout << "Heap" << std::endl; break; }
	case redBlackTree: { std::cout << "Red Black Tree" << std::endl; break; }
	}
	std::cout << "Actual Size is: " << structureSize << std::endl;
	if (structureType == heap || structureType == redBlackTree)
		treesMenu();
	else
		manualMenu();
	{
		structureSize = 10;
		structureMenu();
	}
}


void Manager::treesMenu() {
	std::cout << "1. Print Structure " << std::endl;
	std::cout << "2. Add element" << std::endl;
	std::cout << "3. delete element from structure" << std::endl;
	std::cout << "4. delete all same elements (int) from structure" << std::endl;
	std::cout << "5. Check if int is in structure" << std::endl;
	std::cout << "6. Change Structure" << std::endl;
	std::cout << "7. Load Structure form txt file" << std::endl;
	std::cout << "8. Fill With random" << std::endl;
	std::cout << "9. Clear All" << std::endl;
	std::cout << "0. Exit to Main Menu " << std::endl;
	int choice = 0;
	bool exit = false;
	while (exit == false)
	{
		int choice = makeChoice();
		if (choice >= 0 && choice <= 9) {}
		else {
			system("cls");
			manualMode();
		}
		switch (choice) {
		case 0: {exit = true; break; }
		case 1: {structure->printAll();
			system("Pause");
			manualMode();
			break; }
		case 2: {getNumber(); structure->addElement(givenInt); structureSize = structure->size; manualMode(); break; }
		case 3: {
			if (structureSize <= 0)
			{
			std::cout << "Structure is empty" << std::endl;
			break;
			}
			else
			{
				std::cout << "I will delete given int if it exist" << std::endl;
				getNumber();
				structure->deleteInt(givenInt);
			}
			manualMode();
			break; }
		case 4: {
			if (structureSize <= 0)
			{
				std::cout << "Structure is empty" << std::endl;
				break;
			}
			else {
				std::cout << "I will delete given int if it exist" << std::endl;
				getNumber();
				while (structure->contains(givenInt)) 
				{
					structure->deleteInt(givenInt);
				}
			
			}
			
			manualMode(); break; }
		case 5: {manualModeCheckIfIntExist(); manualMode(); break; }
		case 6: {manualModeStructureChange(); manualMode(); break; }
		case 7: {manualModeStructureFromFile(); manualMode(); break; }
		case 8: {manualModeFillStructure(); manualMode(); break; }
		case 9: {structure->clearAll(); manualMode(); break; }
		}
	}
}

void Manager::manualMenu() {
	std::cout << "1. Print Structure " << std::endl;
	std::cout << "2. Add element on end" << std::endl;
	std::cout << "3. Add element on beginning" << std::endl;
	std::cout << "4. Add element on on index" << std::endl;
	std::cout << "5. delete element from structure" << std::endl;
	std::cout << "6. delete all same elements (int) from structure" << std::endl;
	std::cout << "7. delete index element from structure" << std::endl;
	std::cout << "8. Check if int is in structure" << std::endl;
	std::cout << "9. Get vaule from index" << std::endl;
	std::cout << "10. Change Structure" << std::endl;
	std::cout << "11. Load Structure form txt file" << std::endl;
	std::cout << "12. Fill With random" << std::endl;
	std::cout << "13. Clear ALL" << std::endl;
	std::cout << "0. Exit to Main Menu " << std::endl;
	int choice = 0;
	bool exit = false;
	while (exit == false)
	{
		int choice = makeChoice();
		if (choice >= 0 && choice <= 13) {}
		else {
			system("cls");
			manualMenu();
		}
		switch (choice) {
		case 0: {exit = true; break; }
		case 1: {structure->printAll();
			system("Pause");
			system("cls");
			manualMode();
			break; }
		case 2: {getNumber(); structure->addElement(givenInt);  manualMode(); break; }
		case 3: {getNumber(); structure->addElementOnBeginning(givenInt); manualMode(); break; }
		case 4: {getNumber(); getIndex(); structure->addElementOnIndex(givenInt, index); manualMode(); break; }
		case 5: {getNumber(); structure->deleteInt(givenInt); manualMode(); break; }
		case 6: {if (structureSize <= 0)
		{
			std::cout << "Structure is empty" << std::endl;
			break;
		}
				else 
				{
					std::cout << "I will delete given int if it exist" << std::endl;
					getNumber();
					while (structure->contains(givenInt))
					{
						structure->deleteInt(givenInt);
					}

				} manualMode(); break; }
		case 7: {
			if (structureSize <= 0)
			{
				std::cout << "Structure is empty" << std::endl;
				break;
			}
			else
			{
				std::cout << "I will delete given int if it exist" << std::endl;
				getNumber();
				structure->deleteIndex(givenInt);
			}
			manualMode();
			break;
		}
		case 8: {manualModeCheckIfIntExist(); manualMode(); break; }
		case 9: {getNumber(); 
			if (givenInt < 0) { std::cout<<"Give indx bigger than 0";  break; }
			else
			if (structureSize > 0 && givenInt < structureSize) {
			std::cout << "Index: " << givenInt << " Value: " << structure->getVaule(givenInt) << std::endl;
		
		} break; }
		case 10: {manualModeStructureChange(); manualMode(); break; }
		case 11: {manualModeStructureFromFile(); manualMode(); break; }
		case 12: {manualModeFillStructure(); manualMode(); break; }
		case 13: { {structure->clearAll(); manualMode(); break; }}

		}
	}
}

int Manager::makeChoice() {
	int choice;
	#undef max
				while (!(std::cin >> choice)) {
					std::cin.clear();
					std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
					std::cout << "Invalid input.  Try again: ";
				}
				return choice;

}
void Manager::manualModeCheckIfIntExist() {
	getNumber();
	if (structure->contains(givenInt))
	std::cout << "FOUND IT! There is a: " << givenInt << "in structure" << std::endl;
	else
    std::cout << " There is no: " << givenInt << " in structure" << std::endl;
					system("Pause");

	
}

void Manager::manualModeStructureChange() {
	system("cls");
	std::cout << "You will change structure now. I will rewrite a structure" << std::endl;
	type newType = structureType;
	std::cout << "What type should be a new structure?" << std::endl;
	std::cout << "1.List" << std::endl;
	std::cout << "2.Heap" << std::endl;
	std::cout << "3.Array" << std::endl;
	std::cout << "4.Red-Black Tree" << std::endl;
    std::cout << "0.Return" << std::endl;
	int choice = makeChoice();
	if (choice > 0 && choice <= 4)
	{
	
		switch (choice)
		{
		case 1: {newType = list; break; }
		case 2: {newType = heap; break; }
		case 3: {newType = array; break; }
		case 4: {newType = redBlackTree; break; }
		case 0: {break; }
		}
		rewriteStructure(newType);
		structureType = newType;
	}
	else
	{
		system("cls");
		std::cout << "ERROR Give me 0 - 4" << std::endl;
		manualModeStructureChange();
	}
}

void Manager::manualModeStructureFromFile(){

	std::cout << "Give me the file name" << std::endl;
	std::string fileName;
	std::cin >> fileName;
	std::cout << fileName;
	std::fstream file;
	file.open(fileName);
	if (file.is_open())
	{
		std::cout << "The file has been loaded" << std::endl;
		std::string line;
		getline(file, line);
		//Geting 1st line as size
		structure->clearAll();
		int StructureFileSize;
		StructureFileSize = std::stoi(line);
		for (int i = 0; i < StructureFileSize; i++)
			{
			getline(file, line);
			structure->addElement(std::stoi(line));
			}
	}
	else
	std::cout << " ERROR. Coudn't load the file" << std::endl;
	system("Pause");


}

void Manager::manualModeFillStructure() {
	std::cout << "Give structure size" << std::endl;
	int newStructureSize = makeChoice();
	if (newStructureSize > 0) {
		structure->clearAll();
		structureSize = newStructureSize;
		createArrayOfElements();
		fillWithRandom();
	}
	else
		std::cout << "You can't have - size structure" << std::endl;
	system("Pause");
	
}