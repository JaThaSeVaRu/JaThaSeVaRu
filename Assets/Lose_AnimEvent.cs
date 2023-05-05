using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose_AnimEvent : MonoBehaviour
{
    public AudioSource HeartSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHeartSound()
    {
        HeartSound.Play();
    }
}
