using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level1script : MonoBehaviour
{
    private int starCount = 0;
    private int heartCount = 4;
    private int s1, s2, s3 = 0;
    private float wait = 0f;
    [SerializeField]
    Canvas starCanvas;
    public Text text;
    public GameObject star1, star2, star3;
    public Text heartText;
    public playerScript pScript;

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

    public void updateHeartCount(){
      heartText.text = "x " + pScript.heartCount;
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
      Application.LoadLevel("GameOver");
    }


    public int StarCount{get{return starCount;}}

}
