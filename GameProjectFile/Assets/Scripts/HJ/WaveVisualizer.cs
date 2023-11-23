using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveVisualizer : MonoBehaviour
{
    Renderer renderer;
    public GameObject waveObject;

    public float maxScale = 20f;             // 오브젝트의 최대 크기
    public float scaleSpeed = 2f;            // 스케일 변화 속도
    public float fadeSpeed = 0.5f;           // 투명도 변화 속도

    private float currentScale;              // 현재 스케일

    private void Start()
    {
        renderer = waveObject.GetComponent<Renderer>();     
        currentScale = waveObject.transform.localScale.x*1.5f;     
        StartCoroutine("ScaleAndFadeOut");    
    }

    IEnumerator ScaleAndFadeOut()
    {

        for (int i = 10; i >= 0; i--)
        {
            float f = i / 10.0f;
            Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;

            currentScale += scaleSpeed * Time.deltaTime;
            float newScaleXZ = currentScale;
            Vector3 newScale = new Vector3(newScaleXZ, waveObject.transform.localScale.y, newScaleXZ);
            waveObject.transform.localScale = newScale;

            yield return new WaitForSeconds(fadeSpeed / 10f);
        }
        Destroy(waveObject);
    }
}
