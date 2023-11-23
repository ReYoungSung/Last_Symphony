using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity;

public class HandMotionManager : MonoBehaviour
{
    public GameObject Mission;
    public GameObject Clear;

    private SoundManager soundManager;
    
    private bool activePiano = false;
    private bool FirstTimeToPiano = false;
    private bool activeCello = false;
    private bool FirstTimeToCello = false;
    private bool activeChimeBell1 = false;
    private bool FirstTimeToChimeBell1 = false;
    private bool activeDrum = false;
    private bool FirstTimeToDrum = false;
    private bool activeViolin = false;
    private bool FirstTimeToViolin = false;
    private bool activeChimeBell2 = false;
    private bool FirstTimeToChimeBell2 = false;
    private bool activeCymbals = false;
    private bool FirstTimeToCymbals = false;

    private bool gameStart = false;

    public float MotionGauge = 0f;

    private HandGestureTracking handGestureTracking; 
    private bool CollectGesture = false;

    private UI_Manager uI_Manager;

    private ExtendedFingerDetector lExtendedFingerDetector;
    private PalmDirectionDetector lPalmDirectionDetector;
    private ExtendedFingerDetector rExtendedFingerDetector;
    private PalmDirectionDetector rPalmDirectionDetector;
    private PinchDetector lPinchDetector;
    private PinchDetector rPinchDetector;

    private float time_current = 0;

    [SerializeField] private GameObject particle1;
    [SerializeField] private GameObject particle2;
    [SerializeField] private GameObject particle3;
    [SerializeField] private GameObject particle4;
    [SerializeField] private GameObject particle5;
    [SerializeField] private GameObject particle6;

    public float SliderTimer = 10f;

    // Start is called before the first frame update
    void Awake()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>(); 

        lExtendedFingerDetector = GameObject.Find("LExtendedFingerDetector").GetComponent<ExtendedFingerDetector>(); 
        lPalmDirectionDetector = GameObject.Find("LPalmDirectionDetector").GetComponent<PalmDirectionDetector>(); 
        lPinchDetector = GameObject.Find("LPinchDetector").GetComponent<PinchDetector>(); 

        rExtendedFingerDetector = GameObject.Find("RExtendedFingerDetector").GetComponent<ExtendedFingerDetector>(); 
        rPalmDirectionDetector = GameObject.Find("RPalmDirectionDetector").GetComponent<PalmDirectionDetector>(); 
        rPinchDetector = GameObject.Find("PinchDetector").GetComponent<PinchDetector>(); 

        handGestureTracking = GameObject.Find("PinchDetector").GetComponent<HandGestureTracking>(); 

