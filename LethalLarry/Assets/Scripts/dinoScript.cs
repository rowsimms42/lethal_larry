using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dinoScript : MonoBehaviour
{
    public GameObject player;
    public int health = 4;
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
    public playerScript pScript;
    private Vector3 startPosition;
    public GameObject prefab;
    public AudioClip dinoDeathClip;
    private bool isDead = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //body = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator> ();
        moving = false;
        alertDino.enabled = false;
        startPosition = transform.position;
        

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
        StartCoroutine(enemyDead());
      }
    }
    void OnCollisionEnter2D(Collision2D c){
      if(c.gameObject.tag == "EnemyGrid")
      {
        moving = false;
        Debug.Log("colliding w wall");
      }
    }
    public IEnumerator enemyDead(){
        //anim.SetTrigger("death");
        //isDead = true;
      //GetComponent<AudioSource>().PlayOneShot(dinoDeathClip);
      yield return new WaitForSeconds(2);
        if(prefab)
            Instantiate(prefab, startPosition, transform.rotation);
        
      Destroy(this.gameObject);
    }
}
