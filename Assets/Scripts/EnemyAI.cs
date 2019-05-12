using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    bool agro = false; 
    bool alive = true; 
    public GameObject player;
    public Transform model;
    Animator anim;
    public float runSpeed = 7;
    public float walkSpeed = 4;
    public float acel = 4;

    void Start()
    {
        anim = model.GetComponent<Animator>();
    }
    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 4.5f)
        {
            if (distance >= 1.5f)
            {
                anim.ResetTrigger("Attack");
                anim.SetFloat("Speed", Mathf.Lerp(anim.GetFloat("Speed"), walkSpeed, acel * Time.deltaTime));
                agro = true;
            }
            else
            {
                anim.SetTrigger("Attack");
                anim.SetFloat("Speed", Mathf.Lerp(anim.GetFloat("Speed"), 0, acel * Time.deltaTime));
                agro = false;
            }
        } else if (distance <= 10)
        {
            anim.SetFloat("Speed", Mathf.Lerp(anim.GetFloat("Speed"), runSpeed, acel * Time.deltaTime));
            agro = true;
        }

        if (!alive)
        {
            anim.SetTrigger("Dead");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            alive = false;
        }

        if (agro && alive)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), anim.GetFloat("Speed") * Time.deltaTime);
            model.transform.LookAt(new Vector3(player.transform.position.x, model.transform.position.y, player.transform.position.z));
        }
    }
}
