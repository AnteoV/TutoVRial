using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayScript : MonoBehaviour
{
    public List<GameObject> screens;
    private int videoPlaying;
    List<VideoPlayer> vp = new List<VideoPlayer>();
    void Start()
    {
        
        foreach(GameObject x in screens)
        {
            vp.Add(x.gameObject.GetComponent<VideoPlayer>());
            x.SetActive(false);
        }
        videoPlaying = -1;
    }
    public void playVideo(int index)
    {
        if (videoPlaying != -1)
        {
            vp[videoPlaying].Pause();
            screens[videoPlaying].SetActive(false);
        }
        if (index != -1)
        {
            screens[index].SetActive(true);
            vp[index].Play();
        }
        videoPlaying = index;
    }
}