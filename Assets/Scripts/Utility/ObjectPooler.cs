using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private int amountToPool;
    [SerializeField] public GameObject objectToPool;
    [SerializeField] private GameObject parent;
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    private bool willGrow = true;
    private GameObject pooledObjParent;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        Init();

    }
    private void Init()
    {
        pooledObjParent = new GameObject(objectToPool.name + " Parent");
        for(int i = 0; i < amountToPool; i++)
        {
            CreatePooledObjects();
        }
    }

    private GameObject CreatePooledObjects()
    {
        GameObject go = Instantiate(objectToPool);
        go.SetActive(false);
        go.transform.position = parent.transform.position;
        pooledObjects.Add(go);
        go.transform.parent = pooledObjParent.transform;
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
        if(willGrow)
        {
           return CreatePooledObjects();
        }
        return null;
    }
    public GameObject GetObjectToPool() {
        return objectToPool;
    }
}
