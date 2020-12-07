using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowSpikeEnemy : MonoBehaviour
{
    private Rigidbody2D enemyRB;
    public GameObject redBullet;
    private float yellowFireRate = 3f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(Random.Range(-8.3f, 5.5f), Random.Range(4.5f, 5f));
        enemyRB.velocity = new Vector2(0, -3);
        StartCoroutine("MoveAndStop");
        

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerSpawn"))
        {
            Destroy(gameObject);
        }
        //else if (other.gameObject.CompareTag("Border"))
        //{
        //    Destroy(gameObject);
        //}
    }

    IEnumerator MoveAndStop()
    {
        yield return new WaitForSeconds(Random.Range(.2f,1.5f));
        enemyRB.velocity = new Vector2(0, 0);
        StartCoroutine("ShootAndAnimate");
    }
    IEnumerator ShootAndAnimate()
    {
        while (true)
        {
            for (int i = 0; i < 360; i += 30)
            {
                Instantiate(redBullet, enemyRB.position, Quaternion.Euler(0, 0, i));
            }
            yield return new WaitForSeconds(yellowFireRate);
            for (int i = 15; i < 375; i += 30)
            {
                Instantiate(redBullet, enemyRB.position, Quaternion.Euler(0, 0, i));
            }
            yield return new WaitForSeconds(yellowFireRate);
        }
    }
}
