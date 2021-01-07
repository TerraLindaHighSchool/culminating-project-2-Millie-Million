using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10.0f;
    private Vector3 foodSpawnPos;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public GameObject applePrefab;
    public GameObject bonePrefab;
    public GameObject carrotPrefab;
    public GameObject canPrefab;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        foodSpawnPos = transform.position + new Vector3(0, 1.5f, 0);
        FireFood();
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetBool("Jump_b", true);
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void FireFood()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !gameOver)
        {
            Instantiate(applePrefab, foodSpawnPos, applePrefab.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !gameOver)
        {
            Instantiate(carrotPrefab, foodSpawnPos, carrotPrefab.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && !gameOver)
        {
            Instantiate(bonePrefab, foodSpawnPos, bonePrefab.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && !gameOver)
        {
            Instantiate(canPrefab, foodSpawnPos, canPrefab.transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerAnim.SetBool("Jump_b", false);
            if (!gameOver)
            {
                dirtParticle.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Fox") || collision.gameObject.CompareTag("Doe") || collision.gameObject.CompareTag("Stag") || collision.gameObject.CompareTag("Perp"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
