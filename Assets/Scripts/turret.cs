using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Transform player;
    public Transform bulletSpawnPoint;
    public GameObject bullet;
    public Material IdleMat;
    public Material AgroMat;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.position) <= 20)
        {
            //Agro
            GetComponent<Renderer>().material = AgroMat;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            
            GameObject temp = Instantiate(bullet);
            temp.transform.position = bulletSpawnPoint.position;

            temp.GetComponent<bullet>().direction = (transform.position - player.position);
            temp.GetComponent<bullet>().direction = temp.GetComponent<bullet>().direction.normalized;
        } else
        {
            GetComponent<Renderer>().material = IdleMat;
        }
    }
}
