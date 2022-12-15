using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    Transform[] collectibles;

    [SerializeField]
    float spawnTimeFrame = 5.0F;

    [SerializeField]
    float xMin;

    [SerializeField]
    float xMax;

    [SerializeField]
    float zMin;

    [SerializeField]
    float zMax;

    [SerializeField]
    float yPosition = 1.5F;

    float timeElapsed;

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > spawnTimeFrame)
        {
            int index = Random.Range(0, collectibles.Length);
            Transform collectible = Instantiate(collectibles[index]);
            float x = Random.Range(xMin, xMax);
            float z = Random.Range(zMin, zMax);
            collectible.transform.position = new Vector3(x, yPosition, z);

            timeElapsed = 0.0F;

        }
    }
}
