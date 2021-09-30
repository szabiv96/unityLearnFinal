using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] asteroids;
    public bool isGameActive;

    private float zEnemySpawn = 27f;
    private float yEnemySpawn = 20f;
    private float startDelay = 1f;
    private float enemySpawnTime = 1f;

    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    

     void Start()
    {
        StartGame();
    }


    // Start is called before the first frame update
    public void StartGame(){
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        score = 0;
        isGameActive = true;
    }

    public void GameOver(){
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
    }


    public void SpawnRandomEnemy(){
        float randomZ = Random.Range(-zEnemySpawn, zEnemySpawn);
        int randomIndex = Random.Range(0, asteroids.Length);
        Vector3 spawnPos = new Vector3(60, yEnemySpawn, randomZ);

        Instantiate(asteroids[randomIndex], spawnPos, asteroids[randomIndex].gameObject.transform.rotation);

    }

    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
