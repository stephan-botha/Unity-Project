using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject fireball;
    public float range = 100f;
    public float timeBetweenBullets = 0.5f;     

    float timer;
    

    //ParticleSystem gunParticles;    
    //Light gunLight;
    //float effectsDisplayTime = 0.2f;

    
    

    void Awake ()
    {

        //gunParticles = GetComponent<ParticleSystem> ();        
        //gunLine = GetComponent <LineRenderer> ();       
        // gunLight = GetComponent<Light> ();

        
        
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(Input.GetButtonDown ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Instantiate(fireball, transform.position, transform.rotation);
            timer = 0f;
        }
          

        //if(timer >= timeBetweenBullets * effectsDisplayTime)
        //{
        //    DisableEffects ();
        //}
    }

       

    public void DisableEffects ()
    {
        //gunLine.enabled = false;
        //gunLight.enabled = false;
    }
    
    

   
        //gunLight.enabled = true;

        //gunParticles.Stop ();
        //gunParticles.Play ();
        //gunLine.enabled = true;
        //gunLine.SetPosition (0, transform.position);

        //shootRay.origin = transform.position;
        //shootRay.direction = transform.forward;

        //if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        //{
        //    EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
        //    if(enemyHealth != null)
        //    {
        //        enemyHealth.TakeDamage (damagePerShot, shootHit.point);
        //    }


        //    //gunLine.SetPosition (1, shootHit.point);
        //}
        //else
        //{
        //    gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        //}
    
}
