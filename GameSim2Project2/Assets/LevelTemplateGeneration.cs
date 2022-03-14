using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTemplateGeneration : MonoBehaviour
{
    public GameObject nextLevel;
    public GameObject levelManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject bulletShotPlayer = Instantiate(nextLevel) as GameObject;
            levelManager.GetComponent<LevelController>().currentLevel++;
            // ToDO: Add Logic here to set up new level attributes. 
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
