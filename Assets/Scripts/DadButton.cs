using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DadButton : MonoBehaviour
{
    private Button button;
    //The Law Enforcement Character
    public GameObject dad;
    //The Cultural Character
    public GameObject millie;
    //the Cadet Character
    public GameObject mom;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(DadOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Sets the Law Enforcement Character to active and the other two to inactive.
    private void DadOn()
    {
        dad.gameObject.SetActive(true);
        millie.gameObject.SetActive(false);
        mom.gameObject.SetActive(false);
    }
}
