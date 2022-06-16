using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject camera;
    private float x;
    private float y;
    private Vector3 rotateValue;
    private float speed = 0.003f;

    // Update is called once per frame
    void Update()
    {


       transform.Rotate(0, 1f * speed, 0);

    }
}
