using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTemplateController : MonoBehaviour
{
    public GameObject levelManager;

    public GameObject barrierSector1;
    
    public GameObject[] barrierSectors = new GameObject[4];

    public Vector3 barrier1Test;
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
        // barrier creation
        gameObject.transform.position = positionForNewLevel; 
        // barrier placement
        
      
        for (int i = 0; i < 4; i++)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        float currentLevel = levelManager.GetComponent<LevelController>().currentLevel;
        float currentLevelZFactor = (100 * currentLevel);
        barrier1Test.z = currentLevelZFactor;
        barrierSectors[0].transform.position = barrier1Test;
    }
}
