#ifndef MAP_H_
#define MAP_H_

class Map {
public:
	Map(int x, int y);
	virtual ~Map();
	int sizeX;
	int sizeY;
	void update();
	char** symbols;
	void symbolsInit();
};

#endif /* MAP_H_ */
