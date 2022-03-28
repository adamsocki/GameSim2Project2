using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    public float playerHealth;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Move()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 dir = new Vector3(x, 0, z);
        controller.Move(dir * speed * Time.deltaTime);
    }

    public void Shoot()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
