using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perp : MonoBehaviour
{
    private Animator perpAnim;

    // Start is called before the first frame update
    void Start()
    {
        perpAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Nothing
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            perpAnim.SetInteger("Speed_f", 0);
        }
    }
}
