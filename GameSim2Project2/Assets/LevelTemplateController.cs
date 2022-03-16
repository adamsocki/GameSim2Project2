using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTemplateController : MonoBehaviour
{
    public GameObject levelManager;

    public GameObject barrierSector1;
    
    public GameObject[] barrierSectors = new GameObject[4];

    private Vector3 barrierPosition;
    // Start is called before the first frame update
    void Start()
    {
        
        float currentLevel = levelManager.GetComponent<LevelController>().currentLevel;
        float currentLevelZFactor = (100 * currentLevel);
        Vector3 positionForNewLevel = new Vector3(0, 1, currentLevelZFactor);

        // enemy creation
        int numberOfEnemies = Random.Range(0, 4);

        for (int i = 0; i < numberOfEnemies; i++)
        {
                
            
        }
        // Gme
        
        gameObject.transform.position = positionForNewLevel;
        for (int i = 0; i < 4; i++)
        {
            // barrier shape
            
            //barrierSectors[i].transform.localScale = 
            
            // barrier placement
            barrierPosition.z = currentLevelZFactor - (80f) + (20f * i);
            barrierPosition.x = Random.Range(-20, 30);
            Debug.Log(barrierPosition.x);
            barrierSectors[i].transform.position = barrierPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
