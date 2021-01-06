using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCollision : MonoBehaviour
{
    private AudioSource boneAudio;
    public AudioClip happyEat;
    public AudioClip sadEat;

    // Start is called before the first frame update
    void Start()
    {
        boneAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fox"))
        {
            AudioSource.PlayClipAtPoint(happyEat, this.gameObject.transform.position);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("Stag"))
        {
            AudioSource.PlayClipAtPoint(sadEat, this.gameObject.transform.position);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Doe"))
        {
            AudioSource.PlayClipAtPoint(sadEat, this.gameObject.transform.position);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            AudioSource.PlayClipAtPoint(sadEat, this.gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}
