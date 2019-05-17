using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterLevel : MonoBehaviour
{
    public float[] areaY;
    public int targetArea = 0;
    public float speed = 0.5f;
    public GameObject player;
    
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

        if (player.transform.position.y <= transform.position.y)
        {
            player.GetComponent<PlayerMovement>().health -= Time.deltaTime * 5;
        }
    }
}
