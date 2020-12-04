using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public int speed = 7;
    public float slowSpeedModifier = .5f;
    private float slowSpeedMod = 1f;
    private Rigidbody2D rb;
    private float xinput = 0f;
    private float yinput = 0f;
    public float fireRate = .15f;

    private GameManager gm;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        //This is the slow down ships control lines, to allow for more controlled movement. 
        if (Input.GetKey(KeyCode.LeftControl))
        {
            slowSpeedMod = slowSpeedModifier;
        }
        else
        {
            slowSpeedMod = 1f;
        }

        //Movement and Player Input
        xinput = Input.GetAxis("Horizontal");
        yinput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(xinput * speed * slowSpeedMod, yinput * speed * slowSpeedMod);

        if (Input.GetKeyDown("space"))
        {
            StartCoroutine("ShootLoop");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
    

    //This will shoot bullets while space is held down!
    IEnumerator ShootLoop()
    {
        while(Input.GetKey("space"))
        { 
            Instantiate(bullet);
            yield return new WaitForSeconds(fireRate/1);
        }
    }
}

