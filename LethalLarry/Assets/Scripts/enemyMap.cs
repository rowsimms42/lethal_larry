using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMap : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
      //GameObject player = GameObject.FindGameObjectWithTag("Player");
      //Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Player")
       {
         Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
           // the player hit me
       }
   }
}
