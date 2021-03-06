using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBehavior : MonoBehaviour
{
    //public GameObject player;
    Vector2 movement;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
      DestroyObjectDelayed();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag != "Player"){
          if (col.gameObject.tag == "Enemy"){
            col.gameObject.GetComponent<dinoScript>().health--;
          }
          Destroy(gameObject);
        }
    }

    void DestroyObjectDelayed()
    {
        Destroy(gameObject, 0.5f);
    }
}
