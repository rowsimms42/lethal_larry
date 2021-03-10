using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wizardLevel4 : MonoBehaviour
{
  [SerializeField]
  Canvas messageCanvas;
  public GameObject wizard;
  Rigidbody2D wizbody;
  bool triggered = false;
  public Text text;
  string wizardResponse;
  public bool nextLevel;

  // Start is called before the first frame update
  void Start(){
      BoxCollider2D col = wizard.GetComponent<BoxCollider2D>();
      messageCanvas.enabled = false;
      wizardResponse = "You've done well, Larry. \n You may now wake up from your dream. \n Step into the light.";
      nextLevel = false;
  }

  // Update is called once per frame
  void Update(){
    if (triggered == true){
      if (Input.GetKeyDown("i")){
          text.text = wizardResponse;
          nextLevel = true;
      }
    }
  }
  void OnCollisionEnter2D(Collision2D c){
    if(c.gameObject.tag == "Player"){
      triggered = true;
      TurnOnMessage();
    }
  }
  void OnCollisionExit2D(Collision2D c){
    if(c.gameObject.tag == "Player")
    {
      triggered = false;
      TurnOffMessage();
    }
  }
  void TurnOnMessage(){
    messageCanvas.enabled = true;
  }
  void TurnOffMessage(){
    messageCanvas.enabled = false;
    text.text = "Press 'i' to interact...";
  }
  public bool NextLevel{get{return nextLevel;}}
}
