using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinoScript : MonoBehaviour
{
    public GameObject player;
    Animator anim;
    public float minDistance;
    public float minAttackDistance;
    private float attackTimer = 0;
    public float attackCoolDown;
    Vector2 diff;
    public float speed = 4f;
    private float dhf;
    private float dvf;
    private bool moving;
    private float alertTimer = 0;
    [SerializeField]
    Canvas alertDino;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = this.GetComponent<Animator> ();
        moving = false;
        alertDino.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving){
          diff = player.transform.position - this.transform.position;
          dhf = diff.x > 0.01f ? diff.x : diff.x < -0.01f ? 1 : 0;
          dvf = diff.y > 0.01f ? diff.y : diff.y < -0.01f ? 1 : 0;
          if (diff.x < -0.01f)
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
          else
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
          anim.SetFloat("x", dhf);
          anim.SetFloat("y", diff.y);
          alertTimer += Time.deltaTime;
          if (alertTimer < 1){
            TurnOnMessage();
          }
        }
        if (alertTimer > 1){
          TurnOffMessage();
        }
        //transform.Translate(player.transform.position * Time.deltaTime * speed); //direction
        attackTimer += Time.deltaTime; //how many sec passed since start

        if (Vector2.Distance(this.transform.position, player.transform.position) <= minAttackDistance){ //dino position, player position
            if (attackTimer >= attackCoolDown){
              Debug.Log("attack");
              attackTimer = 0;
              moving = true;
            }
        }
        if (Vector2.Distance(this.transform.position, player.transform.position) <= minDistance){ //dino position, player position
            transform.Translate((player.transform.position - this.transform.position) * Time.deltaTime * speed); //direction
            anim.SetFloat("follow", 1);
            moving = true;
        }
        if (Vector2.Distance(this.transform.position, player.transform.position) > minDistance){
            anim.SetFloat("follow", -1);
            moving = false;
            alertTimer = 0;
        }
    }

    void TurnOnMessage(){
        alertDino.enabled = true;
    }
    void TurnOffMessage(){
        alertDino.enabled = false;
    }
}
