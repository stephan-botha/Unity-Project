using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireballCollision : MonoBehaviour
{

    public GameObject hitEffect;

    FireballMovement fireball;
    Transform explosionTransform;

    // Use this for initialization


    void Awake()
    {
        fireball = GetComponent<FireballMovement>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (fireball.explosion)
        {
            fireball.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
            fireball.transform.position = explosionTransform.position;
            if (fireball.transform.localScale.x < 0f)
                fireball.DestroyFireball();
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if (!collider.collider.CompareTag("Player"))
        {
            Instantiate(hitEffect, transform.position, transform.rotation);
            fireball.explosion = true;
            explosionTransform = this.transform;
            fireball.transform.localScale += new Vector3(0.35f, 0.35f, 0.35f);
        }
        if (collider.collider.CompareTag("Shootable"))
        {
            EnemyHealth enemyHealth = collider.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(fireball.damagePerShot, collider.transform.position);
            }
        }
    }
}
