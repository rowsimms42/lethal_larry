using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lev3script : MonoBehaviour
{
    //private int heartCount = 4;
  [SerializeField]
  Canvas starCanvas;
  public playerScript pScript;
  public wizardScript wScript;
  public GameObject wall;
  public BoxCollider2D wallCollider;
  public sceneTransition sceneScript;
  public GameObject lev3;

  // Start is called before the first frame update
  void Start()
  {

  }
  // Update is called once per frame
  void Update()
  {
    checkNextLevel();
  }

  public void returnToMenu(){
    Debug.Log("Going back to menu...");
    SceneManager.LoadScene("menu");
  }

  void checkNextLevel(){
    if (wScript.NextLevel){
      wallCollider.enabled = false;
      wall.GetComponent<Collider2D>().enabled = false;
      wall.SetActive(false);
    }
  }//

  public void goTo4(){
    Debug.Log("Going to 4...");
    SceneManager.LoadScene("level4");
  }
}
