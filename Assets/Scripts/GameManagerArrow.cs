using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerArrow : MonoBehaviour
{
    private float time;
    public bool started;
    public GameObject timer;
    public GameObject highScore;
    private TextMeshPro timertext;
    private int score;
    private int prevBest;
    private GameObject[] targets;
    void Start()
    {
        started = false;
        targets = GameObject.FindGameObjectsWithTag("Target");
        prevBest = PlayerPrefs.GetInt("arrowHS", 0);
        highScore.GetComponent<TextMeshPro>().text+=prevBest.ToString();

    }
    void Update()
    {
        if(time > 0 && started)
        {
            time -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            timertext.text=string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        if (time <= 0 && started)
        {
            Debug.Log(score);
            started = false;
            for(int i=0; i< targets.Length; i++)
            {
                if (!targets[i].activeSelf)
                {
                    targets[i].SetActive(true);
                }
            }
            if(score > prevBest)
            {
                prevBest = score;
                PlayerPrefs.SetInt("arrowHS", prevBest);
            }

        }
    }

    public void hit()
    {
        if (started && time > 0)
        {
            score++;
            Debug.Log("pogodak");
        }
    }

    public void startGame()
    {
        started = true;
        score = 0;
        time = 90f;
        timertext = timer.GetComponent<TextMeshPro>();
        timertext.text = "01:30";
        Debug.Log("Poceelo");
    }

    
}
