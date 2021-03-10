using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goldHatScript : MonoBehaviour
{
    public GameObject player;
    public int health;
    public int maxHealth;
    Animator anim;
    public float minDistance, minAttackDistance, attackCoolDown;
    private float attackTimer = 0;
    Vector2 diff;
    public float speed = 4f;
    private float dhf = 0;
    private float dvf = 0;
    private bool moving;
    private float alertTimer = 0;
    [SerializeField]
    Canvas alertDino;
    public Text text;
    private goldHatSpawner goldSpawner;
    public GameObject prefab;
    public float spawnDelay;

    public void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = this.GetComponent<Animator> ();
        moving = false;
        alertDino.enabled = false;
        if (!goldSpawner)
        {
          GameObject spawner = new GameObject("spawner");
          goldSpawner = spawner.AddComponent<goldHatSpawner>();
          goldSpawner.prefab = this.gameObject;
          goldSpawner.delay = spawnDelay;
          spawner.transform.position = this.transform.position;
          spawner.transform.rotation = this.transform.rotation;
        }
    }
    // Update is called once per frame
    void Update()
    {
        checkEnemyHealth();
        if (player.gameObject.GetComponent<playerScript>().heartCount > 0f){
          playDino();
        }
        else{
          anim.SetFloat("follow", -1);
          moving = false;
        }
    }

    void playDino(){
      if (moving){
        updateDino();
      }
      if (alertTimer > 1){ //&& attackTimer > 1){
        TurnOffMessage();
      }
      followOrIdle();
    }

    void followOrIdle(){
      //transform.Translate(player.transform.position * Time.deltaTime * speed); //direction
      attackTimer += Time.deltaTime; //how many sec passed since start
      if (Vector2.Distance(this.transform.position, player.transform.position) <= minAttackDistance){ //dino position, player position
          if (attackTimer >= attackCoolDown){
            Debug.Log("attack");
            anim.SetTrigger("pitch");
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

    void updateDino(){
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

    void TurnOnMessage(){
        alertDino.enabled = true;
    }
    void TurnOffMessage(){
        alertDino.enabled = false;
        //text.text = "!";
    }
    void checkEnemyHealth(){
      if (health <=0 ){
        goldSpawner.spawnGoldHat();
        this.gameObject.SetActive(false);
      }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "projectile"){
          health--;
        }
  //}
    }


}
