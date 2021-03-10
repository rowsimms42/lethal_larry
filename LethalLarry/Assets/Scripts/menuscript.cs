using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    void Start(){
      canvas.gameObject.SetActive(false);
    }

    public void gameInfoPage(){
      Debug.Log("Going to directions...");
      canvas.gameObject.SetActive(true);
    }

    public void backToMenu(){
      Debug.Log("Going to directions...");
      canvas.gameObject.SetActive(false);
    }

    public void playGame(){
      Debug.Log("Starting game...");
      SceneManager.LoadScene("lev1");
    }

    public void exitGame(){
      Debug.Log("Exiting...");
      Application.Quit();
    }
}
