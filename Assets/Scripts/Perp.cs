using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
