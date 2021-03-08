//https://weeklyhow.com/unity-top-down-character-movement/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject arrow;
    public Transform projectileSpawnPosition;
    //public projectileBehavior ProjectilePrefab;
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
    public float heartCount = 4f;
    public bool alive;
    public int playerAlive;
    public Text heartText;
    public GameObject hearts;

    void Start ()
    {
      player = GameObject.FindGameObjectWithTag("Player");
      hearts = GameObject.FindGameObjectWithTag("Hearts");

      playerAlive = 0;
      body = player.GetComponent<Rigidbody2D>();
      anim = player.GetComponent<Animator> ();
      projectileSpawnPosition = player.GetComponent<Transform>();
      lastY = -1;
      alive = true;
      heartCount = 4f;
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

      checkHealth();
      //updateHeartCount();

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
      //public GameObject player = GameObject.FindGameObjectWithTag("Player");
      //public Transform projectileSpawnPositionprojectileSpawnPosition = player.GetComponent<Transform>();

      DontDestroyOnLoad (transform.gameObject);
    }

    void fireArrow(){
     
      GameObject b = (GameObject) Instantiate(arrow, projectileSpawnPosition.position, transform.rotation);

      if (lastY < 0 ) {//down{
        b.transform.eulerAngles = new Vector3(0,0,270);
        b.GetComponent<Rigidbody2D>().AddForce (-transform.up * 600); //down
      }
      if (lastY > 0) {//up
        b.transform.eulerAngles = new Vector3(0,0,90);
        b.GetComponent<Rigidbody2D>().AddForce (transform.up * 600);

      }
      if (lastX < 0) {//left
        b.transform.rotation = Quaternion.LookRotation(projectileSpawnPosition.forward * -1);
        b.GetComponent<Rigidbody2D>().AddForce (-transform.right * 600);
      }
      if (lastX > 0) {//right
        b.transform.rotation = Quaternion.LookRotation(projectileSpawnPosition.forward);
        b.GetComponent<Rigidbody2D>().AddForce (transform.right * 600);
      }
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
        if(col.gameObject.tag == "Enemy"){
            heartCount = heartCount - 1.0f;
        }
    }

    void checkHealth(){
      if (heartCount < 0.1){
        anim.SetTrigger("death");
        alive = false;
        playerAlive++;
        this.enabled = false;
        StartCoroutine(gameOver());
      }
    }

    public IEnumerator gameOver()
    {
      Debug.Log("Going back to game over scene...");
      yield return new WaitForSeconds(4);
      SceneManager.LoadScene("GameOver");
      Destroy(player);
    }

    public float HeartCount{get{return heartCount;}}
    public bool Alive{get{return alive;}}
    public int AlivePlayer{get{return playerAlive;}}
}
