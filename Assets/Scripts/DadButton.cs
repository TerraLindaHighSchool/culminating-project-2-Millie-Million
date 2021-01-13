using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DadButton : MonoBehaviour
{
    private Button button;
    public GameObject dad;
    public GameObject millie;
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

    private void DadOn()
    {
        dad.gameObject.SetActive(true);
        millie.gameObject.SetActive(false);
        mom.gameObject.SetActive(false);
    }
}
