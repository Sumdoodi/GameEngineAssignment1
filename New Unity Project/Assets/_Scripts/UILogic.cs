using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogic : MonoBehaviour
{
    [SerializeField]
    public GameObject canvas;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCube()
    {
        Debug.Log("Cube");
    }

    public void SpawnSphere()
    {
        Debug.Log("Sphere");
    }
}
