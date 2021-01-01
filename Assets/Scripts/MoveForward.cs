﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (gameObject.CompareTag("Stag") && transform.position.x < leftBound || gameObject.CompareTag("Doe") && transform.position.x < leftBound || gameObject.CompareTag("Fox") && transform.position.x < leftBound )
        {
            Destroy(gameObject);
        }
    }
}
 