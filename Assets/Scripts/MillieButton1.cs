using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MillieButton1 : MonoBehaviour
{
    private Button button;
    public GameObject millie;
    public GameObject dad;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(MillieOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MillieOn()
    {
        dad.gameObject.SetActive(false);
        millie.gameObject.SetActive(true);
    }
}
