using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCollision : MonoBehaviour
{
    private AudioSource boneAudio;
    //cronch sound
    public AudioClip happyEat;
    //bzzt sound
    public AudioClip sadEat;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        boneAudio = GetComponent<AudioSource>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Checks what the bone has collided with, removes the bone and whatever it collided with, and plays the appropriate sound.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fox"))
        {
            AudioSource.PlayClipAtPoint(happyEat, this.gameObject.transform.position);
            playerControllerScript.UpdateScore(5);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("Stag"))
        {
            AudioSource.PlayClipAtPoint(sadEat, this.gameObject.transform.position);
            playerControllerScript.UpdateScore(-5);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Doe"))
        {
            AudioSource.PlayClipAtPoint(sadEat, this.gameObject.transform.position);
            playerControllerScript.UpdateScore(-5);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Perp"))
        {
            AudioSource.PlayClipAtPoint(sadEat, this.gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}
