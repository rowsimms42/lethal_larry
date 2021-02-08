using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void directionPage(){
      Debug.Log("Going to directions...");
      SceneManager.LoadScene("Directions");
    }

    public void playGame(){
      Debug.Log("Starting game...");
      SceneManager.LoadScene("SampleScene");
    }

    public void exitGame(){
      Debug.Log("Exiting...");
      Application.Quit();
    }
}
