using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class AbilityIndicatorTest : MonoBehaviour
{
 
    private Camera mainCamera;
    private Vector3 mousePos;
    protected Vector2 mousePosition;

    void Awake()
    { 
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();

        mousePos = mainCamera.ScreenToWorldPoint(mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotz);
    }

}
