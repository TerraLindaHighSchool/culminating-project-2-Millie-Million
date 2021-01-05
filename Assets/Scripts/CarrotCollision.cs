using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCollision : MonoBehaviour
{
    private AudioSource carrotAudio;
    public AudioClip happyEat;
    public AudioClip sadEat;

    // Start is called before the first frame update
    void Start()
    {
        carrotAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Doe"))
        {
            carrotAudio.PlayOneShot(happyEat, 1.0f);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            carrotAudio.PlayOneShot(sadEat, 1.0f);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
