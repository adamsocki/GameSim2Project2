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

    public AIState enemyState;
    //AIState enemyState = AIState.Walking;
    // Start is called before the first frame update
    void Start()
    {
        enemyState = AIState.Walking;
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case AIState.Walking:
            {
                
            } break;
            
            case AIState.AttackingPlayer:
            {
                
            } break;
        }
    }
}
