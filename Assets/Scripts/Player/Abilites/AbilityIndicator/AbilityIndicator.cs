using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public abstract class AbilityIndicator : MonoBehaviour
{
    protected Actions actions;
    [SerializeField] protected GameObject IndicatorRotationPoint;
    [SerializeField] protected GameObject abilityIndicator;
    private Camera mainCamera;
    private Vector3 mousePos;
    protected Vector2 mousePosition;

    void Awake()
    {
        IndicatorRotationPoint.SetActive(false);
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        actions = GetComponent <Actions>();
   
    }

    private void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();

        mousePos = mainCamera.ScreenToWorldPoint(mousePosition);

        Vector3 rotation = mousePos - IndicatorRotationPoint.transform.position;

        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        IndicatorRotationPoint.transform.rotation = Quaternion.Euler(0,0, rotz);
    }

    public void EnableAbilityIndicator() {
        IndicatorRotationPoint.SetActive(true);
        //abilityIndicator.enabled = true;
    }
}
