using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 35f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Asteroid")){
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("PassiveAsteroid")){
            Destroy(gameObject);
        }
    }

}
