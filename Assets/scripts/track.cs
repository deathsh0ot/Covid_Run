using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;


public class track : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource audio; 
    public Slider audioVolume;  
    public VideoPlayer video; 
    Slider tracking;
    bool slide = false;
    // Start is called before the first frame update
    void Start()
    {
        tracking = GetComponent<Slider>();
        
    }

    public void OnPointerUp(PointerEventData a){
        float frame = (float) tracking.value * (float) video.frameCount;
        video.frame = (long) frame;

        slide = false;
    }

    public void OnPointerDown(PointerEventData a){
        slide = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(!slide && video.isPlaying){
            tracking.value = (float) video.frame / (float) video.frameCount;
        }
        

        
    }
    public void volume(){
        audio.volume = audioVolume.value;

    }
}
