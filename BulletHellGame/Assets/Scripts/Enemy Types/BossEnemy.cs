using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    private GameManager gm;

    private Rigidbody2D bossRB;
    public GameObject bossSummon;
    public float bossHealth = 50f;
    private float bossSummonRate = 15f;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        bossRB = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(-10, 3); // Starting x,y position
        bossRB.velocity = new Vector2(0,0);
        StartCoroutine("BossXMovement");
        StartCoroutine("BossYMovement");
        StartCoroutine("SummonMinions");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BossXMovement()
    {
        while (true)
        {
            bossRB.velocity = new Vector2(3, 0);
            yield return new WaitForSeconds(7f);
            bossRB.transform.localScale = new Vector3(-1.5f, 1.5f, 1f);

            bossRB.velocity = new Vector2(-3, 0);
            yield return new WaitForSeconds(7f);
            bossRB.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        }
    }

    IEnumerator BossYMovement()
    {
        while (true)
        {
            bossRB.velocity = new Vector2(0, 3);
            yield return new WaitForSeconds(Random.Range(2f,3f));

            bossRB.velocity = new Vector2(0, -3);
            yield return new WaitForSeconds(7f);
            yield return new WaitForSeconds(Random.Range(2f, 3f));
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerSpawn"))
        {
            gm.UpdateScore(20);
            Destroy(gameObject);
        }
    }

    IEnumerator SummonMinions()
    {
        while (true)
        {
            for (int i = 0; i < 10; i += 1)
            {
                Instantiate(bossSummon);
            }
            yield return new WaitForSeconds(bossSummonRate);

        }
    }
}
