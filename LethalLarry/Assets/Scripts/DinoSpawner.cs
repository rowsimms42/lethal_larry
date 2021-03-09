using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float delay;

    public void spawnDino(){
      StartCoroutine(spawnDinoEnum());
    }
    private IEnumerator spawnDinoEnum(){
      yield return new WaitForSeconds(delay);
      prefab.SetActive(true);
      prefab.transform.position = this.transform.position;
      prefab.transform.rotation = this.transform.rotation;
      prefab.GetComponent<dinoScript>().Start();
    }

}
