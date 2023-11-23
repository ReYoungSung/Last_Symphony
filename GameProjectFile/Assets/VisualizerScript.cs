using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizerScript : MonoBehaviour
{
    public float minHeight = 15.0f;
    public float maxHeight = 425.0f;
    public float updateSenstivity = 0.5f;

    public Color visualizerColor = Color.gray;
    [Space(15)]
    public AudioClip audioClip;
    public bool loop = true;
    [Space(15), Range(64, 8192)]
    public int visualizerSimples = 64;
    
    VisualizerObjectsScript[] visualizerObjects;
    AudioSource m_audioSource;

    // Start is called before the first frame update
    void Start()
    {
        visualizerObjects = GetComponentsInChildren<VisualizerObjectsScript>();

        if(!audioClip){ // audio 변수가 선언되지 않은 경우
            return;
        }
        
        m_audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
        m_audioSource.loop = loop;
        m_audioSource.clip = audioClip;
    }

    // Update is called once per frames
    void Update()
    {
        float[] spectrumData = m_audioSource.GetSpectrumData(visualizerSimples, 0, FFTWindow.Rectangular);

        for(int i=0; i<visualizerObjects.Length; i++){
            Vector2 newSize = visualizerObjects[i].GetComponent<RectTransform>().rect.size;
            
            newSize.y = Mathf.Clamp(Mathf.Lerp(newSize.y, minHeight + (spectrumData[i] * (maxHeight - minHeight)*5.0f), updateSenstivity), minHeight, maxHeight);  //height
            visualizerObjects[i].GetComponent<RectTransform>().sizeDelta = newSize;

            visualizerObjects[i].GetComponent<Image> ().color = visualizerColor;
        }
    }

    public void PlayMusic()
    {
        m_audioSource.Play();
    }

    public void MuteMusic()
    {
        m_audioSource.volume = 0f;
    }
}
