using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 600.0f;
    private Vector3 foodSpawnPos;
    public bool isOnGround = true;
    public bool gameOver = false;
    public static bool startGame = false;
    public GameObject applePrefab;
    public GameObject bonePrefab;
    public GameObject carrotPrefab;
    public GameObject canPrefab;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip powerUpSound;
    private AudioSource playerAudio;
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreText;
    private int score;
    private static int level;
    private GameObject playerControllerScript;
    public Camera MainCamera;
    private MusicPlayer musicPlayer;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    private float powerupStrength = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        musicPlayer = MainCamera.GetComponent<MusicPlayer>();
        startGame = false;
        dirtParticle.gameObject.SetActive(false);
        playerAnim.SetFloat("Speed_f", 0.0f);
        level = 0;
        Level();
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        startGame = true;
        score = 0;
        scoreText.text = "Score: " + score;
        UpdateScore(0);
        level = 1;
        Level();
    }

    public bool GetStartGame()
    {
        return startGame;
    }

    // Update is called once per frame
    void Update()
    {
        Level();

        if (startGame == true)
        {
            dirtParticle.gameObject.SetActive(true);
            playerAnim.SetFloat("Speed_f", 0.6f);
            foodSpawnPos = transform.position + new Vector3(0, 1.5f, 0);
            FireFood();
            powerupIndicator.transform.position = transform.position + new Vector3(0.5f, 3.2f, 0);

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver && !hasPowerup)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetBool("Jump_b", true);
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }
            else if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver && hasPowerup)
            {
                playerRb.AddForce(Vector3.up * jumpForce * powerupStrength, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetBool("Jump_b", true);
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }
        }
    }

    private void FireFood()
    {
        if (startGame == true)
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (startGame == true)
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
                startGame = false;
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                explosionParticle.Play();
                dirtParticle.Stop();
                playerAudio.PlayOneShot(crashSound, 1.0f);
                transform.position = new Vector3(0, 0, 0);
                gameOverScreen.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
            playerAudio.PlayOneShot(powerUpSound, 1.0f);
        }
    }

    private void Level()
    {
        if (score < 25 && !startGame)
        {
            level = 0;
            musicPlayer.PlayMusic();
        }

        if (score < 25 && startGame)
        {
            level = 1;
            musicPlayer.PlayMusic();
        }

        if (score >= 25 && score < 60)
        {
            level = 2;
            musicPlayer.PlayMusic();
        }

        if (score >= 60)
        {
            level = 3;
            musicPlayer.PlayMusic();
        }
    }

    public int GetLevel()
    {
        return level;
    }
}
