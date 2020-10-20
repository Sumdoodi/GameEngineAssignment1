#include "GameObject.h"

GameObject::GameObject() {
}

int GameObject::GetID() const {
	return m_id;
}

void GameObject::SetID(const int id) {
	m_id = id;
}

Vector3D GameObject::GetPosition() const {
	return m_position;
}

void GameObject::SetPosition(const float x, const float y, const float z) {
	m_position.x = x;
	m_position.y = y;
	m_position.z = z;
}

Quaternion GameObject::GetRotation() const {
	return m_rotation;
}

void GameObject::SetRotation(float x, float y, float z, float w) {
	m_rotation.x = x;
	m_rotation.y = y;
	m_rotation.z = z;
	m_rotation.w = w;
}

float GameObject::GetScale() const {
	return m_scale;
}

void GameObject::SetScale(float scale) {
	m_scale = scale;
}

std::string GameObject::GetMaterialName() const {
	return m_material;
}

void GameObject::SetMaterialName(std::string material) {
	m_material = material;
}

