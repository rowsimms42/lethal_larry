using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level1script : MonoBehaviour
{
    //private int heartCount = 4;
    [SerializeField]
    Canvas starCanvas;
    public GameObject lev1;
    public playerScript pScript;
    public wizardScript wScript;
    public GameObject wall;
    public BoxCollider2D wallCollider;
    public sceneTransition sceneScript;
    //public Text heartText;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
      checkNextLevel();
    }

    void checkNextLevel(){
      if (wScript.NextLevel){
        wallCollider.enabled = false;
        wall.GetComponent<Collider2D>().enabled = false;
        wall.SetActive(false);
      }
    }

    public void returnToMenu(){
      Debug.Log("Going back to menu...");
      //Application.Quit();
      //Destroy(pScript.heartText);
      //Destroy(pScript.player);
      SceneManager.LoadScene("menu");
      //Destroy(pScript.player);
    }

    public IEnumerator gameOver()
    {
      Debug.Log("Going back to game over scene...");
      yield return new WaitForSeconds(4);
      SceneManager.LoadScene("GameOver");
      //Destroy(pScript.player);
    }

}
