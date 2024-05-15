using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public List<GameObject> checkpoints;
    public CharacterController character;
    Transform t;
    
    void Start()
    {
        t = character.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for(int i=1; i<checkpoints.Count; i++)
            {
                if (checkpoints[i].activeSelf == true)
                {
                    t = checkpoints[i-1].transform;
                }
            }
            character.transform.position = t.position;
        }
    }
}
