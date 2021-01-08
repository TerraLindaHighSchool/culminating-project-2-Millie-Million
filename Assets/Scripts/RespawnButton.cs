using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnButton : MonoBehaviour
{
    private Button button;
    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
