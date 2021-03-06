using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour
{
  public GameObject hearts;
  public Text heartText;
  public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
      if (player){
        updateHeartCount();
      }
    }
    public void updateHeartCount(){

      //string str = "\u2665".ToString() + "\u2665".ToString() + "\u2665".ToString() + "\u2665".ToString();
      if (player.gameObject.GetComponent<playerScript>().heartCount > 3f){
        heartText.text =  "\u2665".ToString() + "\u2665".ToString() + "\u2665".ToString() + "\u2665".ToString();
      }
      else if (player.gameObject.GetComponent<playerScript>().heartCount > 2f){
        heartText.text =  "\u2665".ToString() + "\u2665".ToString() + "\u2665".ToString();
      }
      else if (player.gameObject.GetComponent<playerScript>().heartCount > 1f){
        heartText.text =  "\u2665".ToString() + "\u2665".ToString();
      }
      else if (player.gameObject.GetComponent<playerScript>().heartCount > 0f){
        heartText.text =  "\u2665".ToString();
      }
      else if (player.gameObject.GetComponent<playerScript>().heartCount <= 0f){
        heartText.text =  " " ;
      }
    }
      //heartText.text = "x " + pScript.heartCount;
    void Awake(){
      DontDestroyOnLoad(hearts);
    }
}
