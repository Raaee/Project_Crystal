using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCondition : MonoBehaviour
{

    // if all crystals are purified
    private void Start() {
        CrystalManager.Instance.OnAllCrystalsComplete.AddListener(Result);
    }

    [ProButton]
    public void Result() {
        // this ONLY happens if ALL crystals are purified
        // global light changes
        // everything purifies
        // add SFX
        Debug.Log("purifiy all");
    }
}
