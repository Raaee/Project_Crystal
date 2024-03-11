using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private int amountToPool;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private GameObject player;
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    private bool willGrow = true;

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
        for(int i = 0; i < amountToPool; i++)
        {
            CreatePooledObjects();
        }
    }

    private GameObject CreatePooledObjects()
    {
        GameObject go = Instantiate(objectToPool);
        go.SetActive(false);
        go.transform.position = player.transform.position;
        pooledObjects.Add(go);
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

}
