using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundUpdater : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private SpriteRenderer background;
    public Sprite level1;
    public Sprite level2;
    public Sprite level3;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        background = gameObject.GetComponent<SpriteRenderer>();
        background.sprite = level1;
    }

    // Update is called once per frame
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
