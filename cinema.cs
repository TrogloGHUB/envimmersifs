using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class cinema : MonoBehaviour
{
    public GameObject CubeVideo;
    private VideoPlayer Video;

    private void Start()
    {
        Video = CubeVideo.GetComponent<VideoPlayer>();

    }

    public void joueVideo()
    {
        Video.Play();
    }
}
