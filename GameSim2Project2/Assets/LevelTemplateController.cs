using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTemplateController : MonoBehaviour
{
    public GameObject levelManager;
    // Start is called before the first frame update
    void Start()
    {
        float currentLevel = levelManager.GetComponent<LevelController>().currentLevel;
        Vector3 position = new Vector3(0, 1, (100 * currentLevel));
        gameObject.transform.position = position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
