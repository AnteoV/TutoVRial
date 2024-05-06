using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayScript : MonoBehaviour
{
    public List<GameObject> screens;
    private int videoPlaying;
    List<VideoPlayer> vp = new List<VideoPlayer>();
    // Start is called before the first frame update
    void Start()
    {
        
        foreach(GameObject x in screens)
        {
            vp.Add(x.gameObject.GetComponent<VideoPlayer>());
            x.SetActive(false);
        }
        videoPlaying = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playVideo(int index)
    {
        if (videoPlaying != -1)
        {
            screens[videoPlaying].SetActive(false);
            vp[videoPlaying].Pause();
        }
        if (index != -1)
        {
            screens[index].SetActive(true);
            vp[index].Play();
        }
        videoPlaying = index;
    }
}
