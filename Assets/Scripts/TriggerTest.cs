using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    public GameObject next;
    public GameManagerRocketman gm;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name != "CP1")
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject.GetComponent<MeshRenderer>());
            if (gameObject.name != "FIN")
            {
                next.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                gm.endGame();
            }
            
        }
    }
}
