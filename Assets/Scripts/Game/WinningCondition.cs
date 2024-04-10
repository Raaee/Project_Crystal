using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCondition : MonoBehaviour
{
    [SerializeField] private GameObject corruptedGlobalLight;
    [SerializeField] private GameObject purifiedGlobalLight;

    // if all crystals are purified
    private void Start() {
        CrystalManager.Instance.OnAllCrystalsComplete.AddListener(Result);
        EnableCorruptedLighting();
        TilePurificationManager.instance.CorruptAllTiles();
    }

    [ProButton]
    public void Result() {
        // this ONLY happens if ALL crystals are purified
        // global light changes
        // everything purifies
        // add SFX
        Debug.Log("purifiy all");
        EnablePurifiedLighting();
        TilePurificationManager.instance.PurifyAllTiles();
    }

    public void EnableCorruptedLighting() {
        purifiedGlobalLight.SetActive(false);
        corruptedGlobalLight.SetActive(true);
    }
    public void EnablePurifiedLighting() {
        corruptedGlobalLight.SetActive(false);
        purifiedGlobalLight.SetActive(true);
    }
}
