using UnityEngine;
using System.Collections;


public class EnemyMovement : MonoBehaviour
{
    public float aggroRange = 20f;
    public float attackRange = 3f;
    public float patrolIdleTime = 4f;
    public float fleeHealth = 50f;
    
    public Transform[] patrolPoints;

    int currentPatrolPoint;

    Transform player;
    Vector3 fleeTarget;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;
    EnemyAttack enemyAttack;
    Animator anim;

    float patrolIdleTimer = 0f;
    float fleeDistance;
    bool hasFled = false;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttack>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        currentPatrolPoint = 0;
        fleeDistance = 10f;
        fleeTarget.Set (0f,0f,0f);
        nav.enabled = true;
    }

    void Update()
    {
        if (enemyHealth.currentHealth <= 0 || playerHealth.currentHealth <= 0)
        {
            nav.enabled = false;
        }
        else if (enemyHealth.currentHealth <= fleeHealth && !hasFled)
        {
            if (!anim.GetBool( "isFleeing"))
            { 
                fleeTarget = this.transform.position - (this.transform.forward) * fleeDistance;
                anim.SetBool( "isFleeing", true );
                nav.enabled = true;
            }
            nav.SetDestination( fleeTarget );

            if( Vector3.Distance( this.transform.position, fleeTarget ) <= 0.1f )
            {
                hasFled = true;
                anim.SetBool( "isFleeing", false );
            }
        }
        else if (Vector3.Distance(this.transform.position, player.transform.position) <= attackRange)
        {
            anim.SetBool("inAttackRange", true);
            anim.SetBool("isPatrolling", false);
            nav.enabled = false;
        }                   
        else if (Vector3.Distance(this.transform.position, player.transform.position) <= aggroRange)
        {
            anim.SetBool("inAggroRange", true);
            anim.SetBool("inAttackRange", false);
            nav.enabled = true;
            nav.SetDestination(player.position);
        }
        else
        {
            anim.SetBool("inAggroRange", false);
            Patrol();
        }

    }

    void Patrol()
    {
        if (Vector3.Distance(this.transform.position, patrolPoints[currentPatrolPoint].position) <= 0.5f)
        {
            patrolIdleTimer += Time.deltaTime;

            if (patrolIdleTimer < patrolIdleTime)
            {
                nav.enabled = false;
                anim.SetBool("isPatrolling", false);
            }
            else
            {
                currentPatrolPoint = (currentPatrolPoint == patrolPoints.Length - 1) ? 0 : currentPatrolPoint + 1;
                patrolIdleTimer = 0f;
                nav.enabled = true;
            }
        }
        else
        {
            nav.SetDestination(patrolPoints[currentPatrolPoint].position);
            anim.SetBool("isPatrolling", true);
        }

    }
}


