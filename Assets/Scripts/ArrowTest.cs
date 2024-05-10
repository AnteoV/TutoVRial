using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTest : MonoBehaviour
{
    protected bool alreadyHit;
    // Start is called before the first frame update
    void Start()
    {
        alreadyHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!alreadyHit)
        {
            Debug.Log("Hit");
            alreadyHit = true;
        }
        else {
            Debug.Log("Ne more");
        }
    }
}
