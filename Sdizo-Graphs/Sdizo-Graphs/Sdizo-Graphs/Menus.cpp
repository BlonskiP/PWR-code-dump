#include "stdafx.h"
#include "MainMenu.h"

void MainMenu::start()
{
	clear();
	cout << "Menu g³owne \n" << std::endl;
	cout << "1. Wczytaj Graf z Pliku" << std::endl;
	cout << "2. Generuj Graf Algorytmem" << std::endl;
	cout << "3. Poka¿ strukture: " << std::endl;
	cout << "4. Wykonaj Algorytmy szukania minimalnego drzewa" << std::endl;
	cout << "5. Wykonaj Algorytmy szukania drogi" << std::endl;
	cout << "6. Wykonaj obliczenia" << std::endl;
	cout << "7. Zmieñ ilosc wierzcholkow i gestosc" << std::endl;
	cout << "8. Zmien skierowanie" << std::endl;
	cout << "9. Zmien reprezentacje" << std::endl;
	cout << " W: " << graph->V << " E: " << graph->E << std::endl;
	cout << " Gestosc: " <<  (double)(graph->E)/(double)(graph->V*(graph->V-1))<< std::endl;
	GivenChoice = choice();
	switch (GivenChoice)
	{
	case 1: {
		graph->loadFromFile(); start();
		break;  }
	case 2: {
		reloadStructure();
		graph->generate(W,E);  break; }
	case 3: {graph->print(); graph->printArray(); system("Pause");  break; }
	case 4: {tree(); system("Pause");  break; }
	case 5: {path(); system("Pause");  break; }
	case 6: {countAll(); system("Pause"); break; }
	case 7: {
		cout << "Podaj liczbe wierzcholkow" << endl;
		W = choice();
		cout << " Podaj gestosc. np 25" << endl;
		double gest = choice();
		gest = gest / 100;
		int x = W * (W - 1);
		E = (int)((double)(gest)*(double)(x)); graph->generate(W,E); break; }
	case 8: {if (graph->directed)
		graph->directed = false;
			else
				graph->directed = true;
		graph->changeDir();
		
		start();
		break; }
	case 9: {
		if (structure == AdjList)structure = InciMatrix;
		else
			structure = AdjList;
		reloadStructure();
	
	}
	default:
		break;
	}

	if(end==false)start();
}