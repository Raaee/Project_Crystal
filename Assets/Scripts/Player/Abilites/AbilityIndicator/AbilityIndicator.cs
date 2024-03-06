using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public abstract class AbilityIndicator : MonoBehaviour
{
    protected Actions actions;
    [SerializeField] protected GameObject indicatorCenterPoint;
    [SerializeField] protected GameObject indicator;
    private Vector3 mousePos;
    protected Vector2 mousePosition;
    protected bool indicatorIsActive = false;

    void Start()
    {
        indicatorCenterPoint.SetActive(false);
        indicator.SetActive(false);
        actions = GetComponent<Actions>();
    }

    private void Update()
    {
        if (indicatorIsActive)
        {
            mousePosition = Mouse.current.position.ReadValue();
            mousePos = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 rotation = mousePos - indicatorCenterPoint.transform.position;
            float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            indicatorCenterPoint.transform.rotation = Quaternion.Euler(0, 0, rotz);
        }
    }

    public void EnableAbilityIndicator() {
        indicatorIsActive = !indicatorIsActive;
        indicatorCenterPoint.SetActive(indicatorIsActive);
        indicator.SetActive(indicatorIsActive);
    }

}
