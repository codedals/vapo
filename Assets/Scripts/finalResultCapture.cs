using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleCloudStreamingSpeechToText;
using UnityEngine.Video;

public class finalResultCapture : MonoBehaviour
{
    private GameObject im;
    private StreamingRecognizer streamer;
    private VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        im = GameObject.Find("InputManager");
        videoPlayer = GameObject.Find("VideoPlayer").GetComponent <VideoPlayer  > (); 
        StreamingRecognizer streamer = im.GetComponent <StreamingRecognizer> ();
        streamer.onFinalResult.AddListener(GetTranscript);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GetTranscript(string results){
        Debug.Log("something happened: " + results);
        if(results.Contains("stop player")){
            videoPlayer.Pause();
        }
        else if(results.Contains("start player")){
            videoPlayer.Play();
        }   
    }
}
