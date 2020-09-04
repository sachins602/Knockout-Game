using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 0.2f;
    private GameObject player;
    private Rigidbody playerRb;
    private Rigidbody enemyRb;
    private SpawnManager spawnManager;
    private int pointValue = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        player = GameObject.Find("Player");
        playerRb = player.GetComponent<Rigidbody>();
        enemyRb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            Vector3 lookDirection = (playerRb.transform.position - transform.position).normalized;
            //enemyRb.AddForce(lookDirection * enemySpeed, ForceMode.Acceleration);
            if (spawnManager.waveNumber < 6)
            {
                enemyRb.AddForce(lookDirection * enemySpeed, ForceMode.Acceleration);
            }
            
            else if (spawnManager.waveNumber >= 6)
            {
                float newSpeedModifier = 1.5f;
                float newEnemySpeed = enemySpeed * newSpeedModifier;
                enemyRb.AddForce(lookDirection * newEnemySpeed, ForceMode.Acceleration);
            }


        }

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            spawnManager.UpdateScore(pointValue);
        }
    }
}


