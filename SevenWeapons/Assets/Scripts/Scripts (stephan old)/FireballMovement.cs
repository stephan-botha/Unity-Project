using UnityEngine;
using System.Collections;

public class FireballMovement : MonoBehaviour {

    public int damagePerShot = 50;
    public float fireballSpeed = 10f;
    public bool explosion = false;

    PlayerShooting playerShooting;
    GameObject player;

    float timer;
    Vector3 startFireballMarker;
    Vector3 targetFireballTransform;
    float fireballTravelDistance;
    public float scaleFactor;

    AudioSource fireballAudio;

    int pauseBall = 0;
    float pauseTimer = 0f;

    void Awake()
    {
        playerShooting = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerShooting>();
        player = GameObject.FindGameObjectWithTag("Player");
        fireballAudio = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        scaleFactor = this.transform.localScale.x;
        this.transform.localScale += new Vector3(-scaleFactor, -scaleFactor, -scaleFactor);
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1") && pauseBall == 0)
        {
            transform.position = playerShooting.transform.position;
            pauseTimer += Time.deltaTime;
            if (pauseTimer > 5f)
                DestroyFireball();
        }

        if( Input.GetButtonUp( "Fire1" ) && pauseBall == 0 )
        {
            pauseBall = 1;
            timer = 0f;
            this.transform.localScale -= new Vector3(-scaleFactor, -scaleFactor, -scaleFactor);

            if (pauseTimer < 2f)
            {
                int mod = (int)pauseTimer % 2;
                fireballSpeed += (float)(mod / 2f) * fireballSpeed;
            }
            else
                fireballSpeed += fireballSpeed;

            fireballAudio.Play();

            startFireballMarker = transform.position;
            targetFireballTransform = playerShooting.transform.position + playerShooting.transform.forward * playerShooting.range;
            fireballTravelDistance = Vector3.Distance( transform.position, targetFireballTransform );            

        }
        if( pauseBall == 1 && !explosion)
        {
            timer += Time.deltaTime ;

            float distanceMoved = timer * fireballSpeed;
            float fractionMoved = distanceMoved / fireballTravelDistance;
            transform.position = Vector3.Lerp( startFireballMarker, targetFireballTransform, fractionMoved );
            transform.Rotate(0f, -3f, 0f);
            if (timer > 15f)
                DestroyFireball();
        }
    }

    public void DestroyFireball()
    {
        Destroy(gameObject, 0f);
    }
}
