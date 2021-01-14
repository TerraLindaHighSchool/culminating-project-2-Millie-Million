using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private float speed = 50;
    private PlayerController playerControllerScript;
    //Right boundary for apples, carrots, bones, and cans
    private float rightBound = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame (move right after thrown and destroy after reaching the right boundary)
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (transform.position.x > rightBound && gameObject.CompareTag("Food"))
        {
            Destroy(gameObject);
        }
    }
}
