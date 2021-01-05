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
            boneAudio.PlayOneShot(happyEat, 1.0f);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            boneAudio.PlayOneShot(sadEat, 1.0f);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
