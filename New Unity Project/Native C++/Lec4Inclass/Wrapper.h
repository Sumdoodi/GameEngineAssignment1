#pragma once
#ifndef __WRAPPER__
#define __WRAPPER__

#include "PluginSettings.h"
#include "Vector3D.h"
#include "Quaternion.h"
#include "LevelManager.h"

#ifdef __cplusplus
extern "C" {
#endif
	// GameObject
	PLUGIN_API int GetID();

	PLUGIN_API void SetID(int id);

	PLUGIN_API Vector3D GetPosition();

	PLUGIN_API void SetPosition(float x, float y, float z);

	PLUGIN_API Quaternion GetRotation();

	PLUGIN_API void SetRotation(float x, float y, float z, float w);

	PLUGIN_API float GetScale();

	PLUGIN_API void SetScale(float scale);

	PLUGIN_API std::string GetMaterialName();

	PLUGIN_API void SetMaterialName(std::string material);

	// LevelManager
	PLUGIN_API Level LoadLevel(std::string name);

	PLUGIN_API void SaveLevel(Level level);

	// Level
	PLUGIN_API void AddGameObject(GameObject obj);

	PLUGIN_API bool DeleteGameObject(int id);

	PLUGIN_API int GetNumObjects();

	PLUGIN_API GameObjectRaw GetRawData(int id);

	PLUGIN_API std::string GetLevelName();

	PLUGIN_API void SetLevelName(std::string name);
	
#ifdef __cplusplus
}
#endif

#endif /* defined(__WRAPPER__) */

class Wrapper {
};

