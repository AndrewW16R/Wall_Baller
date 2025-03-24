using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.SetDirectAudioVolume(0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        videoPlayer.SetDirectAudioVolume(0, 0);
    }
}
