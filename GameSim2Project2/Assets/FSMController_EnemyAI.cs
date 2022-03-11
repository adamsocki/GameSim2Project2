using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMController_EnemyAI : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Patroling,
        Walking,
        Shooting,
        Dead
    }

    public EnemyState state;

    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.Idle;
    }

    public void EnemyPlayer()
    {
        switch (state)
        {
            case EnemyState.Idle:
            {
                
            } break;

            case EnemyState.Patroling:
            {
                
            } break;

            case EnemyState.Shooting:
            {
                
            } break;

            case EnemyState.Dead:
            {
                
            } break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
