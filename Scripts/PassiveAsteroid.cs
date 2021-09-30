using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAsteroid : Asteroids
{
    public int passiveValue = -10;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        asteroidRB = GetComponent<Rigidbody>();
        AsteroidMovements();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Player") && gameManager.isGameActive){
            gameManager.UpdateScore(passiveValue);
            gameManager.isGameActive = true;
        }
    }
    
}
