using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Start_Image : MonoBehaviour
{
    [SerializeField]
    private Image start_back;
    [SerializeField]
    private GameObject video_move;

    private bool loadFinish = false;


    // Start is called before the first frame update
    void Start()
    {
        start_back.gameObject.SetActive(true);

        var videoPlayer = video_move.GetComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.url = "Assets/Sato/Materials/move.mp4";
        videoPlayer.prepareCompleted += OnCompletePrepare;
        videoPlayer.Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        start_back.gameObject.SetActive(!loadFinish);
    }


    private void OnCompletePrepare(VideoPlayer vp)
    {
        // 読込が完了したら再生.
        vp.Play();
        loadFinish = true;
        
    }

    
}
