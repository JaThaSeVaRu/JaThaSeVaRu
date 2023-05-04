using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Events : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource JumpSound;
    [SerializeField] private AudioSource PoseSound;
    [SerializeField] private AudioSource SwitchUpSound;
    [SerializeField] private AudioSource SwitchDownSound;

 
    public void JumpAudio()
    {
        JumpSound.Play();
    }
    public void PoseAudio()
    {
        PoseSound.Play();
    }

    public void SwitchUpAudio()
    {
        SwitchUpSound.Play();
    }
    public void SwitchDownAudio()
    {
        SwitchDownSound.Play();
    }

}
