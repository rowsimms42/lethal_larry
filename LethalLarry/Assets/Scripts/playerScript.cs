//https://weeklyhow.com/unity-top-down-character-movement/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
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
        this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
      else
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);

      anim.SetFloat("horizontal", hf);
      anim.SetFloat("vertical", movement.y);
      anim.SetFloat("speed", vf);

      if (movement.x == 1 || movement.x == - 1 || movement.y == 1 || movement.y == -1){
        anim.SetFloat("lastMoveX", movement.x);
        anim.SetFloat("lastMoveY", movement.y);
      }
      if (Input.GetKeyDown("space")){
        anim.SetTrigger("fire");
      }
      if (Input.GetKeyUp("space")){
        anim.ResetTrigger("fire");
      }
      //checkPlayerCoords();
    }
    void Awake(){
      GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");
      //DontDestroyOnLoad(this.gameObject);
    }

    void FixedUpdate()
    {
      body.MovePosition(body.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
/*
    void checkPlayerCoords(){
      //Debug.Log("Player position is: "+ player.transform.position.y);
      if ((player.transform.position.y > 28.1 &&
        (player.transform.position.x < -8.5 && player.transform.position.x > -10.6)) ||
        (player.transform.position.x < 7.8 && player.transform.position.x > -11.3) &&
        (player.transform.position.y > 28.5 && player.transform.position.y < 31)){
            //Debug.Log("At wizard");

            //display.text = "Press 'i' to interact...";
            //private Rect windowRect = new Rect ((Screen.width - 200)/2, (Screen.height - 300)/2, 200, 300);
      }
      //x:> -11.3 && x < 7.8
      //y: > 28.5 && y < 31
    }*/
}
