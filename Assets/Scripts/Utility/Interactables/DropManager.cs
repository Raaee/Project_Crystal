using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public static DropManager Instance;

    [Header("CONFIG")]
    [SerializeField] private GameObject manaDropPrefab;
    [SerializeField] private GameObject healthDropPrefab;





    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("More than one Drop Manager in this Scene!");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }


    public GameObject GetManaDrop(Vector3 location)
    {
        GameObject go = Instantiate(manaDropPrefab, location, Quaternion.identity);
        return go; //return not really needed, the method abouve spawns and sets the drop
    }


    public GameObject GetHealthDrop(Vector3 location)
    {
        GameObject go = Instantiate(healthDropPrefab, location, Quaternion.identity);
        return go;
    }


}
