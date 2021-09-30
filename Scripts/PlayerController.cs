using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public GameObject bulletPrefab;
    
    private float zBound = 30f;
    private float  yBound = 9f;

    private GameManager gameManager;

    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive){
            MovePlayer();
        ConstrainPlayerPosition();
        FireBullet();
        }
    }

    void MovePlayer(){
        float vInput;
        float hInput;

        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        transform.Translate(Vector3.forward * hInput * Time.deltaTime);
        transform.Translate(Vector3.up * vInput * Time.deltaTime);
    }

    void ConstrainPlayerPosition(){
        if(transform.position.z < -zBound){
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if(transform.position.z > zBound){
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if(transform.position.y < -yBound){
            transform.position = new Vector3(transform.position.x, -yBound, transform.position.z);
        }

        if(transform.position.y > yBound){
            transform.position = new Vector3(transform.position.x, yBound, transform.position.z);
        }
    }

    void FireBullet(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(bulletPrefab, transform.position, transform.rotation);

        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Asteroid") && gameManager.isGameActive){
            gameManager.isGameActive = false;
            gameManager.CancelInvoke();
            gameManager.GameOver();
        }
    }
}
