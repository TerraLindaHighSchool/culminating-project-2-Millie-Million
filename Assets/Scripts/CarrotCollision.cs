using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCollision : MonoBehaviour
{
    private AudioSource carrotAudio;
    public AudioClip happyEat;
    public AudioClip sadEat;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        carrotAudio = GetComponent<AudioSource>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Doe"))
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

        if (collision.gameObject.CompareTag("Fox"))
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
