using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] public int amountToPool;
    [SerializeField] public GameObject objectToPool;
    public List<GameObject> pooledObjects;
    public Transform pooledObjParent;
    public void Init()
    {
        pooledObjects = new List<GameObject>();
        for(int i = 0; i < amountToPool; i++)
        {
            CreatePooledObjects();
        }
    }

    private GameObject CreatePooledObjects()
    {
        GameObject go = Instantiate(objectToPool);
        go.SetActive(false);
        go.transform.position = pooledObjParent.position;
        pooledObjects.Add(go);
        go.transform.parent = pooledObjParent;
        return go;
    }

    public GameObject GetPooledObject()
    {
        foreach(GameObject go in pooledObjects)
        {
            if (!go.activeInHierarchy)
            {
                return go;
            }
        }
        return CreatePooledObjects();
    }
    public GameObject GetObjectToPool() {
        return objectToPool;
    }
}
