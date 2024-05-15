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
    public GameObject currScore;
    private TextMeshPro timertext;
    private int score;
    private int prevBest;
    private GameObject[] targets;
    void Start()
    {
        started = false;
        targets = GameObject.FindGameObjectsWithTag("Target");
        prevBest = PlayerPrefs.GetInt("arrowHS", 0);
        highScore.GetComponent<TextMeshPro>().text="Najbolji rezultat: " + prevBest.ToString();

    }
    void Update()
    {
        if(time > 0 && started)
        {
            time -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            timertext.text= string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        if (time <= 0 && started)
        {
            Debug.Log(score);
            timertext.text = "00:00";
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
                highScore.GetComponent<TextMeshPro>().text = "Najbolji rezultat: " + prevBest.ToString();
            }

        }
    }

    public void hit()
    {
        if (started && time > 0)
        {
            score++;
            currScore.GetComponent<TextMeshPro>().text = "Trenutni rezultat: " + score;
            Debug.Log("pogodak");
        }
    }

    public void startGame()
    {
        started = true;
        score = 0;
        time = 90f;
        timertext = timer.GetComponent<TextMeshPro>();
        currScore.GetComponent<TextMeshPro>().text = "Trenutni rezultat: " + score;
        timertext.text = "01:30";
    }

    
}
