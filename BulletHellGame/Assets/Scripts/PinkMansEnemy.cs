using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkMansEnemy : MonoBehaviour
{
    private Rigidbody2D enemyRB;
    public GameObject pinkBullet;
    private float pinkFireRate = 3f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(Random.Range(-8.3f, 5.5f), Random.Range(4.5f, 5f));
        enemyRB.velocity = new Vector2(0, -12);
        StartCoroutine("Exist");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Exist()
    {
        yield return new WaitForSeconds(Random.Range(.2f, .3f));
        enemyRB.velocity = new Vector2(0, 0);
        StartCoroutine("SpreadShot");
    }

    IEnumerator SpreadShot()
    {
        while (true)
        {
            for (int i = 0; i < 360; i += 30)
            {
                Instantiate(pinkBullet, enemyRB.position, Quaternion.Euler(0, 0, i));
            }
            yield return new WaitForSeconds(pinkFireRate);
            for (int i = 15; i < 375; i += 30)
            {
                Instantiate(pinkBullet, enemyRB.position, Quaternion.Euler(0, 0, i));
            }
            yield return new WaitForSeconds(pinkFireRate);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
     if (other.gameObject.CompareTag("PlayerSpawn"))
      { 
         Destroy(gameObject);
      }
     else if (other.gameObject.CompareTag("Border"))
         {
           Destroy(gameObject);
         }
    }
}
