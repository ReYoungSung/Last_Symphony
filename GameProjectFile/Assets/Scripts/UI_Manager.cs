using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameObject[] uiObjects; // Ȱ��ȭ/��Ȱ��ȭ�� UI ������Ʈ��
    public GameObject[] frameObjects; // ������ UI ������Ʈ��
    public float blinkingDuration = 4f; // ������ ���� �ð� 
    public Color blinkingColor = Color.black; // ������ ����
    public Color frameColor = Color.red; // ������ ����
    public Color ClearColor = Color.green; // Ŭ���� ����

    private float[] blinkingTimers; // ������ Ÿ�̸� �迭
    private bool[] isBlinking; // ������ ���� �迭

    private void Awake()
    {
        int frameCount = frameObjects.Length;
        blinkingTimers = new float[frameCount];
        isBlinking = new bool[frameCount];
    }

    // UI ������Ʈ Ȱ��ȭ/��Ȱ��ȭ
    public void SetActiveUI(int index, bool isActive)
    {
        if (index >= 0 && index < uiObjects.Length)
        {
            uiObjects[index].SetActive(isActive);
        }
        else
        {
            Debug.LogWarning("��ȿ���� ���� �ε����Դϴ�.");
        }
    }

    // UI ������Ʈ Ȱ��ȭ ���� ��ȯ
    public bool IsUIActive(int index)
    {
        if (index >= 0 && index < uiObjects.Length)
        {
            return uiObjects[index].activeSelf;
        }
        else
        {
            Debug.LogWarning("��ȿ���� ���� �ε����Դϴ�.");
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
            Debug.LogWarning("��ȿ���� ���� �ε����Դϴ�.");
            return false;
        }
    }

    // ������ ����
    public void StartBlinking(int index)
    {
        frameObjects[index].SetActive(true);

        StopBlinking(index);

        isBlinking[index] = true;

        StartCoroutine(BlinkRoutine(index));
    }

    // ������ ��ƾ
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
            // ������ �������� ����
            SetFrameColor(rawImages, blinkingColor);
            yield return new WaitForSeconds(0.5f);

            if(isBlinking[index])
            {
                // ���� ������ �������� ����
                SetFrameColor(rawImages, frameColor);
                yield return new WaitForSeconds(0.5f);
                Duration += 1;
            }
        }
    }

    // ������ ����
    private void StopBlinking(int index)
    {
        isBlinking[index] = false;
    }

    // Ŭ���� ���� ����
    public void SetClearColor(int index)
    {
        RawImage[] rawImages = frameObjects[index].GetComponentsInChildren<RawImage>();
        SetFrameColor(rawImages, ClearColor);
        StopBlinking(index);
    }

    // ������ ���� ����
    public void SetFrameColor(int index, Color color)
    {
        RawImage[] rawImages = frameObjects[index].GetComponentsInChildren<RawImage>();
        SetFrameColor(rawImages, color);
    }

    // ������ ���� ����
    private void SetFrameColor(RawImage[] rawImages, Color color)
    {
        foreach (RawImage rawImage in rawImages)
        {
            rawImage.color = color;
        }
    }
}