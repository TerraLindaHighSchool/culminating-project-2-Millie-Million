using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs1;
    public GameObject[] obstaclePrefabs2;
    public GameObject[] obstaclePrefabs3;
    private Vector3 spawnPos = new Vector3(25, 0.72f, 0);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void OnEnable()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomObstacle()
    {
        int obstacleIndex1 = Random.Range(0, obstaclePrefabs1.Length);
        int obstacleIndex2 = Random.Range(0, obstaclePrefabs2.Length);
        int obstacleIndex3 = Random.Range(0, obstaclePrefabs3.Length);

        if (playerControllerScript.GetStartGame())
        {
            if (!playerControllerScript.gameOver)
            {
                if (playerControllerScript.GetLevel() == 1)
                {
                    Instantiate(obstaclePrefabs1[obstacleIndex1], spawnPos, obstaclePrefabs1[obstacleIndex1].transform.rotation);
                }

                if (playerControllerScript.GetLevel() == 2)
                {
                    Instantiate(obstaclePrefabs2[obstacleIndex2], spawnPos, obstaclePrefabs2[obstacleIndex2].transform.rotation);
                }

                if (playerControllerScript.GetLevel() == 3)
                {
                    Instantiate(obstaclePrefabs3[obstacleIndex3], spawnPos, obstaclePrefabs2[obstacleIndex2].transform.rotation);
                }
            }
        }
    }
}
