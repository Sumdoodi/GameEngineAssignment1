#pragma once
#ifndef __GAME_OBJECT__
#define __GAME_OBJECT__

#include <string>
#include "PluginSettings.h"
#include "Vector3D.h"
#include "Quaternion.h"

struct GameObjectRaw {
	int id;
	float xPos, yPos, zPos;
	float xRot, yRot, zRot, wRot;
	float scale;
	std::string material;
};

class PLUGIN_API GameObject {
public:
	// Constructor
	GameObject();

	// Getters & setters
	int GetID() const;
	void SetID(int id);

	Vector3D GetPosition() const;
	void SetPosition(float x = 0.0f, float y = 0.0f, float z = 0.0f);

	Quaternion GetRotation() const;
	void SetRotation(float x = 0.0f, float y = 0.0f, float z = 0.0f, float w = 0.0f);

	float GetScale() const;
	void SetScale(float scale = 1.0f);
	
	std::string GetMaterialName() const;
	void SetMaterialName(std::string material);


private:
	int m_id = -1;
	Vector3D m_position;
	Quaternion m_rotation;
	float m_scale;
	std::string m_material;
};

#endif /* defined(__GAME_OBJECT__) */
// Reference: some code by Tom :)