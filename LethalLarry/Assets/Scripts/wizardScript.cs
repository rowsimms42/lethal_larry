//https://unity.grogansoft.com/speech-bubbles-and-popup-ui/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wizardScript : MonoBehaviour
{
    [SerializeField]
    Canvas messageCanvas;
    public GameObject wizard;
    Rigidbody2D wizbody;
    bool triggered = false;
    public Text text;
    string[] wizardResponses = new string [4];
    public level1script lev1;
    public bool nextLevel;

    // Start is called before the first frame update
    void Start(){
        BoxCollider2D col = wizard.GetComponent<BoxCollider2D>();
        messageCanvas.enabled = false;
        wizardResponses[0] = "Hello, Larry. \n Please collect 3 stars and bring them to me.";
        wizardResponses[1] = "You have 1 star, 2 more to go.";
        wizardResponses[2] = "2 stars down, 1 more to go.";
        wizardResponses[3] = "You have all 3 stars. \n I can now free you from this level. \n Enter 'c'.";
        nextLevel = false;
    }

    // Update is called once per frame
    void Update(){
      if (triggered == true){
        if (Input.GetKeyDown("i")){
            text.text = wizardResponses[lev1.StarCount];
            if (lev1.StarCount == 3){
              nextLevel = true;
          }
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
/*
    void OnGUI(){
      if (triggered){
        GUI.skin.label.fontSize = 27;
        GUI.Label(new Rect (710, 250, 600, 100), "Press 'i' to interact..");
        Debug.Log("gui");
      }
    }*/
}
