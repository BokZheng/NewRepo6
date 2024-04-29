using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawntoken : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public float respawnTime = 3f;

    private GameObject spawnedObject;

    private void Start()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }

    private void OnDestroy()
    {
        if (spawnedObject != null)
        {
            StartCoroutine(RespawnAfterDelay());
        }
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnTime);
        SpawnObject();
    }
}