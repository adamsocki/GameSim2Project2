using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_A : MonoBehaviour
{
    public bool enemyOnGround;
    public enum AIState
    {
        Walking,
        LookingForPlayer,
        LookingAtPlayer,
        ShootingAtPlayer,
        AttackingPlayer,
        Dead
    }
    public enum SearchForPlayerState
    {
        WalkForward,
        TurnAround
    }

    public Vector3 rotation;

    private CharacterController controller;
    public float rotateSpeed;
    public float seachForPlayerSpeed;
    public AIState enemyState;

    public SearchForPlayerState searchState;
    //AIState enemyState = AIState.Walking;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        enemyState = AIState.Walking;
    }

    private void SearchForPlayer()
    {
       
        //enemy vision
        Ray rayEnemyVision = new Ray(transform.position, transform.forward);
        Physics.Raycast(rayEnemyVision, out RaycastHit rayEnemyVisionInfo);
        //Debug.Log(rayEnemyVisionInfo.collider);
        Debug.DrawRay(transform.position, transform.forward, Color.green);

        if (rayEnemyVisionInfo.collider.tag == "Player")
        {
            enemyState = AIState.AttackingPlayer;
        }
        
        // enemy walk
        Vector3 dir = new Vector3(0,0,0);
        switch (searchState)
        {
            case SearchForPlayerState.WalkForward:
            {
                //searchState = SearchForPlayerState.TurnAround;
                dir = transform.forward;
                if (rayEnemyVisionInfo.distance < 5)
                {
                    searchState = SearchForPlayerState.TurnAround;
                }
            } break;

            case SearchForPlayerState.TurnAround:
            {
                // rotate in player direction
                //if ()
                Quaternion target = Quaternion.Euler(rotation);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target, Time.deltaTime * rotateSpeed);
                if (target == transform.rotation)
                {
                    //Debug.Log(rotation);
                    if (rotation.y == 270)
                    {
                      //  Debug.Log("hit1");
                        rotation.y = 90;
                    }
                    else if (rotation.y == 90)
                    {
                       // Debug.Log("hit2");
                        rotation.y = 270;
                    }
                    searchState = SearchForPlayerState.WalkForward;
                }
            } break;
        }
        controller.Move(dir * seachForPlayerSpeed * Time.deltaTime);
    }

    private void AttackingPlayer()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case AIState.Walking:
            {
                
                SearchForPlayer();
                
                
            } break;
            
            case AIState.AttackingPlayer:
            {
                AttackingPlayer();
            } break;
            
            
        }
    }
}
