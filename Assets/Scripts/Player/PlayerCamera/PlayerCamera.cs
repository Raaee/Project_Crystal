using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform camera; 

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = camera.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, cameraPosition, ref velocity, smoothTime);
    }
}
