using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    public void PlayAudioByIndex(int index){
        audioSources[index].Play();
    }
}
