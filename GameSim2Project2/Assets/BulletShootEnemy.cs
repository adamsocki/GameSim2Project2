using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootEnemy : MonoBehaviour
{
    public float bulletSpeed;

    //public GameObject scoreController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.forward * Time.deltaTime * bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().playerHealth--;
            Destroy(gameObject);
        }
        else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
