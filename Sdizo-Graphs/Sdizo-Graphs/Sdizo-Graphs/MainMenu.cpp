#include "stdafx.h"
#include "MainMenu.h"

//TIME COUNT

MainMenu::MainMenu()
{
	structure = InciMatrix;
	W = 20;
	E = E = (int)(0.25 * (W*(W - 1)));// %
	if (structure == AdjList)
		graph = new AdjacencyList(true);
	else
		graph = new IncidenceMatrix(true);
	measureType = treeM;
	
	graph->changeDir();
}


MainMenu::~MainMenu()
{
	delete graph;

}



int MainMenu::choice()
{
	int choice;
#undef max
	while (!(std::cin >> choice)) {
		std::cin.clear();
		std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
		std::cout << "Invalid input.  Try again: ";
	}
	return choice;
}

void MainMenu::tree() {
	graph->directed = false;
	graph->changeDir();
	graph->MST();

}
void MainMenu::path()
{
	graph->directed = true;
	graph->changeDir();
	graph->path();
}
void MainMenu::clearAndPause() {
	

}
void MainMenu::clear() {
	system("cls");

}

void MainMenu::countAll()
{
	////25%
	//W = 10;  E = (int)(0.25 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 25; E = (int)(0.25 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 50; E = (int)(0.25 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 75; E = (int)(0.25 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 100; E = (int)(0.25 * (W*(W - 1)));
	//count(AdjList, W, E);
	////50%
	//W = 10;  E = (int)(0.50 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 25; E = (int)(0.50 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 50; E = (int)(0.50 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 75; E = (int)(0.50 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 100; E = (int)(0.50 * (W*(W - 1)));
	//count(AdjList, W, E);
	////75%
	//W = 10;  E = (int)(0.75 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 25; E = (int)(0.75 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 50; E = (int)(0.75 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 75; E = (int)(0.75 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 100; E = (int)(0.75 * (W*(W - 1)));
	//count(AdjList, W, E);
	////99%
	//W = 10;  E = (int)(0.99 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 25; E = (int)(0.99 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 50; E = (int)(0.99 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 75; E = (int)(0.99 * (W*(W - 1)));
	//count(AdjList, W, E);
	//W = 100; E = (int)(0.99 * (W*(W - 1)));
	//count(AdjList, W, E);

	////MATRIX
	//structure = InciMatrix;
	//W = 10;  E = (int)(0.25 * (W*(W - 1))); // 25%
	//count(InciMatrix, W, E);
	//W = 25; E = (int)(0.25 * (W*(W - 1))); // 25%
	//count(InciMatrix, W, E);
	//W = 50; E = (int)(0.25 * (W*(W - 1))); // 25%
	//count(InciMatrix, W, E);
	//W = 75; E = (int)(0.25 * (W*(W - 1))); // 25%
	//count(InciMatrix, W, E);
	//W = 100; E = (int)(0.25 * (W*(W - 1))); // 25%
	//count(InciMatrix, W, E);
	////50%
	//W = 10;  E = (int)(0.50 * (W*(W - 1)));
	//count(InciMatrix, W, E);
	//W = 25; E = (int)(0.50 * (W*(W - 1)));
	//count(InciMatrix, W, E);
	//W = 50; E = (int)(0.50 * (W*(W - 1)));
	//count(InciMatrix, W, E);
	//W = 75; E = (int)(0.50 * (W*(W - 1)));
	//count(InciMatrix, W, E);
	//W = 100; E = (int)(0.50 * (W*(W - 1)));
	//count(InciMatrix, W, E);
	////75%
	//W = 10;  E = (int)(0.75 * (W*(W - 1)));
	//count(InciMatrix, W, E);
	//W = 25; E = (int)(0.75 * (W*(W - 1)));
	//count(InciMatrix, W, E);
	//W = 50; E = (int)(0.75 * (W*(W - 1)));
	//count(InciMatrix, W, E);
	//W = 75; E = (int)(0.75 * (W*(W - 1)));
	//count(InciMatrix, W, E);
	//W = 100; E = (int)(0.75 * (W*(W - 1)));
	//count(InciMatrix, W, E);
	////99%
	//W = 10;  E = (int)(0.99 * (W*(W - 1)));
	//count(InciMatrix, W, E);
	//W = 25; E = (int)(0.99 * (W*(W - 1)));
	//count(InciMatrix, W, E);
	//W = 50; E = (int)(0.99 * (W*(W - 1)));
	//count(InciMatrix, W, E);
	W = 75; E = (int)(0.99 * (W*(W - 1)));
	count(InciMatrix, W, E);
	W = 100; E = (int)(0.99 * (W*(W - 1)));
	count(InciMatrix, W, E);
	
}

