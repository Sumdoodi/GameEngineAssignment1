using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogic : MonoBehaviour
{
    // references
    [SerializeField]
    public GameObject canvas;
    [SerializeField]
    public Camera player;

    // prefabs
    [SerializeField]
    public GameObject cubePrefab;
    [SerializeField]
    public GameObject spherePrefab;

    // vars
    public float placementDistance = 1.0f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCube()
    {
        Instantiate<GameObject>(cubePrefab, GetSpawnLocation(), GetSpawnRotation());
        Debug.Log("Cube");
    }

    public void SpawnSphere()
    {
        Instantiate<GameObject>(spherePrefab, GetSpawnLocation(), GetSpawnRotation());
        Debug.Log("Sphere");
    }

    public Vector3 GetSpawnLocation()
    {
        Vector3 basePos = player.transform.position;
        Vector3 placePos = basePos + (player.transform.forward * placementDistance);

        return placePos;
    }

    public Quaternion GetSpawnRotation()
    {

        return new Quaternion();
    }
}
