using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestVisual : MonoBehaviour
{
    private SpriteRenderer chestSr;
    private Collider2D chestCollider2d;
    [SerializeField] private Sprite chestOpenSprite;
    [SerializeField] private Sprite chestClosedSprite;
    [SerializeField] [Range(3f, 5f)] private float respawnTime = 3f;
    private float disappearTime = 2.5f; //longer dissapear time to play the chest audio fully
    private void Awake()
    {
        chestSr = GetComponent<SpriteRenderer>();
        chestCollider2d = GetComponent<Collider2D>();
    }


    public IEnumerator ChestOpenVisual()
    {
        chestSr.sprite = chestOpenSprite;
        yield return new WaitForSeconds(disappearTime);
        chestSr.enabled = false;
        chestCollider2d.enabled = false;
        
        //  StartCoroutine(RespawnChest(sr, obj));
        yield return RespawnChest();
    }

    private IEnumerator RespawnChest()
    {
        yield return new WaitForSeconds(respawnTime);
        chestSr.sprite = chestClosedSprite;
        chestSr.enabled = true;
        chestCollider2d.enabled = true;
    }

}
