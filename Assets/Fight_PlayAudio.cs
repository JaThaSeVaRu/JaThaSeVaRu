using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_PlayAudio : MonoBehaviour
{
    public AudioSource TransitionSound; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTransitionAudio()
    {
        TransitionSound.Play();
    }
}
