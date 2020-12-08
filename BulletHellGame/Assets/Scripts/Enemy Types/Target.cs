using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gm;

    private Rigidbody2D enemyRB;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        enemyRB = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(Random.Range(-8.3f,5.5f), Random.Range(4.5f,5f));
        enemyRB.velocity = new Vector2(0, -3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerSpawn"))
        {
            gm.UpdateScore(20);
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}  
