using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenerCont : MonoBehaviour
{
    public GameObject rightDoor;
    public GameObject leftDoor;
    public bool openDoor;
    public float doorSpeed;
    public AudioSource doorSound;
    public AudioClip clip;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (openDoor)
        {
            doorSound.Play();
            Vector3 rightMovement = Vector3.right;
            Vector3 leftMovement = Vector3.left;
            rightDoor.transform.position += (rightMovement * Time.deltaTime * doorSpeed);
            leftDoor.transform.position += (leftMovement * Time.deltaTime * doorSpeed);

            if (rightDoor.transform.position.x > 42)
            {
                openDoor = false;
            }
        }
    }
}
