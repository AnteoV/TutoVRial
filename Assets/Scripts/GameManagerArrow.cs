using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerArrow : MonoBehaviour
{
    public float time;
    public bool started;
    public GameObject timer;
    private TextMeshPro timertext;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        started = false;
    }

    // Update is called once per frame
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
        timertext = timer.GetComponent<TextMeshPro>();
        timertext.text = "01:30";
        Debug.Log("Poceelo");
    }

    
}
