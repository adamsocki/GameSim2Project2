using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTemplateGeneration : MonoBehaviour
{
    public GameObject nextLevel;
    public GameObject levelManager;

    public GameObject doorManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject bulletShotPlayer = Instantiate(nextLevel) as GameObject;
            levelManager.GetComponent<LevelController>().currentLevel++;
            doorManager.GetComponent<DoorOpenerCont>().openDoor = true;
            // ToDO: Add Logic here to set up new level attributes. 
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
