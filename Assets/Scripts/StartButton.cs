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

    private void StartGame()
    {
        playerControllerScript.StartGame();
        titleScreen.gameObject.SetActive(false);
        spawnManager.gameObject.SetActive(true);
    }
}
