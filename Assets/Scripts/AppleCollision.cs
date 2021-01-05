using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollision : MonoBehaviour
{
    private AudioSource appleAudio;
    public AudioClip happyEat;
    public AudioClip sadEat;

    // Start is called before the first frame update
    void Start()
    {
        appleAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stag"))
        {
            appleAudio.PlayOneShot(happyEat, 1.0f);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            appleAudio.PlayOneShot(sadEat, 1.0f);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
