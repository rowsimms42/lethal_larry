//https://unity.grogansoft.com/speech-bubbles-and-popup-ui/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class starScript : MonoBehaviour
{
    [SerializeField]
    Canvas messageStar;
    //Canvas starCanvas;
    public Text text;
    public Text heartText;
    public GameObject star;
    bool atStar = false;
    private static int count = 0;
    public GameObject player;
    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        count = 0;
        messageStar.enabled = false;
        star.SetActive(true);
    }
    // Update is called once per frame
    void Update(){
      if (atStar == true){
        if (Input.GetKeyDown("c")){
          star.SetActive(false);
          messageStar.gameObject.SetActive(false);
          count++;
        }
      }
      //checkStars();
      updateStarCount();
    }
    void OnCollisionEnter2D(Collision2D c){
      if(c.gameObject.tag == "Player"){
        atStar = true;
        TurnOnMessage();
      }
    }
    void OnCollisionExit2D(Collision2D c){
      if(c.gameObject.tag == "Player")
      {
        atStar = false;
        TurnOffMessage();
      }
    }
    void TurnOnMessage(){
      messageStar.enabled = true;
    }
    void TurnOffMessage(){
      messageStar.enabled = false;
    }

    public void updateStarCount(){
      text.text = "x " + count;
      //Debug.Log(count);

    }


    public int StarCount{get{return count;}}
/*
    void OnGUI(){
      if (triggered){
        GUI.skin.label.fontSize = 27;
        GUI.Label(new Rect (710, 250, 600, 100), "Press 'i' to interact..");
        Debug.Log("gui");
      }
    }*/
}
