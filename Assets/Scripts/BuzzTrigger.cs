using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BuzzHand")
        {
            other.gameObject.GetComponent<BuzzGame>().flag = !other.gameObject.GetComponent<BuzzGame>().flag;
        }
    }
}
