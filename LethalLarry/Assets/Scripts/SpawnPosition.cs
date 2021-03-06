using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
       FindObjectOfType<playerScript>().gameObject.transform.position = spawn.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
