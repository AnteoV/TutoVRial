using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTest : MonoBehaviour
{
    protected bool alreadyHit;
    public GameManagerArrow gm;
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
            alreadyHit = true;
            gm.hit();
            Invoke("despawnTarget", 2.5f);
        }
        else {
            Debug.Log("Ne");
        }
    }

    private void despawnTarget()
    {
        this.gameObject.SetActive(false);
    }
}