void MainMenu::count(structureGraph type, int verticles, int edges)
{
	std::ofstream output("result.txt", std::ios::app);
	std::cout << "\n";
	std::cout << "*****************************";
	std::cout << "\n";
	W = verticles;
	E = edges;
	if (type == AdjList) output << "Lista sasiedzctwa" << endl;
	else output << "Macierz incydencji" << endl;

	output << "W :" << W;
	output << "E :" << E;
	output << " gestosc: " << round((double)(edges)*100 / (double)(verticles*(verticles - 1))) <<"%" << std::endl;
	measureType = treeM;
	measure(&MainMenu::kruskal);
	output << "Kruskal: " << measurement << "[ms]" << endl;
	measure(&MainMenu::prim);
	output << "Prim: " << measurement << "[ms] " << endl;
	measureType = pathM;
	measure(&MainMenu::dij);
	output << "Dijkstra: " << measurement << "[ms]" << endl;
	measure(&MainMenu::bell);
	output << "Bellman-Ford: " << measurement << "[ms]" << endl;
	output << endl;
	output << endl;
	output << endl;
	output.close();
}

void MainMenu::countMeasure()
{
	measurement = 0;
	for (int i = 0; i < 100; i++) {
		measurement += measureTab[i];
	}
	measurement = measurement / 100;
}

void MainMenu::measure(void(MainMenu::* function)(void))
{
	measureTab = new double[100];
	for (int i = 0; i < 100; i++)
	{
		
		reloadStructure();
		
		if (measureType == treeM)graph->directed = false;
		else graph->directed = true;
		graph->generate(W,E);
		measureTab[i] = timeCount(function);
		
		
	}
	countMeasure();
	delete[] measureTab;
	
}
//Time counting
long long int read_QPC()
{
	LARGE_INTEGER count;
	DWORD_PTR oldmask = SetThreadAffinityMask(GetCurrentThread(), 0);
	QueryPerformanceCounter(&count);
	SetThreadAffinityMask(GetCurrentThread(), oldmask);
	return((long long int)count.QuadPart);
}

double MainMenu::timeCount(void(MainMenu::* function)(void))
{
	double measure = 0;
	long long int frequency, start, elapsed;
	QueryPerformanceFrequency((LARGE_INTEGER *)&frequency);
	start = read_QPC();
	(this->*function)();
	elapsed = read_QPC() - start;
	//	std::cout << "Time [s] = " << std::fixed << std::setprecision(3) << (float)elapsed / frequency << std::endl;
	//	std::cout << "Time [ms] = " << std::setprecision(0) << (1000.0 * elapsed) / frequency << std::endl;
	//	std::cout << "Time [us] = " << std::setprecision(0) << (1000000.0 * elapsed) / frequency << std::endl << std::endl;
	measure = (1000.0 * elapsed) / frequency;
	return measure;
}

void MainMenu::kruskal()
{

	graph->kruskalSolver();
	
}

void MainMenu::prim()
{
	graph->primSolver();
}

void MainMenu::dij()
{
	graph->dijSolver();
}

void MainMenu::bell()
{
	graph->bellSolver();
}

void MainMenu::reloadStructure()
{	delete graph;
	if (structure == AdjList)
		graph = new AdjacencyList(true);
	else
		graph = new IncidenceMatrix(true);
}
