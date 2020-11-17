using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("SpawnBullets");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBullets()
    {
        yield return new WaitForSeconds(.5f);
        while (true)
        {
            
        }
    }
}
