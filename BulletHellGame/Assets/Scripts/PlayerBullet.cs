using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float playerXPos;
    private float playerYPos;
    public float bulletSpeed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerXPos = GameObject.Find("Player").GetComponent<Rigidbody2D>().position.x;
        playerYPos = GameObject.Find("Player").GetComponent<Rigidbody2D>().position.y;
        rb.position = new Vector3(playerXPos, playerYPos+.5f);
        rb.velocity = new Vector2(0, bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       
       if (other.gameObject.CompareTag("Enemy"))
       {
           Destroy(gameObject);
       }
       else if (other.gameObject.CompareTag("TopBorder"))
       {
           Destroy(gameObject);
       }
     
    }

}
