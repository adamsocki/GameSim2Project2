using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMController_EnemyAI : MonoBehaviour
{
    public int health;
    public char enemyType;
    public enum EnemyState
    {
        Idle,
        Patrolling,
        Shooting,
        Dead
    }

    public EnemyState state;

    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.Idle;
        if (enemyType == 'A')
        {
            health = 100;
        }
    }

    public void EnemyPlayer()
    {
        switch (state)
        {
            case EnemyState.Idle:
            {
                
                
            } break;

            case EnemyState.Patrolling:
            {
                
            } break;

            case EnemyState.Shooting:
            {
                
            } break;

            case EnemyState.Dead:
            {
                
            } break;
        }

        if (health <= 0)
        {
            state = EnemyState.Dead;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
