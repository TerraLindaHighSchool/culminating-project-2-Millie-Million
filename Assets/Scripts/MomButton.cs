using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MomButton : MonoBehaviour
{
    private Button button;
    //The Cultural Character
    public GameObject millie;
    //The Law Enforcement Character
    public GameObject dad;
    //the Cadet Character
    public GameObject mom;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(MomOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Sets the Cadet Character to active and the other two to inactive.
    private void MomOn()
    {
        dad.gameObject.SetActive(false);
        millie.gameObject.SetActive(false);
        mom.gameObject.SetActive(true);
    }
}
