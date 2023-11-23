using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlOBJ : MonoBehaviour
{
    private SoundManager soundManager;

    [SerializeField] private GameObject celloParticle;
    [SerializeField] private GameObject chime1Particle;
    [SerializeField] private GameObject timpanyParticle;
    [SerializeField] private GameObject violinParticle;
    [SerializeField] private GameObject chime2Particle;
    [SerializeField] private GameObject chime3Particle;
    [SerializeField] private GameObject symbalsParticle;

    public GameObject pianoVisualizer;

    void Start()
    {
        soundManager = GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            soundManager.PlayAudioByIndex(3);
            soundManager.PlayAudioByIndex(1);
            soundManager.PlayAudioByIndex(2);
            
            soundManager.PlayAudioByIndex(4);
            soundManager.PlayAudioByIndex(5);
            soundManager.PlayAudioByIndex(6);
            soundManager.PlayAudioByIndex(7);
            soundManager.PlayAudioByIndex(0);
            soundManager.ManageVolume(0);    // 0을 건들이기
            pianoVisualizer.SetActive(true);
             
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) // 첼로
        {
            soundManager.ManageVolume(1);  
            celloParticle.SetActive(true);
            Debug.Log("abc");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))  //팀파니
        {
            soundManager.ManageVolume(2);
            timpanyParticle.SetActive(true);
            
        }
 
        if (Input.GetKeyDown(KeyCode.RightArrow)) // 바이올린
        {
            soundManager.ManageVolume(3);
            violinParticle.SetActive(true);
        }

// 효과음
        if (Input.GetKeyDown(KeyCode.Alpha1))   // 차임벨1
        {
            soundManager.ManageVolume(4);
            chime1Particle.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))  // 차임벨2
        {
            soundManager.ManageVolume(5);
            chime2Particle.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) // 차임벨3
        {
            soundManager.ManageVolume(6);
            chime3Particle.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) // 심벌즈
        {
            soundManager.ManageVolume(7);
            symbalsParticle.SetActive(true);
        }
    }
}
