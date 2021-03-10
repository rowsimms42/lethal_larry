using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lev4script : MonoBehaviour
{
    // Start is called before the first frame update
    //private int heartCount = 4;
  [SerializeField]
  public playerScript pScript;
  public wizardLevel4 wScript4;
  public GameObject wall;
  public BoxCollider2D wallCollider;
  public sceneTransition sceneScript;
  public GameObject lev4;
  public bool nextLevel;


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
    if (wScript4.NextLevel){
      wallCollider.enabled = false;
      wall.GetComponent<Collider2D>().enabled = false;
      wall.SetActive(false);
    }
  }//

  public void goToWonScene(){
    Debug.Log("Going to winning scene...");
    SceneManager.LoadScene("WinScene");
  }
}
