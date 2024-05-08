using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzGame : MonoBehaviour
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
        if (collision.gameObject.tag == "Buzz")
        {
            Debug.Log("Mrtav");
        }
        else
        {
            Debug.Log("Živ");
        }
    }
}
