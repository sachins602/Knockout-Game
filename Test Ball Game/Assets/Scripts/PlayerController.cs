using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody playerRb;
    public ParticleSystem sparkParticle;
    public ParticleSystem smokeTrailParticle;
 
    //public Joystick joystick;
    public float playerSpeed;
    public float maxMovement;

    private AudioSource playerAudio;
    
    public AudioClip bumpAudio;
    public AudioClip powerUpAudio;


    private float powerUpStrength = 18.0f;
    private float defaultPlayerStrength = 6.0f;

    private Touch touch;
    //private float speedModifier;


     public GameObject powerUpIndicator;

    public bool hasPowerUp = false;
    public SpawnManager spawnManager;
    private Vector3 powerUpIndicatorPostion = new Vector3(3.34f, -2.2f, 2.9f);

    // Start is called before the first frame update
    void Start()
    {
        //speedModifier = 0.01f;
        playerRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerAudio = GetComponent<AudioSource>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    void FixedUpdate()
    {
        MovePlayer();
    }
    // Update is called once per frame
    void Update()
    {
       

        powerUpIndicator.transform.position = transform.position + powerUpIndicatorPostion;
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            
            spawnManager.GameOver();
           Time.timeScale = 0;
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            playerAudio.PlayOneShot(powerUpAudio, 1.0f);
            Destroy(other.gameObject);
            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
       powerUpIndicator.gameObject.SetActive(false);
        hasPowerUp = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromThePlayer = collision.gameObject.transform.position - transform.position;
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            Instantiate(sparkParticle, position, rotation);
            //Destroy(particle);


           // sparkParticle.Play();
            playerAudio.PlayOneShot(bumpAudio, 1.0f);
            enemyRb.AddForce(awayFromThePlayer * powerUpStrength, ForceMode.Impulse);
            //Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
        }
        else if (collision.gameObject.CompareTag("Enemy") && !hasPowerUp)
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            Instantiate(sparkParticle, position, rotation);
            //Destroy(particle);


            //sparkParticle.Play();
            playerAudio.PlayOneShot(bumpAudio, 1.0f);
            enemyRb.AddForce(awayFromThePlayer * defaultPlayerStrength, ForceMode.Impulse);
            //Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
        }
    }

    public void MovePlayer()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                //transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier,
                //transform.position.y, transform.position.z + touch.deltaPosition.y * speedModifier);


                float x = Input.touches[0].deltaPosition.x;
                float y = Input.touches[0].deltaPosition.y;

                Vector3 movement = new Vector3(x, 0.0f, y);
                if (movement.sqrMagnitude > maxMovement * maxMovement)
                {
                    movement = movement.normalized * maxMovement;
                }

                playerRb.AddForce(movement * playerSpeed * Time.deltaTime);


                //playerRb.transform.Translate(movement* playerSpeed * Time.deltaTime);

                //playerRb.AddForce(movement * playerSpeed * Time.deltaTime, ForceMode.VelocityChange);


               /* Vector3 movement = new Vector3(transform.position.x + touch.deltaPosition.x,
                0.0f, transform.position.z + touch.deltaPosition.y);
                playerRb.AddForce(movement * playerSpeed, ForceMode.Force); */
            }
        }






        /*float verticalInput = joystick.Vertical;
        float horizontalInput = joystick.Horizontal;
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        playerRb.AddForce(movement * playerSpeed);*/
    }
}
