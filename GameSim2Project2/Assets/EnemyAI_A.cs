using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.IO;
using UnityEngine.AI;

public class EnemyAI_A : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    public bool playerInSightRange;
    public float sightRange;
    public bool playerInAttackRange;
    public float attackRange;
    public Transform player;
    public bool enemyDeadSeq1;
    public bool enemyOnGround;
    public GameObject scoreController;

    public float timeElapsedBetweenEnemyShots;

    public float timePauseBetweenEnemyShots;
    //public GameObject score
    public enum AIState
    {
        Walking,
        LookingForPlayer,
        ChasingPlayer,
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
    public GameObject bullet;
    public float chasingPlayerSpeed;
    public int enemyHealth;
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
        searchState = SearchForPlayerState.WalkForward;
        enemyHealth = 1;
        var color = gameObject.GetComponent<Renderer>();
        color.material.SetColor("_Color", Color.red);
    }

    private void SearchForPlayer()
    {
        
        //enemy vision
        Ray rayEnemyVision = new Ray(transform.position, transform.forward);
        Physics.Raycast(rayEnemyVision, out RaycastHit rayEnemyVisionInfo);
        //Debug.Log(rayEnemyVisionInfo.collider.name);
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        
        Vector3 walk = new Vector3();
        
        switch (searchState)
        {
            case SearchForPlayerState.WalkForward:
            {
                //searchState = SearchForPlayerState.TurnAround;
                walk = transform.forward;
                if (rayEnemyVisionInfo.distance < 5)
                {
                    searchState = SearchForPlayerState.TurnAround;
                }
                Vector3 move = Vector3.forward;
                move.z = (move.z * Time.deltaTime * seachForPlayerSpeed);
                move = transform.TransformDirection(move);
                transform.position += move;
                //controller.Move(walk * seachForPlayerSpeed * Time.deltaTime);
            } break;

            case SearchForPlayerState.TurnAround:
            {
                // rotate in player direction
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
        
        //controller.Move(walk * seachForPlayerSpeed * Time.deltaTime);
    }

    private void EnemyDead()
    {
        var color = gameObject.GetComponent<Renderer>();
        color.material.SetColor("_Color", Color.black);
        if (enemyDeadSeq1)
        {
            scoreController.GetComponent<ScoreManager>().currentScore++;
            FileStream fs = new FileStream("Assets/highScore.txt",FileMode.OpenOrCreate, 
                FileAccess.ReadWrite, 
                FileShare.None);

            StreamReader reader = new StreamReader(fs);
            string scoreReader = reader.ReadLine();
            int scoreInt = int.Parse(scoreReader);
            reader.Close();
        
            Debug.Log(scoreInt);
            Debug.Log("size:" + scoreController.GetComponent<ScoreManager>().currentScore);
            if (scoreInt < scoreController.GetComponent<ScoreManager>().currentScore)
            {
                StreamWriter writer = new StreamWriter("Assets/highScore.txt", false);
                writer.WriteLine(scoreController.GetComponent<ScoreManager>().currentScore);
                writer.Close();
            }

            enemyDeadSeq1 = false;
        }
        
        //StreamWriter writer = new StreamWriter("Assets/highScore.txt", true);
        //writer.Write(current)
    }
    private void AttackingPlayer()
    {
       
    }

    private void ChasingPlayer()
    {
        //Vector3 dir = new Vector3(0, 0, 0);
        Vector3 dir = new Vector3();
        dir = Vector3.forward;
        Vector3 direction = player.transform.position - transform.position; 
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
        //Debug.Log("Chasing");
        dir = transform.TransformDirection(dir);
        controller.Move(dir * chasingPlayerSpeed * Time.deltaTime);

        timeElapsedBetweenEnemyShots += Time.deltaTime;
        
        if (timeElapsedBetweenEnemyShots > timePauseBetweenEnemyShots)
        {
            GameObject bulletShotEnemy = Instantiate(bullet) as GameObject;
            bulletShotEnemy.SetActive(true);
            bulletShotEnemy.transform.position = transform.position;
            bulletShotEnemy.transform.rotation = transform.rotation;
            timeElapsedBetweenEnemyShots = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case AIState.Walking:
            {
                SearchForPlayer();
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
                if (playerInSightRange)
                {
                    enemyState = AIState.ChasingPlayer;
                }
            } break;
            
            case AIState.ChasingPlayer:
            {
                ChasingPlayer();
            } break;
            
            case AIState.AttackingPlayer:
            {
                AttackingPlayer();
            } break;

            case AIState.Dead:
            {
                EnemyDead();
            } break;
            
            
        }
        if (enemyHealth <= 0)
        {
            enemyState = AIState.Dead;
        }
    }
    
}
