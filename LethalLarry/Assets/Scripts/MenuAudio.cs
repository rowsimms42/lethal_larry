using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += destroyGameObject;
        DontDestroyOnLoad(this.gameObject);
    }

    void destroyGameObject(Scene s, LoadSceneMode lsm)
    {
        if(s.name == "lev1")
        {
            SceneManager.sceneLoaded -= destroyGameObject;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
