using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class YouDiedScreen : MonoBehaviour
{
    private float gameRestartTimer;

    public float timeToRestart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameRestartTimer += Time.deltaTime;

        if (gameRestartTimer > timeToRestart)
        {
            gameRestartTimer = 0;
            SceneManager.LoadScene("MainMenu");
        }


    }
}
