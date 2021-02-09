//https://weeklyhow.com/unity-top-down-character-movement/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D body;
    Animator anim;
    Vector2 movement;
    float hf = 0.0f;
    float vf = 0.0f;

    float horizontal;
    float vertical;

    public float movementSpeed = 5.0f;

    void Start ()
    {
      body = this.GetComponent<Rigidbody2D>();
      anim = this.GetComponent<Animator> ();

    }

    void Update()
    {

      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      hf = movement.x > 0.01f ? movement.x : movement.x < -0.01f ? 1 : 0;
      vf = movement.y > 0.01f ? movement.y : movement.y < -0.01f ? 1 : 0;
    if (movement.x < -0.01f)
    {
        this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
    } else
    {
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    anim.SetFloat("horizontal", hf);
    anim.SetFloat("vertical", movement.y);
    anim.SetFloat("speed", vf);
    }


    void FixedUpdate()
    {
      body.MovePosition(body.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

}
