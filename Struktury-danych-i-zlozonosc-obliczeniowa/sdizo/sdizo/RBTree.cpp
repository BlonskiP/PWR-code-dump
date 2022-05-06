#include "RBTree.h"



RBTree::RBTree()
{
	hOut = GetStdHandle(STD_OUTPUT_HANDLE); //Handle is our console now
	cr = cl = cp = "  ";
	cr[0] = 218; cr[1] = 196;
	cl[0] = 192; cl[1] = 196;
	cp[0] = 179;
	// Guard is initialized
	guard.color = black; //always black         
	guard.parent = &guard; //all guards pointers points himself
	guard.left = &guard;
	guard.right = &guard;
	root = &guard;     // When there is no nodes. Root will point guard
	size = 0;

}


RBTree::~RBTree()
{
	clearAll();
}

void RBTree::print(std::string sp, std::string sn, Node * pointer)
{
		std::string t;

		if (pointer != &guard)
		{
			t = sp;
			if (sn == cr) t[t.length() - 2] = ' ';
			print(t + cp, cr, pointer->right);

			t = t.substr(0, sp.length() - 2);
			std::cout << t << sn << ":";
			if (pointer->color == red)SetConsoleTextAttribute(hOut, FOREGROUND_RED);
			else  SetConsoleTextAttribute(hOut, FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
			std::cout <<pointer->value << std::endl;
			SetConsoleTextAttribute(hOut, FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
			t = sp;
			if (sn == cl) t[t.length() - 2] = ' ';
			print(t + cp, cl, pointer->left);
		}
}

void RBTree::rotateRight(Node * node)
{
	Node *son, *parent;

	son = node->left;
	if (son != &guard)
	{
		parent = node->parent;
		node->left = son->right;
		if (node->left != &guard)
			node->left->parent = node;

		son->right= node;
		son->parent = parent;
		node->parent =son;
		if (parent != &guard)
		{
			if (parent->left == node)
				parent->left = son;
			else
				parent->right =son;
		}
		else root = son;

	}

}

void RBTree::rotateLeft(Node * node)
{
	Node *brother, *parent;

	brother = node->right;
	if (brother != &guard)
	{
		parent = node->parent;
		node->right = brother->left;
		if (node->right != &guard)
			node->right->parent = node;

		brother->left = node;
		brother->parent = parent;
		node->parent = brother;
		if (parent != &guard)
		{
			if (parent->left == node)
				parent->left = brother;
			else
				parent->right = brother;
		}
		else root = brother;

	}
}

void RBTree::addElement(int x)
{
	size++;
	Node * newNode, *uncle;
	newNode = new Node();
	newNode->left = &guard;//new nodes childer should be guard
	newNode->right = &guard;
	newNode->parent = root;
	newNode->value = x;
	if (newNode->parent == &guard) root = newNode; //If there is no other node. New node is root
	else
		while (true)
		{
			if (newNode->value < newNode->parent->value)
			{
				if (newNode->parent->left == &guard)
				{
					newNode->parent->left = newNode;
					break;
				}
				newNode->parent = newNode->parent->left;
			}
			else
			{
				if (newNode->parent->right == &guard)
				{
					newNode->parent->right = newNode;
					break;
				}
				newNode->parent = newNode->parent->right;
			}

		}
	newNode->color = red; // newNodes are always red. Later they can be recolored
	while ((newNode != root) && (newNode->parent->color == red))
	{
		if (newNode->parent == newNode->parent->parent->left)
		{
			uncle = newNode->parent->parent->right;

			if (uncle->color == red) //first situation
			{
				newNode->parent->color = black;
				uncle->color = black;
				newNode->parent->parent->color = red;
				newNode = newNode->parent->parent;
				continue;
			}
			if (newNode == newNode->parent->right) //2nd sitaution
			{
				newNode = newNode->parent;
				rotateLeft(newNode);
			}
			newNode->parent->color = black;
			newNode->parent->parent->color = red;
			rotateRight(newNode->parent->parent);
			break;
		}
		else
		{
			uncle = newNode->parent->parent->left; // mirror uncle
			if (uncle->color == red)
			{
				newNode->parent->color = black;
				uncle->color = black;
				newNode->parent->parent->color = red;
				newNode = newNode->parent->parent;
				continue;
			}
			if (newNode == newNode->parent->left)
			{
				newNode = newNode->parent;
				rotateRight(newNode);
			}
			newNode->parent->color = black;
			newNode->parent->parent->color = red;
			rotateLeft(newNode->parent->parent);
			break;
		}
	}
	root->color = black; // root always black;
}

void RBTree::addElementOnIndex(int x, int index)
{
}

void RBTree::addElementOnBeginning(int x)
{
}

void RBTree::deleteNode(Node *node)
{
	size--;
	Node * W, *Y, *Z;

	if ((node->left == &guard) || (node->right == &guard))
		Y = node;
	else                                  
		Y = succesor(node);

	if (Y->left != &guard) 
		Z = Y->left;
	else            
		Z = Y->right;

	Z->parent = Y->parent;

	if (Y->parent == &guard) 
		root = Z;
	else 
		if (Y == Y->parent->left) 
				Y->parent->left = Z;
	else                     
		Y->parent->right = Z;

	if (Y != node) 
		node->value = Y->value;

	if (Y->color == 'B')  
		while ((Z != root) && (Z->color == 'B'))
			if (Z == Z->parent->left)
			{
				W = Z->parent->right;

				if (W->color == 'R')
				{              // situation 1
					W->color = black;
					Z->parent->color = red;
					rotateLeft(Z->parent);
					W = Z->parent->right;
				}

				if ((W->left->color == 'B') && (W->right->color == 'B'))
				{              // situation 2
					W->color = red;
					Z = Z->parent;
					continue;
				}

				if (W->right->color == 'B')
				{              // situation 3
					W->left->color = black;
					W->color = red;
					rotateRight(W);
					W = Z->parent->right;
				}

				W->color = Z->parent->color; // situation 4
				Z->parent->color = black;
				W->right->color = black;
				rotateLeft(Z->parent);
				Z = root;        
			}
			else
			{                // Mirror
				W = Z->parent->left;

				if (W->color == 'R')
				{              // situation 1
					W->color = black;
					Z->parent->color = red;
					rotateRight(Z->parent);
					W = Z->parent->left;
				}

				if ((W->left->color == 'B') && (W->right->color == 'B'))
				{              // situation 2
					W->color = red;
					Z = Z->parent;
					continue;
				}

				if (W->left->color == 'B')
				{              // situation 3
					W->right->color = black;
					W->color = red;
					rotateLeft(W);
					W = Z->parent->left;
				}

				W->color = Z->parent->color;  // situation 4
				Z->parent->color = black;
				W->left->color = black;
				rotateRight(Z->parent);
				Z = root;        
			}

	Z->color = black;

	delete Y;
}

Node *RBTree::succesor(Node * node)
{
	Node* temp;
	if (node != &guard)
	{
		if (node->right != &guard) return minNode(node->right);
		else
		{
			temp = node->parent;
			while ((temp != &guard) && (node == temp->right))
			{
				node = temp;
				temp = temp->parent;
			}
			return temp;
		}
	}
	return &guard;
}

Node * RBTree::minNode(Node * node)
{
	if (node != &guard)
		while (node->left != &guard) node = node->left;

	return node;
	
}

Node * RBTree::findNodeWithValue(int value)
{
	Node *temp;
	temp = root;
	while ((temp != &guard) && (temp->value != value))
	if (value < temp->value)
		temp = temp->left;
	else
		temp = temp->right;
	if (temp == &guard) return NULL;
	return temp;
}

void RBTree::clearNode(Node * node)
{
	if (node != &guard)
	{
		clearNode(node->left);   // usuwamy lewe poddrzewo
		clearNode(node->right);  // usuwamy prawe poddrzewo
		delete node;              // usuwamy sam wêze³
	}
}

void RBTree::deleteLastElement()
{


}

void RBTree::deleteIndex(int index)
{
	
}

void RBTree::deleteInt(int x)
{
	Node *temp = findNodeWithValue(x);
	if (temp != nullptr)
		deleteNode(temp);
}

void RBTree::deleteFirst()
{
	deleteNode(root);
}

void RBTree::printAll()
{
	print("", "", root);
}

int RBTree::getVaule(int index) //method used for rewriting only
{
	if (size > 0) {
		int temp;
		temp = root->value;
		deleteNode(root);
		return temp;
	}

}

void RBTree::clearAll()
{	
	if (root != &guard)
	{
		clearNode(root->left);   // usuwamy lewe poddrzewo
		clearNode(root->right);  // usuwamy prawe poddrzewo
		delete root;              // usuwamy sam wêze³
		guard.color = black; //always black         
		guard.parent = &guard; //all guards pointers points himself
		guard.left = &guard;
		guard.right = &guard;
		root = &guard;     // When there is no nodes. Root will point guard
		size = 0;

	}


}

bool RBTree::contains(int x)
{
	if (findNodeWithValue(x) != nullptr)
	{
		return true;
	}
	else
		return false;
}
