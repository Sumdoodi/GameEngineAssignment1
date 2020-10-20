#pragma once
#ifndef __LEVEL_MANAGER__
#define __LEVEL_MANAGER__

#include <string>
#include <vector>
#include "PluginSettings.h"
#include "Vector3D.h"
#include "GameObject.h"

class PLUGIN_API LevelManager {
public:
	// Constructor
	LevelManager();

	// load and save
	Level LoadLevel(std::string name);
	void SaveLevel(Level level);

private:
	Level m_workingLevel;

};

#endif /* defined(__LEVEL_MANAGER__) */


#ifndef __LEVEL__
#define __LEVEL__
class PLUGIN_API Level {
public:
	Level();

	// add and delete objects by id
	void AddGameObject(GameObject obj);
	bool DeleteGameObject(int id);

	int GetNumObjects();
	GameObjectRaw GetRawData(int id);

	std::string GetLevelName() const;
	void SetLevelName(std::string name);

private:
	std::string m_name;
	std::vector<GameObject> m_objectList;
};
#endif