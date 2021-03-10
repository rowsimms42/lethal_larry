using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lev2script : MonoBehaviour
{
  //private int heartCount = 4;
  [SerializeField]
  Canvas starCanvas;
  public wizardScript wScript;
  public GameObject wall;
  public BoxCollider2D wallCollider;
  public sceneTransition sceneScript;
  public GameObject lev2;


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
    //SceneManager.LoadScene("menu");
  }

  void checkNextLevel(){
    if (wScript.NextLevel){
      wallCollider.enabled = false;
      wall.GetComponent<Collider2D>().enabled = false;
      wall.SetActive(false);
    }
  }//

  public void goTo3a(){
    Debug.Log("Going to 3...");
    SceneManager.LoadScene("level3");
  }
}
