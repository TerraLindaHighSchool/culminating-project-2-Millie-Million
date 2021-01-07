using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perp : MonoBehaviour
{
    private Animator perpAnim;
    public float speed = 30;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        perpAnim = GetComponent<Animator>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            perpAnim.SetFloat("Speed_f", 0.0f);
        }
    }
}
