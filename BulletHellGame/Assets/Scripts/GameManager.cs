using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public TextMeshProUGUI scoreText;
    private int score;

    public List<GameObject> enemyList;
    public GameObject bossEnemyDude;
    private float enemySpawnRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Make a Coroutine to span enemies
        score = 0;
        UpdateScore(0);
        StartCoroutine("SpwanEnemies");
        StartCoroutine("SlowScoreIncrease");
        StartCoroutine("SpawnBoss");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SlowScoreIncrease()
    {
        while (true)
        {
            UpdateScore(1);
            yield return new WaitForSeconds(.69f);
        }
     }

    IEnumerator SpwanEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(.5f,enemySpawnRate));
            int index = Random.Range(0, enemyList.Count);
            Instantiate(enemyList[index]);
        }
    }

    IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(15f);
        while (true)
        {
            Instantiate(bossEnemyDude);
            yield return new WaitForSeconds(30f);

        }
    }
}
