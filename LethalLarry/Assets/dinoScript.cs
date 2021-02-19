using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinoScript : MonoBehaviour
{
    public GameObject player;
    public float minDistance;
    public float speed;
    public float minAttackDistance;
    private float attackTimer = 0;
    public float attackCoolDown;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime; //how many sec passed since start
        if (Vector2.Distance(this.transform.position, player.transform.position) <= minAttackDistance){ //dino position, player position
            if (attackTimer >= attackCoolDown){
              Debug.Log("attack");
              attackTimer = 0;
            }
        }
        if (Vector2.Distance(this.transform.position, player.transform.position) <= minDistance){ //dino position, player position
            transform.Translate((player.transform.position - this.transform.position) * Time.deltaTime * speed); //direction
        }
    }
}
