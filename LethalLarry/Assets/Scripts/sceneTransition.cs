using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransition : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Testing rodent");
        if(collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    
}
