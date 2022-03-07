using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private CharacterController controller;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
          
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 dir = new Vector3(x, 0, z);

        // if (dir.magnitude >= 0.0f)
        // {
        //     if (prevY == 0.0 && prevX == 0.0)
        //     {
        //         moveStartTime = Time.time;
        //
        //     }
        //     
        // }

       // float timeSinceLastMove = Time.time - moveStartTime;

       // float t = timeSinceLastMove / accelFactor;

        //float speed = Mathf.Lerp(0.0f, maxSpeed, t);

        controller.Move(dir * speed * Time.deltaTime);
        
        //Debug.Log(speed);

        //prevX = x;
        //prevY = y; 
    }
}
