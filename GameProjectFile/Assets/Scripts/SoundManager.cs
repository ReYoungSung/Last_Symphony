using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }


    public void PlayAudioByIndex(int index)
    {
        audioSources[index].volume = 0f;
        audioSources[index].Play();
    }

    public void ManageVolume(int index)
    {
        audioSources[index].volume = Mathf.Lerp(0f, 20f, Time.time);
    }

    public void MuteVolume(int index)
    {
        audioSources[index].volume = Mathf.Lerp(20f, 0f, Time.time);
    }
}
