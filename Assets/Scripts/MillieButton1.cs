using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MillieButton1 : MonoBehaviour
{
    private Button button;
    //The Cultural Character
    public GameObject millie;
    //The Law Enforcement Character
    public GameObject dad;
    //The Cadet Character
    public GameObject mom;

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

    //Sets the Cultural Character to active and the other two to inactive.
    private void MillieOn()
    {
        dad.gameObject.SetActive(false);
        mom.gameObject.SetActive(false);
        millie.gameObject.SetActive(true);
    }
}
