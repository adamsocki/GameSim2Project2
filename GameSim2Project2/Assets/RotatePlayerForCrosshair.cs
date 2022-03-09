using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerForCrosshair : MonoBehaviour
{
    public GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(crosshair.transform.position);
        // Vector3 rotate = new Vector3(90f, 0, 0);
        // transform.Rotate(rotate);
    }
}