        uI_Manager = GameObject.Find("Canvas_Display1").GetComponent<UI_Manager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStart == true)
        {
            time_current += Time.deltaTime;
        }
        
        //??? ??? ???? ????? ??? ?????????? ????
        if (time_current > 0 && time_current < 9)
            handGestureTracking.InitReset();
        else if (time_current > 14 && time_current < 39)
            handGestureTracking.InitReset();
        else if (time_current > 43 && time_current < 52)
            handGestureTracking.InitReset();

        //?©£? ???? ???? ????? ??? ??
        if (time_current <= 0) //????
        {
            if (uI_Manager.IsUIActive(0) == false && time_current <= 0)
                uI_Manager.SetActiveUI(0, true);

            if (uI_Manager.IsFrameUIActive(0) == false && time_current <= 0)
                uI_Manager.StartBlinking(0);

            Invoke("activatingPiano", 0f);
        }
        else if (time_current < 14 && time_current >= 10) //???
        {
            if (uI_Manager.IsUIActive(1) == false && time_current <= 13)
                uI_Manager.SetActiveUI(1, true);

            if (uI_Manager.IsFrameUIActive(1) == false && time_current <= 13)
                uI_Manager.StartBlinking(1);

            Invoke("activatingCello", 14f - time_current);
        }
        else if (time_current < 34 && time_current >= 17) //?????1
        {
            if (uI_Manager.IsUIActive(2) == false && time_current <= 33)
                uI_Manager.SetActiveUI(2, true); 

            if (uI_Manager.IsUIActive(6) == false && time_current <= 33)
                uI_Manager.SetActiveUI(6, true); 

            if (uI_Manager.IsFrameUIActive(2) == false && time_current <= 33)
                uI_Manager.StartBlinking(2); 

            SliderTimer = 12f; 

            BasicMotion();
            Invoke("activatingChamibell1", 34f - time_current);
        }
        else if (time_current < 43 && time_current >= 39) //?????
        {
            if (uI_Manager.IsUIActive(3) == false && time_current <= 42)
                uI_Manager.SetActiveUI(3, true);

            if (uI_Manager.IsFrameUIActive(3) == false && time_current <= 42)
                uI_Manager.StartBlinking(3);

            Invoke("activatingTimpani", 43f - time_current);
        }
        else if (time_current < 50 && time_current >= 45) //?????2
        {
            if (uI_Manager.IsUIActive(2) == false && time_current <= 49)
                uI_Manager.SetActiveUI(2, true);

            if (uI_Manager.IsUIActive(6) == false && time_current <= 49)
                uI_Manager.SetActiveUI(6, true);

            if (uI_Manager.IsFrameUIActive(4) == false && time_current <= 49)
                uI_Manager.StartBlinking(4);

            SliderTimer = 2f;

            BasicMotion();
            Invoke("activatingChamibell2", 50f - time_current);
        }
        else if (time_current < 56 && time_current >= 52) //????©ª?
        {
            if (uI_Manager.IsUIActive(4) == false && time_current <= 55)
                uI_Manager.SetActiveUI(4, true); 

            if (uI_Manager.IsFrameUIActive(5) == false && time_current <= 55)
                uI_Manager.StartBlinking(5); 

            Invoke("activatingViolin", 56f - time_current);
        }
        else if (time_current < 63 && time_current >= 58) //?????
        {
            if (uI_Manager.IsUIActive(5) == false && time_current <= 62)
                uI_Manager.SetActiveUI(5, true); 

            if (uI_Manager.IsUIActive(6) == false && time_current <= 62)
                uI_Manager.SetActiveUI(6, true); 

            if (uI_Manager.IsFrameUIActive(6) == false && time_current <= 62)
                uI_Manager.StartBlinking(6); 

            SliderTimer = 3f;

            BasicMotion();
            Invoke("activatingCymbals", 63f - time_current);
        }
    }

    private void BasicMotion()  //????? ??? ?????? ????? ????? ??? ?????? ???????? ??????.
    {
        if (rExtendedFingerDetector.ThumbExtended == true
            && rExtendedFingerDetector.IndexExtended == true
            && rExtendedFingerDetector.MiddleExtended == true
            && rExtendedFingerDetector.RingExtended == true
            && rExtendedFingerDetector.PinkyExtended == true

            && lExtendedFingerDetector.ThumbExtended == true
            && lExtendedFingerDetector.IndexExtended == true
            && lExtendedFingerDetector.MiddleExtended == true
            && lExtendedFingerDetector.RingExtended == true
            && lExtendedFingerDetector.PinkyExtended == true

            && lPalmDirectionDetector.OnTarget == false
            && rPalmDirectionDetector.OnTarget == false)
        {
            MotionGauge += Time.deltaTime; 
        }
    }

    private void activatingPiano()
    {
        if (!FirstTimeToPiano)
        {
            if (lPinchDetector.Active == true
            && rPinchDetector.Active == true
            && handGestureTracking.HandsUp == true) //?????? ?????? ?????? ?¢¥?? ??? ?????? ?????? ?¢¥???. ????? ????? ???? ?©ª???.
            {
                gameStart = true;
                activePiano = true;
                FirstTimeToPiano = true;

                //??? ???�L ???? && ???? ???�L?? ???? ??
                soundManager.PlayAudioByIndex(0);
                soundManager.ManageVolume(0);

                soundManager.PlayAudioByIndex(1);
                soundManager.PlayAudioByIndex(2);
                soundManager.PlayAudioByIndex(3);
                soundManager.PlayAudioByIndex(5);
                soundManager.PlayAudioByIndex(6);
                soundManager.PlayAudioByIndex(7);
                
                uI_Manager.SetClearColor(0);

                uI_Manager.SetActiveUI(0, false);
                if (Clear.activeSelf == false)
                    Clear.SetActive(true);
                StartCoroutine(DisabledClear());
            }
        }
    }

    private void activatingCello()
    {
        uI_Manager.SetActiveUI(1, false);
        if (!FirstTimeToCello)
        {
            if(rExtendedFingerDetector.ThumbExtended == false
            && rExtendedFingerDetector.IndexExtended == true
            && rExtendedFingerDetector.MiddleExtended == false
            && rExtendedFingerDetector.RingExtended == false
            && rExtendedFingerDetector.PinkyExtended == false

            && lExtendedFingerDetector.ThumbExtended == false
            && lExtendedFingerDetector.IndexExtended == true
            && lExtendedFingerDetector.MiddleExtended == false
            && lExtendedFingerDetector.RingExtended == false
            && lExtendedFingerDetector.PinkyExtended == false

            && handGestureTracking.CircleGesture == true) //??? ?????? ??? ?????????? ???? ?????.
            {
                activeCello = true;
               
                FirstTimeToCello = true;

                soundManager.ManageVolume(1);

                if (Clear.activeSelf == false)
                    Clear.SetActive(true);
                StartCoroutine(DisabledClear());

                particle1.SetActive(true);
                uI_Manager.SetClearColor(1);
            }
        }
    }

    private void activatingChamibell1()
    {
        uI_Manager.SetActiveUI(2, false);
        uI_Manager.SetActiveUI(6, false); 
        if (!FirstTimeToChimeBell1)
        {
            if (MotionGauge >= 10)  //Basic ??? ?????? 10?? ??? ???? ??
            {
                activeChimeBell1 = true;

                FirstTimeToChimeBell1 = true;

                soundManager.ManageVolume(5);

                if (Clear.activeSelf == false)
                    Clear.SetActive(true);
                StartCoroutine(DisabledClear());

                particle2.SetActive(true);
                uI_Manager.SetClearColor(2);
                MotionGauge = 0;
            }
        }
    }

    private void activatingTimpani()
    {
        uI_Manager.SetActiveUI(3, false);
        if (!FirstTimeToDrum)
        {
            if (rExtendedFingerDetector.ThumbExtended == false
            && rExtendedFingerDetector.IndexExtended == false
            && rExtendedFingerDetector.MiddleExtended == false
            && rExtendedFingerDetector.RingExtended == false
            && rExtendedFingerDetector.PinkyExtended == false

            && lExtendedFingerDetector.ThumbExtended == false
            && lExtendedFingerDetector.IndexExtended == false
            && lExtendedFingerDetector.MiddleExtended == false
            && lExtendedFingerDetector.RingExtended == false
            && lExtendedFingerDetector.PinkyExtended == false

            && handGestureTracking.HandsUpDownShaking == true)  //??? ????? ??? ???? ???? ?¡????? ????? ?????? ??????? ????.
            {
                activeDrum = true;
                
                FirstTimeToDrum = true;

                soundManager.ManageVolume(2);

                if (Clear.activeSelf == false)
                    Clear.SetActive(true);
                StartCoroutine(DisabledClear());

                particle3.SetActive(true);
                uI_Manager.SetClearColor(3);
            }
        }
    }

    private void activatingChamibell2()
    {
        uI_Manager.SetActiveUI(2, false);
        uI_Manager.SetActiveUI(6, false);
        if (!FirstTimeToChimeBell2)
        {
            if (MotionGauge >= 2)  //Basic ??? ?????? 2?? ??? ???? ??
            {
                activeChimeBell2 = true;

                FirstTimeToChimeBell2 = true;

                soundManager.ManageVolume(6);

                if (Clear.activeSelf == false)
                    Clear.SetActive(true);
                StartCoroutine(DisabledClear());

                particle4.SetActive(true);
                uI_Manager.SetClearColor(4);
                MotionGauge = 0;
            }
        }
    }

    private void activatingViolin()
    {
        uI_Manager.SetActiveUI(4, false);
        if (!FirstTimeToViolin)
        {
            if (lPalmDirectionDetector.OnTarget == true
            && handGestureTracking.HandsShaking == true
            && rPinchDetector.Active == true)  //????? ?????? ???? ???¬Ñ? ???????? ?????? ?????? ?¢¥?? ?¢¯?? ?????¥ä?.
            {
                activeViolin = true;
                
                FirstTimeToViolin = true;

                soundManager.ManageVolume(3);

                if (Clear.activeSelf == false)
                    Clear.SetActive(true);
                StartCoroutine(DisabledClear());

                particle5.SetActive(true);
                uI_Manager.SetClearColor(5);
            }
        }
    }

    private void activatingCymbals()
    {
        uI_Manager.SetActiveUI(5, false);
        uI_Manager.SetActiveUI(6, false);
        if (!FirstTimeToCymbals)
        {
            if (MotionGauge >= 3)  //Basic ??? ?????? 3?? ??? ???? ??
            {
                activeCymbals = true;

                FirstTimeToCymbals = true;

                soundManager.ManageVolume(7);

                if (Clear.activeSelf == false)
                    Clear.SetActive(true);
                StartCoroutine(DisabledClear());

                particle6.SetActive(true);
                uI_Manager.SetClearColor(6);
                MotionGauge = 0;
            }
        }
    }

    IEnumerator DisabledClear() // 1.5?? ??? bool ?? ????
    {
        yield return new WaitForSecondsRealtime(1.5f);
        if (Clear.activeSelf == true)
            Clear.SetActive(false);
    }
}
