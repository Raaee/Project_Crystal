using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffUI : MonoBehaviour
{
    [SerializeField] private GameObject BezerkerIU;
    [SerializeField] private GameObject DrowingIU;
    [SerializeField] private Drowning drowningEffect;
    [SerializeField] private Drowning bezerkerEffect;

    // Start is called before the first frame update
    void Start()
    {
        drowningEffect.OnDrowning.AddListener(DrowingUIActive);
        drowningEffect.StopDrowning.AddListener(DrowningUINotActive);

        //bezerkerEffect.OnBezerker.AddListener(BezerkerUIActive);


        BezerkerIU.SetActive(false);
        DrowingIU.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BezerkerUIActive() {
        BezerkerIU.SetActive(true);
    }

    public void BezerkerUINotActive() {
        BezerkerIU.SetActive(false);
    }

    public void DrowingUIActive()
    {
        DrowingIU.SetActive(true);
    }

    public void DrowningUINotActive() {
        DrowingIU.SetActive(false);
    }
}
