using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class winScript : MonoBehaviour
{
    public void backToMenu(){
      Debug.Log("Going to menu...");
      SceneManager.LoadScene("menu");
    }
}
