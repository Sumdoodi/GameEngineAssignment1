using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOutObject : MonoBehaviour
{
    [SerializeField]
    private float timeout = 2;

    private float startTime;


    private void OnEnable()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - startTime > timeout)
        {
            Destroy(gameObject);
        }
    }
}