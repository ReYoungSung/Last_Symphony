using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObj : MonoBehaviour
{
    private AudioManager audioManager;
    
    void Start()
    {
        audioManager = GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioManager.PlayAudioByIndex(0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioManager.PlayAudioByIndex(1);
        }
    }
}
