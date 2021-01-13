using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MomButton : MonoBehaviour
{
    private Button button;
    public GameObject millie;
    public GameObject dad;
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

    private void MomOn()
    {
        dad.gameObject.SetActive(false);
        millie.gameObject.SetActive(false);
        mom.gameObject.SetActive(true);
    }
}
