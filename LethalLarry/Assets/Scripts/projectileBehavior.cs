using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBehavior : MonoBehaviour
{
    //public GameObject player;
    public GameObject arrowbody;
    Vector2 movement;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        arrowbody = GameObject.FindGameObjectWithTag("projectile");
    }
    // Update is called once per frame
    void Update()
    {
      DestroyObjectDelayed();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.tag == "Enemy"){
        //  col.gameObject.GetComponent<dinoScript>().health--;
        //}
        if (col.gameObject.tag != "Player"){
          Destroy(gameObject);
        }
          //Destroy(gameObject);
        //}
    }

    void DestroyObjectDelayed()
    {
        Destroy(gameObject, 0.5f);
    }
}
