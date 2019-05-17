using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed;
    public Vector3 direction;
    public Transform player;
    public float life;
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, -bulletSpeed * Time.deltaTime);
        life -= Time.deltaTime * 10;
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMovement>().health -= 0.2f;
            Destroy(this.gameObject);
        }
    }
}
