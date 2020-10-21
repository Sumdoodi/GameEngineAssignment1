using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRatePerMinute = 60;

    private int currentCount = 0;

    [SerializeField]
    private TimedObjectFactory factory;

    private void Update()
    {
        var targetCount = Time.time * (spawnRatePerMinute / 60);

        while (targetCount > currentCount)
        {
            var inst = factory.GetNewInstance();
            inst.transform.position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-5.0f, 5.0f), Random.Range(-10.0f, 10.0f));

            currentCount++;
        }
    }
}

