using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 2f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    public bool playerInRange;
    float timer;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        timer = 0f;
    }


    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        playerInRange = true;
    //        anim.SetBool("inAttackRange", true);
    //    }
    //}


    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        playerInRange = false;
    //        anim.SetBool("inAttackRange", false);
    //    }
    //}


    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= timeBetweenAttacks && anim.GetBool("inAttackRange") && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            anim.SetTrigger("isAttacking");


        }
    }

    void DamagePlayer()
    {
        playerHealth.TakeDamage(attackDamage);
    }

}
