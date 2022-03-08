using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerManager;

    public GameObject cameraManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        PlayerController player = playerManager.GetComponent<PlayerController>();
        player.Move();
        player.Shoot();
        
        

    }
}
