using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanCollision : MonoBehaviour
{
    private AudioSource canAudio;
    public AudioClip happyEat;
    public AudioClip sadEat;
    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        canAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Perp"))
        {
            AudioSource.PlayClipAtPoint(happyEat, this.gameObject.transform.position);
            Instantiate(obstaclePrefab, collision.gameObject.transform.position, obstaclePrefab.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
            
        if (collision.gameObject.CompareTag("Doe"))
        {
            AudioSource.PlayClipAtPoint(sadEat, this.gameObject.transform.position);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Stag"))
        {
            AudioSource.PlayClipAtPoint(sadEat, this.gameObject.transform.position);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Fox"))
        {
            AudioSource.PlayClipAtPoint(sadEat, this.gameObject.transform.position);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
