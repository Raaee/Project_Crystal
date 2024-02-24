using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;
    private GameObject target1;

    public void Update()
    {
        // Code for a movement AI which updates the target GameObject
        // Code for moving towards target GameObject
        // Code for passive walkpath
    }

    public void ChangeSpeed(float amount)
    {
        this.speed += amount;
    }
}
