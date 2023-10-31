using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public enum PrefabType
{
    Prefab0 = 0,
    Prefab1 = 1,
    Prefab2 = 2,
    Prefab3 = 3,
    Prefab4 = 4,
    Prefab5 = 5
   
}
public class ObjectPooling2 : MonoBehaviour
{
    public static ObjectPooling2 Shared;
    public Dictionary<GameObject, List<GameObject>> pooledObjects;
    public List<GameObject> objectsToPool;
    public List<int> amountToPool;
  
    private void Awake()
    {
        Shared = this;
    }

    private void Start()
    {
        pooledObjects = new Dictionary<GameObject, List<GameObject>>();
        for (int i = 0; i < objectsToPool.Count; i++)
        {
            pooledObjects[objectsToPool[i]] = new List<GameObject>();
            for (int j = 0; j < amountToPool[i]; j++)
            {
                GameObject obj = Instantiate(objectsToPool[i]);
                obj.SetActive(false);
                pooledObjects[objectsToPool[i]].Add(obj);
            }
        }
    }

    public GameObject GetPrefabByType(PrefabType type)
    {
        int index = (int)type;
        if (index >= 0 && index < objectsToPool.Count)
        {
            return objectsToPool[index];
        }
        else
        {
            Debug.LogError("Invalid PrefabType.");
            return null;
        }
    }

    public GameObject GetPooledObject(PrefabType type)
    {
        GameObject prefab = GetPrefabByType(type);
        if (prefab == null)
        {
            return null;
        }

        for (int i = 0; i < pooledObjects[prefab].Count; i++)
        {
            if (!pooledObjects[prefab][i].activeInHierarchy)
            {
                return pooledObjects[prefab][i];
            }
        }

        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        pooledObjects[prefab].Add(obj);
        return obj;
    }
}