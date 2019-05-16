using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float speed = 6f;
    public float nightSpeed = 12f;
    public float horizon = -70f;
    float lightChangeSpeed = 0.004f;

    void Update()
    {
        if (transform.position.y < horizon)
        {
            transform.RotateAround(Vector3.zero, Vector3.right, nightSpeed * Time.deltaTime);
            transform.LookAt(Vector3.zero);

            if (transform.position.z > 450 && RenderSettings.ambientIntensity > 0.15f)
            {
                RenderSettings.ambientIntensity -= lightChangeSpeed;
            }
            else if (transform.position.z < -450 && RenderSettings.ambientIntensity < 1f)
            {
                RenderSettings.ambientIntensity += lightChangeSpeed;
            }

            Debug.Log(RenderSettings.ambientIntensity);
        }
        else
        {
            transform.RotateAround(Vector3.zero, Vector3.right, speed * Time.deltaTime);
            transform.LookAt(Vector3.zero);
            RenderSettings.ambientIntensity = 1f;
        }
    }
}
