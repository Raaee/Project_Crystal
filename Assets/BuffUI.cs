using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffUI : MonoBehaviour
{
    [SerializeField] private GameObject bezerkerUI;
    [SerializeField] private GameObject drowningUI;
    [SerializeField] private Drowning drowningEffect;
    [SerializeField] private BezerkerBuffActivate bezerkerEffect;


    // Start is called before the first frame update
    void Start()
    {
        BezerkerUINotActive();
        DrowningUINotActive();
        drowningEffect = PlayerManager.Instance.GetPlayer().GetComponent<Drowning>();
        drowningEffect.OnDrowning.AddListener(DrowningUIActive);
        drowningEffect.StopDrowning.AddListener(DrowningUINotActive);

        //bezerkeBezerkerClone = GameObject.FindGameObjectWithTag("BezerkerTag");
        //bezerkerEffect = bezerkeBezerkerClone.GetComponent<BezerkerCubeDrop>();
        bezerkerEffect.OnBezerker.AddListener(BezerkerUIActive);
        bezerkerEffect.StopBezerker.AddListener(BezerkerUINotActive);
    }

    public void BezerkerUIActive() {
        bezerkerUI.SetActive(true);
    }

    public void BezerkerUINotActive() {
        bezerkerUI.SetActive(false);
    }

    public void DrowningUIActive()
    {
        drowningUI.SetActive(true);
    }

    public void DrowningUINotActive() {
        drowningUI.SetActive(false);
    }
}
