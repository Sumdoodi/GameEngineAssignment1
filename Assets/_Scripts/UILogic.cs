using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class UILogic : MonoBehaviour
{
    // references
    [SerializeField]
    public GameObject canvas;
    public Camera player;
    public GameObject spawnCubeButton;
    public GameObject spawnSphereButton;
    public GameObject spawnMarksmanButton;
    public GameObject spawnRockButton;
    public GameObject spawnLightButton;
    public GameObject matOneButton;
    public GameObject matTwoButton;
    public GameObject matThreeButton;
    public Material red;
    public Material blue;
    public Material green;
    public GameObject PropsParentObj;

    public GameObject save1;
    public GameObject save2;
    public GameObject save3;
    public GameObject load1;
    public GameObject load2;
    public GameObject load3;

    // prefabs
    [SerializeField]
    public GameObject lightPrefab;
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject marksmanPrefab;
    public GameObject rockPrefab;

    // vars
    [SerializeField]
    public float placementDistance = 10.0f;

    public bool legendIsVisible = false;
    public bool objectsButtonsVisible = false;
    public bool matrialsButtonsVisible = false;
    public bool saveButtonsVisible = false;
    public bool loadButtonsVisible = false;

    public GameObject lvlMan;

    GameObject curObject;
    public GameObject legendImage;

    // Update is called once per frame
    void Update()
    {
        if (!curObject)
        {
            return;
        }

        bool inMenu = player.GetComponent<Movement>().cursorState();
       
        if (!inMenu && Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            PlaceObject();
        }

        if (Input.mouseScrollDelta != new Vector2(0,0))
        {
            placementDistance += Input.mouseScrollDelta.y;
            Debug.Log(placementDistance);
        }

        curObject.transform.position = GetSpawnLocation();
        // curObject.transform.rotation = GetSpawnRotation();
    }

    // menu toggles
    public void ShowObjects()
    {
        objectsButtonsVisible = !objectsButtonsVisible;
        spawnCubeButton.SetActive(objectsButtonsVisible);
        spawnSphereButton.SetActive(objectsButtonsVisible);
        spawnMarksmanButton.SetActive(objectsButtonsVisible);
        spawnRockButton.SetActive(objectsButtonsVisible);
        spawnLightButton.SetActive(objectsButtonsVisible);
    }

    public void ShowMaterials()
    {
        matrialsButtonsVisible = !matrialsButtonsVisible;
        matOneButton.SetActive(matrialsButtonsVisible);
        matTwoButton.SetActive(matrialsButtonsVisible);
        matThreeButton.SetActive(matrialsButtonsVisible);
    }

    public void ShowSave()
    {
        saveButtonsVisible = !saveButtonsVisible;
        save1.SetActive(saveButtonsVisible);
        save2.SetActive(saveButtonsVisible);
        save3.SetActive(saveButtonsVisible);
    }
    public void ShowLoad()
    {
        loadButtonsVisible = !loadButtonsVisible;
        load1.SetActive(loadButtonsVisible);
        load2.SetActive(loadButtonsVisible);
        load3.SetActive(loadButtonsVisible);
    }

    // spawners
    public void SpawnCube()
    {
        if (curObject)
        {
            Destroy(curObject);
        }
        curObject = Instantiate<GameObject>(cubePrefab, GetSpawnLocation(), GetSpawnRotation());
        curObject.transform.SetParent(PropsParentObj.transform, false);
        Debug.Log("Cube");
    }

    public void SpawnSphere()
    {
        if (curObject)
        {
            Destroy(curObject);
        }
        curObject = Instantiate<GameObject>(spherePrefab, GetSpawnLocation(), GetSpawnRotation());
        curObject.transform.SetParent(PropsParentObj.transform, false);
        Debug.Log("Sphere");
    }

    public void SpawnMarksman()
    {
        if (curObject)
        {
            Destroy(curObject);
        }
        curObject = Instantiate<GameObject>(marksmanPrefab, GetSpawnLocation(), GetSpawnRotation());
        curObject.transform.SetParent(PropsParentObj.transform, false);
        Debug.Log("marksman");
    }

    public void SpawnRock()
    {
        if (curObject)
        {
            Destroy(curObject);
        }
        curObject = Instantiate<GameObject>(rockPrefab, GetSpawnLocation(), GetSpawnRotation());
        curObject.transform.SetParent(PropsParentObj.transform, false);
        Debug.Log("rock");
    }

    public void SpawnLight()
    {
        if (curObject)
        {
            Destroy(curObject);
        }
        curObject = Instantiate<GameObject>(lightPrefab, GetSpawnLocation(), GetSpawnRotation());
        curObject.transform.SetParent(PropsParentObj.transform, false);
        Debug.Log("light");
    }

    public void AssignRedMaterial()
    {
        GameObject temp = player.GetComponent<Movement>().returnSelected();
        temp.GetComponent<MeshRenderer>().material = red;
    }

    public void AssignGreenMaterial()
    {
        GameObject temp = player.GetComponent<Movement>().returnSelected();
        temp.GetComponent<MeshRenderer>().material = green;
    }

    public void AssignBlueMaterial()
    {
        GameObject temp = player.GetComponent<Movement>().returnSelected();
        temp.GetComponent<MeshRenderer>().material = blue;
    }

    // utils
    public void PlaceObject()
    {
        if (!curObject)
        {
            return;
        }

        GameObject temp = Instantiate<GameObject>(curObject);
        temp.transform.SetParent(PropsParentObj.transform, false);
        Destroy(curObject);
    }

    public void ToggleLegend()
    {
        legendIsVisible = !legendIsVisible;
        legendImage.SetActive(legendIsVisible);
    }

    public Vector3 GetSpawnLocation()
    {
        Vector3 basePos = player.transform.position;
        Vector3 placePos = basePos + (player.transform.forward * placementDistance);

        return placePos;
    }

    public Quaternion GetSpawnRotation()
    {
        Quaternion cameraRot = Quaternion.LookRotation(player.transform.forward);
        return cameraRot;
    }
}
