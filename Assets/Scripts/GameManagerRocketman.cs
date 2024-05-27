using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManagerRocketman : MonoBehaviour
{
    private float time;
    private bool started;
    private Transform t;
    private float prevBest;
    public GameObject highScore;
    public GameObject currScore;
    public GameObject UIstart;
    public CharacterController characterController;
    void Start()
    {
        time = 0f;
        started = false;
        t = characterController.transform;
        prevBest = PlayerPrefs.GetFloat("rocketHS", 0.0f);
        Debug.Log(prevBest);
    }

    void Update()
    {
        if (started)
        {
            time += Time.deltaTime;
        }
    }

    public void startGame()
    {
        started = true;
        time = 0f;
    }

    public void endGame()
    {
        started = false;
        if (prevBest == 0.0f || time < prevBest)
        {
            prevBest = time;
            PlayerPrefs.SetFloat("rocketHS", time);
        }
        highScore.GetComponent<TextMeshPro>().text = "Najbolji rezultat: " + string.Format("{0:00}:{1:00}", Mathf.FloorToInt(prevBest/60), Mathf.FloorToInt(prevBest%60)); ;
        currScore.GetComponent<TextMeshPro>().text = "Trenutni rezultat: " + string.Format("{0:00}:{1:00}", Mathf.FloorToInt(time/60), Mathf.FloorToInt(time%60)); ;
    }

    public void restartGame()
    {
        characterController.transform.position = t.position;
        UIstart.SetActive(true);
    }
}
