using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPoolerManager : MonoBehaviour
{
    // Singleton

    public static ObjPoolerManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public ObjectPooler GetPool(GameObject obj)
    {
        ObjectPooler[] pools = GetComponentsInChildren<ObjectPooler>();
        if (pools == null)
            Debug.Log("pools is null");


        foreach (ObjectPooler pool in pools)
        {
            if (pool.GetObjectToPool().name == obj.name)
            {
                return pool;
            }
        }

        // if no pool found, create a new one
        GameObject newPool = new GameObject(obj.name + " Pool");
        newPool.transform.parent = transform;
        ObjectPooler newPooler = newPool.AddComponent<ObjectPooler>();
        newPooler.objectToPool = obj;
        newPooler.pooledObjParent = newPool.transform;
        newPooler.amountToPool = 3;
        newPooler.Init();
        return newPooler;
    }
}
