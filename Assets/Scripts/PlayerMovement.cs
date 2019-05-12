using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
    Rigidbody rb;
    public Animator anim;
    public Transform model;
    public bool alive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            anim.SetTrigger("Death");
        } else
        {
            Move();
            Jump();
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            alive = false;
        }
    }

    void Move()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(deltaX, 0, deltaZ);

        moveVector.Normalize();
        moveVector = Camera.main.transform.TransformDirection(moveVector);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", Mathf.Lerp(anim.GetFloat("Speed"), moveVector.magnitude * runSpeed, 0.1f));
            moveVector *= Time.deltaTime * runSpeed;
        }
        else
        {
            anim.SetFloat("Speed", Mathf.Lerp(anim.GetFloat("Speed"), moveVector.magnitude * walkSpeed, 0.1f));
            moveVector *= Time.deltaTime * walkSpeed;
        }

        transform.Translate(moveVector.x, 0, moveVector.z);
        model.transform.LookAt(new Vector3(moveVector.x + transform.position.x, model.transform.position.y, moveVector.z + transform.position.z));
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump");
        }
    }

    void Shoot()
    {
        anim.ResetTrigger("Shoot");
        anim.ResetTrigger("Shoot2");
        anim.ResetTrigger("Spell");

        if (Input.GetButtonDown("Fire1"))
            anim.SetTrigger("Shoot");

        if (Input.GetButtonDown("Fire2"))
            anim.SetTrigger("Shoot2");

        if (Input.GetKeyDown(KeyCode.Q))
            anim.SetTrigger("Spell");
    }
}
