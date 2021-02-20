using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level1script : MonoBehaviour
{
    public int starCount = 0;
    private int s1, s2, s3 = 0;
    [SerializeField]
    Canvas starCanvas;
    public Text text;
    public GameObject star1, star2, star3;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        checkStars();
        updateStarCount();
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

    public void returnToMenu(){
        Debug.Log("Going back to menu...");
        SceneManager.LoadScene("menu");
    }
}
