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
    public projectileBehavior ProjectilePrefab;
    public GameObject arrow;
    Rigidbody2D body;
    Animator anim;
    Vector2 movement;
    float horizontal, vertical;
    private float hf = 0;
    private float vf = 0;
    public float movementSpeed = 5.0f;
    private float lastX = 0;
    private float lastY = 0;
    public Vector3 movePosition;


    void Start ()
    {
      body = this.GetComponent<Rigidbody2D>();
      anim = this.GetComponent<Animator> ();
      lastY = -1;
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
        lastX = movement.x;
        lastY = movement.y;
      }
      if (Input.GetKeyDown("space")){
        anim.SetTrigger("fire");
        fireArrow();
      }
      if (Input.GetKeyUp("space")){
        anim.ResetTrigger("fire");
      }
    }
    void Awake(){
      GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");
      //DontDestroyOnLoad(this.gameObject);
    }

    void fireArrow(){
      GameObject b = (GameObject) Instantiate(arrow, transform.position, Quaternion.identity);
      //b.transform.parent = gameObject.transform.parent;

      if (lastY < 0 ) {//down{
        b.GetComponent<Rigidbody2D>().rotation = -80f;
        b.GetComponent<Rigidbody2D>().AddForce (-transform.up * 1000); //down
      }
      if (lastY > 0) {//up
        b.GetComponent<Rigidbody2D>().rotation = 80f;
        b.GetComponent<Rigidbody2D>().AddForce (transform.up * 1000);

      }
      if (lastX < 0) //left
        b.GetComponent<Rigidbody2D>().AddForce (-transform.right * 1000);
      if (lastX > 0) //right
        b.GetComponent<Rigidbody2D>().AddForce (transform.right * 1000);
    }

    void FixedUpdate()
    {
      body.MovePosition(body.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "projectile")
          Destroy(gameObject);
    }
}
