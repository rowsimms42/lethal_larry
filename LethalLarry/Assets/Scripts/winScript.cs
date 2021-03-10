using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class winScript : MonoBehaviour
{
    public playerScript pScript;
    public void backToMenu(){
      Debug.Log("Going to menu...");
      Destroy(pScript.heartText);
      Destroy(pScript.player);
      SceneManager.LoadScene("menu");
    }
}
