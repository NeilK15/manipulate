using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    public int maxSpawn = 5;
    public float spawnSpeed = .5f;

    int numSpawned = 0;

    private void Start()
    {
        StartCoroutine(Loop());

        if (numSpawned > maxSpawn)
            StopAllCoroutines();
    }

    IEnumerator Loop()
    {

        Instantiate(enemy, transform.position, Quaternion.identity);
        numSpawned++;

        yield return new WaitForSeconds(spawnSpeed);

        if (numSpawned < maxSpawn)
            StartCoroutine(Loop());

    }

}
