using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTemplateController : MonoBehaviour
{
    public GameObject levelManager;
    public GameObject ground;
    
    public GameObject[] barrierSectors = new GameObject[4];
    public GameObject[] enemySectors = new GameObject[4];
    
    private Vector3 barrierPosition;
    private Vector3 barrierSize;

    public Vector3 enemyPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        float currentLevel = levelManager.GetComponent<LevelController>().currentLevel;
        float currentLevelZFactor = (100 * currentLevel);
        Vector3 positionForNewLevel = new Vector3(0, 1, currentLevelZFactor);

        gameObject.transform.position = positionForNewLevel;
        // enemy creation
        int numberOfEnemies = Random.Range(1, 4);
        for (int i = 0; i < 4; i++)
        {
            //enemy placement
            enemyPosition.x = Random.Range(-10, 15);
            enemyPosition.y = 1.5f;
            enemyPosition.z =  (-80f) + (15f * i) ;
            Debug.Log(enemyPosition.z);
            enemySectors[i].transform.localPosition = enemyPosition;
        }
        // Game
        for (int i = 0; i < 4; i++)
        {
            // barrier shape
            barrierSize.x = Random.Range(1, 20);
            barrierSize.y = Random.Range(1, 15);
            barrierSize.z = Random.Range(1, 15);
            barrierSectors[i].transform.localScale = barrierSize;
            
            // barrier placement
            barrierPosition.z = currentLevelZFactor - (80f) + (20f * i);
            barrierPosition.x = Random.Range(-20, 30);
            barrierPosition.y = ground.transform.localPosition.y + (barrierSize.y / 2) + 1.5f;
//            Debug.Log(barrierPosition.x);
            barrierSectors[i].transform.position = barrierPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
