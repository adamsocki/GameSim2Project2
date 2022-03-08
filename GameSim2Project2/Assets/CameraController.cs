using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject camera;

    public GameObject player;
    public Vector3 cameraPositionShift;
    public Quaternion cameraPositionRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 cameraPosition = new Vector3(playerPosition.x, playerPosition.y , playerPosition.z);
        cameraPosition += cameraPositionShift;
        camera.GetComponent<Transform>().position = cameraPosition;
        //camera.GetComponent<Transform>().Translate(cameraPositionShift, Space.World);
        camera.GetComponent<Transform>().rotation = cameraPositionRotation;
    }
}
