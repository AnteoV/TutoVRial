using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzGame : MonoBehaviour

{

    public bool flag;
    public Material safeMat;
    public Material dangerMat;
    public List<GameObject> indicator;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (flag)
        {
            foreach (GameObject go in indicator)
            {
               go.GetComponent<MeshRenderer>().material = dangerMat;
            }
        }
            
    }

    private void OnCollisionExit(Collision collision)
    {
        if (flag)
        {
            foreach (GameObject go in indicator)
            {
                go.GetComponent<MeshRenderer>().material = safeMat;
            }
        }
    }
}
