using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffUI : MonoBehaviour
{
    [SerializeField] private GameObject BezerkerIU;
    [SerializeField] private GameObject DrowingIU;
    [SerializeField] private Drowning drowningEffect;
    [SerializeField] private BezerkerCubeDrop bezerkerEffect;

    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.GetPlayer().GetComponent<Drowning>();
        drowningEffect.OnDrowning.AddListener(DrowingUIActive);
        drowningEffect.StopDrowning.AddListener(DrowningUINotActive);

        bezerkerEffect.OnBezerker.AddListener(BezerkerUIActive);
        bezerkerEffect.StopBezerker.AddListener(BezerkerUINotActive);
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
