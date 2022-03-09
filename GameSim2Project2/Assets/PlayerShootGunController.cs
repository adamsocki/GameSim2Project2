using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootGunController : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletShotPlayer = Instantiate(bullet) as GameObject;
            bulletShotPlayer.SetActive(true);
            bulletShotPlayer.transform.position = transform.position;
            bulletShotPlayer.transform.rotation = transform.rotation;
        }
        
    }
}
