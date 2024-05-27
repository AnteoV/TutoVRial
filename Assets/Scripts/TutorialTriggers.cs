using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggers : MonoBehaviour
{
    public bool isObjectCheck;
    public GameObject UI_Curr;
    public GameObject UI_Prev;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isObjectCheck || other.tag == "CubeOrBall" && isObjectCheck)
        {
            UI_Curr.SetActive(false);
            UI_Prev.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
