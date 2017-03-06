using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public float speedX = 2.0f;
    public float speedY = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        yaw += speedX * Input.GetAxis("Camera  X");
        pitch -= speedY * Input.GetAxis("Camera Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
