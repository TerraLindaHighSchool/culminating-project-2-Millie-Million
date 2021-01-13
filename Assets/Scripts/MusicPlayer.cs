using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public AudioSource music0;
    public AudioSource music1;
    public AudioSource music2;
    public AudioSource music3;
    public AudioClip level0;
    public AudioClip level1;
    public AudioClip level2;
    public AudioClip level3;
    private bool music0IsPlaying = false;
    private bool music1IsPlaying = false;
    private bool music2IsPlaying = false;
    private bool music3IsPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        music0.Play();
        music0IsPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic()
    {
        if (playerControllerScript.GetLevel() == 0 && ! music0IsPlaying)
        {
            music0.Play();
            music0IsPlaying = true;
            music2.Stop();
            music3.Stop();
            music2IsPlaying = false;
            music3IsPlaying = false;
            music0.Stop();
            music1IsPlaying = false;
        }

        if (playerControllerScript.GetLevel() == 1 && !music1IsPlaying)
        {
            music1.Play();
            music1IsPlaying = true;
            music2.Stop();
            music3.Stop();
            music0.Stop();
            music2IsPlaying = false;
            music3IsPlaying = false;
            music0IsPlaying = false;
        }

        if (playerControllerScript.GetLevel() == 2 && !music2IsPlaying)
        {
            music2.Play();
            music2IsPlaying = true;
            music1.Stop();
            music1IsPlaying = false;
            music3.Stop();
            music3IsPlaying = false;
        }

        if (playerControllerScript.GetLevel() == 3 && ! music3IsPlaying)
        {
            music3.Play();
            music3IsPlaying = true;
            music2.Stop();
            music2IsPlaying = false;
            music1.Stop();
            music1IsPlaying = false;
        }

        if (playerControllerScript.gameOver == true)
        {
            music1.Stop();
            music2.Stop();
            music3.Stop();
            music0.Stop();
        }
    }
}
