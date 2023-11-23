using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    private HandMotionManager handMotionManager;

    [SerializeField] private Slider slider;
    private float sliderTime;

    // Start is called before the first frame update
    void Awake()
    {
        handMotionManager = GameObject.Find("DetectManager").GetComponent<HandMotionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderTime = handMotionManager.SliderTimer; 
        slider.value = handMotionManager.MotionGauge/sliderTime; 
    }
}
