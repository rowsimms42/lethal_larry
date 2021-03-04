using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level1script : MonoBehaviour
{
    private int starCount = 0;
    //private int heartCount = 4;
    private int s1, s2, s3 = 0;
    [SerializeField]
    Canvas starCanvas;
    public Text text;
    public GameObject star1, star2, star3;
    public Text heartText;
    public playerScript pScript;
    public wizardScript wScript;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
      checkStars();
      updateStarCount();
      updateHeartCount();
      checkNextLevel();
    }

    public void checkStars(){
      if (!star1.activeSelf)
          s1=1;
      if (!star2.activeSelf)
          s2=1;
      if (!star3.activeSelf)
          s3=1;
    }
    public void updateStarCount(){
      starCount = s1+s2+s3;
      text.text = "x " + starCount;

    }

    void checkNextLevel(){
      if (wScript.NextLevel){
        if (Input.GetKeyDown("c")){
          Debug.Log("Going to level 2...");
          SceneManager.LoadScene("level2");
        }
      }
    }

    public void updateHeartCount(){
      //string str = "\u2665".ToString() + "\u2665".ToString() + "\u2665".ToString() + "\u2665".ToString();
      if (pScript.heartCount > 3f){
        heartText.text =  "\u2665".ToString() + "\u2665".ToString() + "\u2665".ToString() + "\u2665".ToString();
      }
      else if (pScript.heartCount > 2f){
        heartText.text =  "\u2665".ToString() + "\u2665".ToString() + "\u2665".ToString();
      }
      else if (pScript.heartCount > 1f){
        heartText.text =  "\u2665".ToString() + "\u2665".ToString();
      }
      else if (pScript.heartCount > 0f){
        heartText.text =  "\u2665".ToString();
      }
      else if (pScript.heartCount <= 0f){
        heartText.text =  "--" ;
      }
      //heartText.text = "x " + pScript.heartCount;

      if (!pScript.Alive){
          Debug.Log("dead.");
          StartCoroutine(gameOver());
      }
    }

    public void returnToMenu(){
      Debug.Log("Going back to menu...");
      SceneManager.LoadScene("menu");
    }

    public IEnumerator gameOver()
    {
      Debug.Log("Going back to game over scene...");
      yield return new WaitForSeconds(4);
      SceneManager.LoadScene("GameOver");
      Destroy(pScript.player);
    }


    public int StarCount{get{return starCount;}}

}
