using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRayCast : MonoBehaviour
{
    public GameObject gunOrigin;
    public GameObject player;
    public GameObject crosshair;

    public GameObject gunDirection;
    
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        // transform.LookAt(crosshair.transform.position);
        // Vector3 rotate = new Vector3(90f, 0, 0);
        // transform.Rotate(rotate);
        Ray rayPlayerGun = new Ray(gunOrigin.transform.position, gunOrigin.transform.up);
        Physics.Raycast(rayPlayerGun, out RaycastHit hitInfo);
        Debug.DrawRay(gunOrigin.transform.position, gunOrigin.transform.up, Color.black);
        //Debug.Log(hitInfo.distance);
        
        Ray rayPlayer = new Ray(player.transform.position, Vector3.forward);
        Physics.Raycast(rayPlayer, out hitInfo);
        Debug.DrawRay(player.transform.position, player.transform.forward, Color.red);

        Physics.Linecast(player.transform.position, crosshair.transform.position);
        Debug.DrawLine(player.transform.position, crosshair.transform.position, Color.blue);

    }
}
