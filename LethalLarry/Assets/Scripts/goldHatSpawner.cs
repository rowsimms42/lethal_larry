using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldHatSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float delay;

    public void spawnGoldHat(){
      StartCoroutine(spawnGoldHatEnum());
    }
    private IEnumerator spawnGoldHatEnum(){
      yield return new WaitForSeconds(delay);
      prefab.SetActive(true);
      prefab.transform.position = this.transform.position;
      prefab.transform.rotation = this.transform.rotation;
      prefab.GetComponent<goldHatScript>().Start();
    }

}
