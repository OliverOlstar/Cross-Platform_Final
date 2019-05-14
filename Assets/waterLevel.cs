using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterLevel : MonoBehaviour
{
    public float[] areaY;
    public int targetArea = 0;
    public float speed = 0.5f;
    
    void Update()
    {
        if (transform.position.y + areaY[targetArea] > speed)
        {
            transform.position = new Vector3(0, transform.position.y - speed);
        }
        else if (transform.position.y + areaY[targetArea] < -speed)
        {
            transform.position = new Vector3(0, transform.position.y + speed);
        }
    }
}
