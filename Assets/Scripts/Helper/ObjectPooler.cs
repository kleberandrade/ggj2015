using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public GameObject objectPrefab;
    public int pooledAmount = 3;
    public bool willGrow = true;
    private List<GameObject> pooledObjects;

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject go = (GameObject)Instantiate(objectPrefab);
            go.SetActive(false);
            pooledObjects.Add(go);
        }
    }

    public GameObject NextObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }

        if (willGrow)
        {
            GameObject go = (GameObject)Instantiate(objectPrefab);
            pooledObjects.Add(go);
            return go;
        }

        return null;
    }
}
