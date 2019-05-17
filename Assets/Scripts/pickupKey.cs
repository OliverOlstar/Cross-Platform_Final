using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupKey : MonoBehaviour
{
    public door myDoor;

    private void OnTriggerEnter(Collider col)
    {
        myDoor.key = true;
        Destroy(this.gameObject);
    }
}
