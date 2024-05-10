using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int sceneNum;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Change()
    {
        SceneManager.LoadScene(sceneNum);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneNum);
        }
    }
}
