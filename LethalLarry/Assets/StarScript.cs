//https://unity.grogansoft.com/speech-bubbles-and-popup-ui/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScript : MonoBehaviour
{
    [SerializeField]
    Canvas messageStar;
    public GameObject star1;
    bool atStar = false;
    // Start is called before the first frame update
    void Start(){
        messageStar.enabled = false;
        //star1 = GameObject.Find("Star1");
        star1.SetActive(true);
    }
    // Update is called once per frame
    void Update(){
      if (atStar == true){
        if (Input.GetKeyDown("c")){
          star1.SetActive(false);
          messageStar.gameObject.SetActive(false);
        }
      }
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
/*
    void OnGUI(){
      if (triggered){
        GUI.skin.label.fontSize = 27;
        GUI.Label(new Rect (710, 250, 600, 100), "Press 'i' to interact..");
        Debug.Log("gui");
      }
    }*/
}
