using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    
    public Text highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        StreamReader reader = new StreamReader("Assets/highScore.txt");
        string highScoreReader = reader.ReadLine();
        highScore.text = highScoreReader;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
