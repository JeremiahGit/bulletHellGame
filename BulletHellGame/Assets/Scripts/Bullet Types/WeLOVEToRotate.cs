using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeLOVEToRotate : MonoBehaviour
{
    private Rigidbody2D rb;
    private float startingYPos;
    private float startingXPos;
    public float bulletSpeed = 4f;
    private int bulletType;
    private float rotationDegree = 12f; 
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(bulletSpeed * Mathf.Cos(Mathf.Abs(rb.transform.rotation.eulerAngles.z * Mathf.Deg2Rad)), -bulletSpeed * Mathf.Cos(Mathf.Sin(rb.transform.rotation.eulerAngles.z * Mathf.Deg2Rad)));
        StartCoroutine("ROTATEEEE");

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator ROTATEEEE()
    {
        while (true)
        {
            yield return new WaitForSeconds(.05f);
            rb.transform.Rotate(0, 0, rotationDegree);
             
        }
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
