using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.IO;

public class ScoreManager : MonoBehaviour
{

    public int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void WriteHighScore()
    {
        StreamReader reader = new StreamReader("highScore.txt");
        string scoreReader = reader.ReadLine();
        int scoreInt = int.Parse(scoreReader);
        
        Debug.Log(scoreInt);
        
        
        StreamWriter writer = new StreamWriter("highScore.txt", true);
        //writer.Write(current)
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
