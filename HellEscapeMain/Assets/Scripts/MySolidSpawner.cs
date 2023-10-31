using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
public class MySolidSpawner : MonoBehaviour
{
    // The prefabs to spawn
    //public GameObject[] prefabs;
    public float desiredCircleRadius;
    // The minimum and maximum number of prefabs to spawn
    public int minSpawnCount = 5;
    public int maxSpawnCount = 10;
    public int maxActivePrefabs = 65;
    // The movable object to generate spawn points around
    public GameObject movableObject;
    [Range(0.0f, 1f)]
    public float nadide;
    // The list of spawned prefabs
    public List<GameObject> spawnedPrefabs;
    public float spawnInterval; 
    public float spawnIntervalBoss;  
    public bool BossHere;
    private ObjectPooling2 pool;
    private void Awake()
    {
        pool = ObjectPooling2.Shared;
    }
    void Start()
    {
        // Initialize the list of spawned prefabs
        spawnedPrefabs = new List<GameObject>();
        Spawn4();
        // Start the spawn coroutine
        StartCoroutine(SpawnCoroutine());
        StartCoroutine(SpawnCoroutineBoss());

        Application.targetFrameRate = 60;
    }

    IEnumerator SpawnCoroutine()
    {
        
       
            // Loop indefinitely
            while (true)
            {
                // Wait for the specified interval
                yield return new WaitForSeconds(spawnInterval);

                // Spawn the prefabs
                int spawnCount = Random.Range(minSpawnCount, maxSpawnCount + 1);
                for (int i = 0; i < spawnCount; i++)
                {
                    if (!BossHere)
                    {
                       Spawn4();
                    }               
                }             
            }
       
    }
    IEnumerator SpawnCoroutineBoss()
    {
        while (true)
        {
            if (!BossHere)
            {
                yield return new WaitForSeconds(spawnIntervalBoss);

                BossSpawn();
                BossHere = true;
            }
            else
            {
                yield return null;
            }
        }
    }

    public void Spawn3(Vector3 pos)
    {
        //GameObject prefabToSpawn = ObjectPooler.SharedInstance.GetPooledObject();
        GameObject prefabToSpawn;
        float randomValue = Random.value;
        if (randomValue <= 0.85f) // 85% probability
        {
            prefabToSpawn = pool.GetPooledObject(PrefabType.Prefab0);
        }
        else  // 15% probability
        {
            prefabToSpawn = pool.GetPooledObject(PrefabType.Prefab1);
        }
        if (prefabToSpawn == null) return;

        // Define the range for the random offset
        float offsetRange = 0.5f;

        // Generate a random offset
        Vector3 offset = new(Random.Range(-offsetRange, offsetRange),
                                     0, // no change on the y-axis
                                     Random.Range(-offsetRange, offsetRange));

        // Apply the offset to the spawn position
        pos += offset;

        // Set the position and rotation of the prefab
        prefabToSpawn.transform.SetPositionAndRotation(new Vector3(pos.x, 1, pos.z), Quaternion.identity);

        // Enable the prefab
        prefabToSpawn.SetActive(true);

        float jumpDistance = 3f;
        float jumpDuration = 0.5f;

        // Calculate the target position for the jump
        Vector3 jumpTarget = prefabToSpawn.transform.position + prefabToSpawn.transform.forward * jumpDistance;

        // Make the prefab jump forward
        prefabToSpawn.transform.DOMove(jumpTarget, jumpDuration);
    }

    public void Spawn4()
    {
       
        GameObject prefab;
        float randomValue = Random.value;
        if (randomValue <= 0.60f) // 60% probability
        {
            prefab = pool.GetPooledObject(PrefabType.Prefab2);
        }
        else if (randomValue <= 0.9f) // 25% probability
        {
            prefab = pool.GetPooledObject(PrefabType.Prefab3);
        }
        else if (randomValue <= 0.98f) // 10% probability
        {
            prefab = pool.GetPooledObject(PrefabType.Prefab4);
        }
        else // 5% probability
        {
            prefab = pool.GetPooledObject(PrefabType.Prefab2);

        }
        if (prefab == null) return;
        if (spawnedPrefabs.Count >= maxActivePrefabs)
        {
            return;
        }
        float angle = Random.Range(0f, 360f);
        float x = movableObject.transform.position.x + desiredCircleRadius * Mathf.Cos(angle);
        float z = movableObject.transform.position.z + desiredCircleRadius * Mathf.Sin(angle);
        Vector3 position = new Vector3(x, 0, z);
        prefab.transform.SetPositionAndRotation(position, Quaternion.Euler(0, angle, 0));
        prefab.SetActive(true);
    }
    public void BossSpawn()
    {
        
        GameObject prefab = pool.GetPooledObject(PrefabType.Prefab5); 

        float angle = Random.Range(0f, 360f);
        float x = movableObject.transform.position.x + desiredCircleRadius * Mathf.Cos(angle);
        float y = movableObject.transform.position.y;
        float z = movableObject.transform.position.z + desiredCircleRadius * Mathf.Sin(angle);
        Vector3 position = new Vector3(x, 0, z);
        prefab.transform.SetPositionAndRotation(position, Quaternion.identity);
        prefab.SetActive(true);
    }
}


