using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundUpdater : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private SpriteRenderer background;
    // The afternoon forest scene
    public Sprite level1;
    // The evening forest scene
    public Sprite level2;
    //The night forest scene
    public Sprite level3;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        background = gameObject.GetComponent<SpriteRenderer>();
        background.sprite = level1;
    }

    // Update is called once per frame (Changes the background to correspond with the level)
    void Update()
    {
        if (playerControllerScript.GetLevel() == 1)
        {
            background.sprite = level1;
        }

        if (playerControllerScript.GetLevel() == 2)
        {
            background.sprite = level2;
        }

        if (playerControllerScript.GetLevel() == 3)
        {
            background.sprite = level3;
        }
    }
}
