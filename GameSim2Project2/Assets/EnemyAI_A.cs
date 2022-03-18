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

    private CharacterController controller;
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
        Ray rayEnemyVision = new Ray(transform.position, Vector3.right);
        Physics.Raycast(rayEnemyVision, out RaycastHit rayEnemyVisionInfo);
        Debug.Log(rayEnemyVisionInfo.collider);
        Debug.DrawRay(transform.position, Vector3.right, Color.green);
        
        // enemy walk
        Vector3 dir = new Vector3(0,0,0);
        switch (searchState)
        {
            case SearchForPlayerState.WalkForward:
            {
                dir = Vector3.right;
                if (rayEnemyVisionInfo.distance < 5)
                {
                    searchState = SearchForPlayerState.TurnAround;
                }
            } break;

            case SearchForPlayerState.TurnAround:
            {
                // rotate in player direction
                //if ()
                
            } break;
        }
        controller.Move(dir * seachForPlayerSpeed * Time.deltaTime);
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
                
            } break;
            
            
        }
    }
}
