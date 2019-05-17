using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	GameObject thedoor;
    public bool key = false;

    void OnTriggerEnter ( Collider obj  ){
        if (key)
        {
            thedoor = GameObject.FindWithTag("SF_Door");
            thedoor.GetComponent<Animation>().Play("open");
        }
    }

    void OnTriggerExit ( Collider obj  ){
        if (key)
        {
            thedoor = GameObject.FindWithTag("SF_Door");
            thedoor.GetComponent<Animation>().Play("close");
        }
    }
}