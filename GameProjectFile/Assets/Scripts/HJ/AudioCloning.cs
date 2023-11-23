using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCloning : MonoBehaviour
{
    public GameObject drumVisualizerPrefab;
    public float cooldownTime = 2f;
    public float minAmplitude = 0f;
    public GameObject soundManager;

    private AudioSource audioSource;
    private float lastCloneTime;

    private void Start()
    {
        audioSource = soundManager.GetComponents<AudioSource>()[2];
        lastCloneTime = -cooldownTime;
    }

    private void Update()
    {
        float[] spectrumData = new float[256];
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        
        for (int i = 0; i < spectrumData.Length; i++)
        {
            if (spectrumData[i] > minAmplitude)
            {
                GameObject drumVisualizer = Instantiate(drumVisualizerPrefab, transform.position, Quaternion.identity, transform.parent);
                lastCloneTime = Time.time;
            }
        }
    }
}
