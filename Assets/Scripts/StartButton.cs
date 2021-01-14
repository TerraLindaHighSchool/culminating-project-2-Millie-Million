using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button button;
    public GameObject titleScreen;
    private PlayerController playerControllerScript;
    public GameObject spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartGame);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When this button is clicked, it calls the PlayerController StartGame() function, deactivates the title screen, and activates to spawn manager to start spawning obstacles
    private void StartGame()
    {
        playerControllerScript.StartGame();
        titleScreen.gameObject.SetActive(false);
        spawnManager.gameObject.SetActive(true);
    }
}
