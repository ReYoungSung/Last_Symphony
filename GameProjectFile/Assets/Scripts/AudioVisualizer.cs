using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour
{
    public int numPoints = 100;
    public float lineWidth = 0.1f;
    public float maxAmplitude = 1.0f;
    public Color lineColor = Color.white;
    public float smoothValue = 5.0f;

    public GameObject audioSourceObject; // 다른 게임오브젝트의 Audio Source를 가지고 올 public 변수

    public float rotationValue = 0.0f;   // 그래프의 rotation 값
    public float lengthValue = 10.0f; // 그래프의 length 값
    public float positionValue = 10.0f; // 그래프의 position 이동값
    public float positionValue2 = 0.0f;

    private LineRenderer lineRenderer;
    private float[] samples;
    private Material material;
    private Vector3[] positions;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numPoints;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        // Create a new material with the desired color
        material = new Material(Shader.Find("Sprites/Default"));
        material.color = lineColor;
        lineRenderer.material = material;

        samples = new float[numPoints];

        // Initialize positions array
        positions = new Vector3[numPoints];
        for (int i = 0; i < numPoints; i++)
        {
            float t = (float)i / (numPoints - 1);
            float spacing = lengthValue / (numPoints - 1);
            positions[i] = new Vector3(-positionValue + i * spacing, 0+positionValue2, 0);

        }
    }

    void Update()
    {
        // 다른 게임오브젝트의 Audio Source 가져오기
        AudioSource audioSource = audioSourceObject.GetComponent<AudioSource>();
        audioSource.GetOutputData(samples, 0);

        float spacing = lengthValue / (numPoints - 1);

        for (int i = 0; i < numPoints; i++)
        {
            float t = (float)i / (numPoints - 1);
            float y = samples[i] / maxAmplitude;
            float curve = Mathf.Pow(Mathf.Sin(t * Mathf.PI), 2); // Apply curve to y-coordinate

            // Check if the absolute value of the sample is greater than maxAmplitude
            if (Mathf.Abs(samples[i]) > maxAmplitude)
            {
                y = Mathf.Sign(samples[i]);
            }

            // Flip the sign of y to move the graph towards negative y direction
            y = -y;
            
            Vector3 point = new Vector3(-positionValue + i * spacing, y * curve + positionValue2, 0);

            point = Quaternion.Euler(0, 0, rotationValue) * point;
            positions[i] = Vector3.Lerp(positions[i], point, Time.deltaTime * smoothValue);
        }

        lineRenderer.SetPositions(positions);
    }
}
