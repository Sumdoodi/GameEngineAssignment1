﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class UILogic : MonoBehaviour
{
    // references
    [SerializeField]
    public GameObject canvas;
    public Camera player;

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

    public void SpawnCube()
    {
        if (curObject)
        {
            Destroy(curObject);
        }
        curObject = Instantiate<GameObject>(cubePrefab, GetSpawnLocation(), GetSpawnRotation());
        Debug.Log("Cube");
    }

    public void SpawnSphere()
    {
        if (curObject)
        {
            Destroy(curObject);
        }
        curObject = Instantiate<GameObject>(spherePrefab, GetSpawnLocation(), GetSpawnRotation());
        Debug.Log("Sphere");
    }

    public void SpawnMarksman()
    {
        if (curObject)
        {
            Destroy(curObject);
        }
        curObject = Instantiate<GameObject>(marksmanPrefab, GetSpawnLocation(), GetSpawnRotation());
        Debug.Log("marksman");
    }

    public void SpawnRock()
    {
        if (curObject)
        {
            Destroy(curObject);
        }
        curObject = Instantiate<GameObject>(rockPrefab, GetSpawnLocation(), GetSpawnRotation());
        Debug.Log("rock");
    }

    public void SpawnLight()
    {
        if (curObject)
        {
            Destroy(curObject);
        }
        curObject = Instantiate<GameObject>(lightPrefab, GetSpawnLocation(), GetSpawnRotation());
        Debug.Log("light");
    }


    // utils
    public void PlaceObject()
    {
        if (!curObject)
        {
            return;
        }

        GameObject temp = Instantiate<GameObject>(curObject);
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
