using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_Rotator : MonoBehaviour
{
    // A little Quirky Bonus

    // We do Random here - it helps more than you think!

    public Vector3 rotSpeed; // Normal rotation speeds
    public Vector3 randVariance; // How much we're allowed to be naughty

    void Start(){
        rotSpeed.x+=(Random.Range(-randVariance.x,randVariance.x));
        rotSpeed.y+=(Random.Range(-randVariance.y,randVariance.y));
        rotSpeed.z+=(Random.Range(-randVariance.z,randVariance.z));
    }

    void Update(){
        transform.Rotate(rotSpeed*Time.deltaTime);
    }
}
