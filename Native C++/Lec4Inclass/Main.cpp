#include <iostream>
#include <vector>
#include "LevelManager.h"
#include "GameObject.h"

int main()
{
	LevelManager levelManager = LevelManager();
	Level testLevel = Level();
	std::vector<GameObject> objList;
	GameObject obj1 = GameObject();
	GameObject obj2 = GameObject();
	GameObject obj3 = GameObject();

	objList.push_back(obj1);
	objList.push_back(obj2);
	objList.push_back(obj3);

	for (int i = 0; i < objList.size(); i++) {
		objList[i].SetID(i);
	}

	std::cout << "Finished initializing test objects." << std::endl;

	for (int i = 0; i < objList.size(); i++) {
		std::cout << "ID: " << objList[i].GetID() << std::endl;
		std::cout << "Position: " << objList[i].GetPosition().x << " " << objList[i].GetPosition().y << " " << objList[i].GetPosition().z << std::endl;
		std::cout << "Rotation: " << objList[i].GetRotation().x << " " << objList[i].GetRotation().y << " " << objList[i].GetRotation().z << " " << objList[i].GetRotation().w << std::endl;
		std::cout << "Scale:    " << objList[i].GetScale() << std::endl;
		std::cout << "Material: " << objList[i].GetMaterialName() << std::endl;
	}

	std::cin.get();
}