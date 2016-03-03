using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;   
    public int scoreValue = 10;    

    Animator anim;   
    CapsuleCollider capsuleCollider;
    GameObject player;
    bool isDead;
    
    bool beenHit;
    float hitTimer;
    

    
    void Awake ()
    {
        anim = GetComponent <Animator> ();        
        capsuleCollider = GetComponent <CapsuleCollider> ();
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = startingHealth;
        beenHit = false;
    }


    void Update ()
    {
        
        {
            hitTimer += Time.deltaTime;
            if (hitTimer > 0.1f && beenHit)
            {
                anim.SetTrigger("CutShortHit");
                beenHit = false;
            }
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        currentHealth -= amount;
        anim.SetTrigger("BeingHit");
        hitTimer = 0f;
        beenHit = true;
          
        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");
         }

        
}
