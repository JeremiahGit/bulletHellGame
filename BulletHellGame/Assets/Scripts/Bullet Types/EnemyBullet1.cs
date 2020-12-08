using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet1 : MonoBehaviour
{
    // Start is called before the first frame update

    /* I want to make 4 types of bullets
     * 1. Goes Straight Down
     * 2. Goes in a random downwards direction
     * 3. Is pointed at the player's current location
     * 4. Fans out in a spread */
    private Rigidbody2D rb;
    private float startingYPos;
    private float startingXPos;
    public float bulletSpeed = 4f;
    private int bulletType;

    public GameObject Player;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-bulletSpeed*Mathf.Sin(Mathf.Abs(rb.transform.rotation.eulerAngles.z * Mathf.Deg2Rad)), bulletSpeed * Mathf.Cos(Mathf.Abs(rb.transform.rotation.eulerAngles.z * Mathf.Deg2Rad)));
    }

    // Update is called once per frame  
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("TopBorder"))
        {
            Destroy(gameObject);
        }
    }

}
