using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Image VolumeOn;
    [SerializeField] Image VolumeOff;

    [SerializeField] AudioSource BGM;

    private bool isMuted;

    private void Start()
    {
        isMuted = false;
        BGM.Play();
        VolumeOn.enabled = true;
        VolumeOff.enabled = false;
    }

    public void MuteUnmute()
    {
        if (isMuted == false)
        {
            VolumeOff.enabled = true;
            VolumeOn.enabled = false;
            BGM.Stop();
            isMuted = true;
        }
        else if (isMuted == true)
        {
            VolumeOff.enabled = false;
            VolumeOn.enabled = true;
            BGM.Play();
            isMuted = false;
        }
    }
}
