using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{

    public Rigidbody asteroidRB;
    public float minSpeed = 8f;
    public float maxSpeed = 15f;
    public GameManager gameManager;
    public int pointValue;

    // Start is called before the first frame update
    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        asteroidRB = GetComponent<Rigidbody>();
        AsteroidMovements();

    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public Vector3 RandomForce(){
        return Vector3.down * Random.Range(minSpeed, maxSpeed);
    }

    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Bullet") && gameManager.isGameActive){
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }

    public void AsteroidMovements(){
        asteroidRB.AddForce(RandomForce(), ForceMode.Impulse);
    }
}
