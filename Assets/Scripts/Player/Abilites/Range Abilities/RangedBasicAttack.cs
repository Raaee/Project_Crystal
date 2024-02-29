using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangedBasicAttack : MonoBehaviour
{
    [SerializeField] private GameObject rangedAttack;
    [SerializeField] private GameObject rangedAttackShot;
    [SerializeField] private Transform attackShotSpawnPoint;
    private Actions actions;
    private GameObject rangedAttackShotInst;
    private Vector2 worldPos;
    private Vector2 direction;
    private Vector3 localScale;
    private float angle;

    void Start()
    {
        actions = GetComponent<Actions>();
        actions.OnBasicAttack.AddListener(HandleRangeShooting);
    }
    void FixedUpdate()
    {
        
        HandlePlayerRotation();
        

    }

    private void HandlePlayerRotation()
    {
        worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //Vector3 mousePos = Mouse.current.position.ReadValue();
        //mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        direction = (worldPos- (Vector2)rangedAttack.transform.position).normalized;
        rangedAttack.transform.right = direction;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        localScale = Vector3.one;
        if (angle > 90 || angle < -90 )
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }
        rangedAttack.transform.localScale = localScale;

    }

    private void HandleRangeShooting()
    {
            rangedAttackShotInst = Instantiate(rangedAttackShot, attackShotSpawnPoint.position, rangedAttack.transform.rotation);
            //rangedAttack.GetComponent<rangedAttack>().SetDirection(direction);
        
    }

}
