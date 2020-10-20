#include "LevelManager.h"

Level::Level() {
}

void Level::AddGameObject(GameObject obj) {
    m_objectList.push_back(obj);
}

bool Level::DeleteGameObject(int id) {
    for (int i = 0; i < m_objectList.size(); i++) {
        if (m_objectList[i].GetID() == id) {
            // found object with id, delete it
            m_objectList.erase(m_objectList.begin() + i);
            return true;
        }
    }
    // did not find object with id
    return false;
}

int Level::GetNumObjects() {
    return m_objectList.size();
}

GameObjectRaw Level::GetRawData(int id) {
    GameObject cooked;
    for (int i = 0; i < m_objectList.size(); i++) {
        if (m_objectList[i].GetID() == id) {
            // found object with id
            cooked = m_objectList[i];
        }
    }

    GameObjectRaw rawData;
    if (cooked.GetID() == -1) {
        // did not find object with id
        rawData.id = -1;
        return rawData;
    }
    else {
        rawData.id = cooked.GetID();

        rawData.xPos = cooked.GetPosition().x;
        rawData.yPos = cooked.GetPosition().y;
        rawData.zPos = cooked.GetPosition().z;

        rawData.xRot = cooked.GetRotation().x;
        rawData.yRot = cooked.GetRotation().y;
        rawData.zRot = cooked.GetRotation().z;
        rawData.wRot = cooked.GetRotation().w;

        rawData.scale = cooked.GetScale();

        rawData.material = cooked.GetMaterialName();

        return rawData;
    }
}

std::string Level::GetLevelName() const {
    return m_name;
}

void Level::SetLevelName(std::string name) {
    m_name = name;
}

LevelManager::LevelManager() {
}

Level LevelManager::LoadLevel(std::string name) {
    // a bunch of file stuff here
    return Level();
}

void LevelManager::SaveLevel(Level level) {

}
