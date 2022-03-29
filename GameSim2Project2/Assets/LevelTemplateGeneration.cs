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
            //GameObject level = new GameObject("")
            
            //GameObject bulletShotPlayer = Instantiate(nextLevel) as GameObject;
            
            levelManager.GetComponent<LevelController>().currentLevel++;
            
            GameObject newLevel = Instantiate(nextLevel);
            for (int i = 0; i < 4; i++)
            {
                //nextLevel.GetComponent<LevelTemplateController>().enemySectors[i].GetComponent<EnemyAI_A>().enemyState =
                    //EnemyAI_A.AIState.Walking;
                  //  newLevel.GetComponent<LevelTemplateController>().enemySectors[i].GetComponent<EnemyAI_A>()
                //        .enemyHealth = 1;
                 //   newLevel.GetComponent<LevelTemplateController>().enemySectors[i].GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
            
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
