using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D body;
    //Animator animator;

    float horizontal;
    float vertical;

    public float runSpeed = 10.0f;

    void Start ()
    {
      body = GetComponent<Rigidbody2D>();
      //animator = GetComponent<Animator> ();

    }

    void Update()
    {
      horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
      vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }


    void FixedUpdate()
    {
      body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

}
