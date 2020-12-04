﻿using System.Collections;
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

        // Update is called once per frame  
        //rb.velocity = new Vector2(bulletSpeed* Mathf.Cos(Mathf.Abs(rb.transform.rotation.eulerAngles.z* Mathf.Deg2Rad)), -bulletSpeed* Mathf.Cos(Mathf.Sin(rb.transform.rotation.eulerAngles.z* Mathf.Deg2Rad)));

    }

    // Update is called once per frame  
    void Update()
    {
        //rb.velocity = transform.forward * bulletSpeed;
        //transform.Translate(Vector3.forward * Time.deltaTime);
    }

    /*This will be called right after the initalization of the object
    public void Initialise(int _bulletType, float Xpos, float YPos)
    {
        bulletType = _bulletType;
        rb.position = new Vector3(Xpos, YPos);

        switch (bulletType)
        {
            case 1:
                setBulletType1();
                break;
            case 2:
                setBulletType2();
                break;
            case 3:
                Debug.Log('3');
                break;
            case 4:
                Debug.Log('4');
                break;
        }
    }

    //This will send the bullet in a downwards trajectory
    public void setBulletType1()
    {
        rb.velocity = new Vector2(0, -bulletSpeed);
    }
    */

    //This will make the the bullet face in a downwards range and move in that path
    public void setBulletType2()
    {
        rb.transform.Rotate(0,0,Random.Range(-75f, 75f));
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
