using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollectable : MonoBehaviour
{
    public float rotateSpeed = 1;
    public GameObject water;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            water.GetComponent<waterLevel>().targetArea++;
            Destroy(this.gameObject);
        }
    }
}
