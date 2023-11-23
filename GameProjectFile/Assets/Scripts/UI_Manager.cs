using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameObject[] uiObjects; // 활성화/비활성화할 UI 오브젝트들
    public GameObject[] frameObjects; // 프레임 UI 오브젝트들
    public float blinkingDuration = 4f; // 깜박임 지속 시간 
    public Color blinkingColor = Color.black; // 깜박임 색상
    public Color frameColor = Color.red; // 프레임 색상
    public Color ClearColor = Color.green; // 클리어 색상

    private float[] blinkingTimers; // 깜박임 타이머 배열
    private bool[] isBlinking; // 깜박임 여부 배열

    private void Awake()
    {
        int frameCount = frameObjects.Length;
        blinkingTimers = new float[frameCount];
        isBlinking = new bool[frameCount];
    }

    // UI 오브젝트 활성화/비활성화
    public void SetActiveUI(int index, bool isActive)
    {
        if (index >= 0 && index < uiObjects.Length)
        {
            uiObjects[index].SetActive(isActive);
        }
        else
        {
            Debug.LogWarning("유효하지 않은 인덱스입니다.");
        }
    }

    // UI 오브젝트 활성화 여부 반환
    public bool IsUIActive(int index)
    {
        if (index >= 0 && index < uiObjects.Length)
        {
            return uiObjects[index].activeSelf;
        }
        else
        {
            Debug.LogWarning("유효하지 않은 인덱스입니다.");
            return false;
        }
    }

    public bool IsFrameUIActive(int index)
    {
        if (index >= 0 && index < frameObjects.Length)
        {
            return frameObjects[index].activeSelf;
        }
        else
        {
            Debug.LogWarning("유효하지 않은 인덱스입니다.");
            return false;
        }
    }

    // 깜박임 시작
    public void StartBlinking(int index)
    {
        frameObjects[index].SetActive(true);

        StopBlinking(index);

        isBlinking[index] = true;

        StartCoroutine(BlinkRoutine(index));
    }

    // 깜박임 루틴
    private IEnumerator BlinkRoutine(int index)
    {
        RawImage[] rawImages = frameObjects[index].GetComponentsInChildren<RawImage>();

        int Duration = 0;
        int PianoDuration = 0;
        
        if(index == 0)
        {
            PianoDuration = 10000;
        }
        else if(index == 2)
        {
            PianoDuration = 15;
        }
        else
        {
            PianoDuration = 0;
        }

        while (isBlinking[index] && Duration < blinkingDuration + PianoDuration)
        {
            // 깜박임 색상으로 변경
            SetFrameColor(rawImages, blinkingColor);
            yield return new WaitForSeconds(0.5f);

            if(isBlinking[index])
            {
                // 원래 프레임 색상으로 변경
                SetFrameColor(rawImages, frameColor);
                yield return new WaitForSeconds(0.5f);
                Duration += 1;
            }
        }
    }

    // 깜박임 종료
    private void StopBlinking(int index)
    {
        isBlinking[index] = false;
    }

    // 클리어 색상 설정
    public void SetClearColor(int index)
    {
        RawImage[] rawImages = frameObjects[index].GetComponentsInChildren<RawImage>();
        SetFrameColor(rawImages, ClearColor);
        StopBlinking(index);
    }

    // 프레임 색상 설정
    public void SetFrameColor(int index, Color color)
    {
        RawImage[] rawImages = frameObjects[index].GetComponentsInChildren<RawImage>();
        SetFrameColor(rawImages, color);
    }

    // 프레임 색상 설정
    private void SetFrameColor(RawImage[] rawImages, Color color)
    {
        foreach (RawImage rawImage in rawImages)
        {
            rawImage.color = color;
        }
    }
}