using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public float bulletSpeed;

    public GameObject scoreController;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void BulletTravel()
    {
        transform.position += (Vector3.up * Time.deltaTime * bulletSpeed);
    }

        // Update is called once per frame
    void Update()
    {
        transform.position += (transform.up * Time.deltaTime * bulletSpeed);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Wall")
        {   
            Destroy(gameObject);
        }

        if (other.tag == "EnemyA")
        {
            Debug.Log("HitEnemyA");
            other.GetComponent<EnemyAI_A>().enemyHealth--;
            scoreController.GetComponent<ScoreManager>().currentScore++;
            Destroy(gameObject);
        }
    }
}
