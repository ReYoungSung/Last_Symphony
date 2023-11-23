using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelloScript : MonoBehaviour
{
    public int numPoints = 100;
    public float lineWidth = 0.1f;
    public float maxAmplitude = 1.0f;
    //public Color lineColor = Color.white;
    public Material lineMaterial;
    public GameObject soundObject;

    private float position_x = -130.8f; 
    private float position_y = -7.0f; 
    private float position_z = -19.0f; 
    private float lengthValue = 93.76f;
    private int rotationValue = -174;   // Í∑∏Îûò?îÑ?ùò rotation Í∞?
    public float smoothValue = 7.0f; // ???ÏßÅÏûÑ?ùò Î∂??ìú?ü¨??? ?†ï?èÑÎ•? Ï°∞Ï†à?ïò?äî Í∞?

    private float desiredAmplitude = 200.0f;
    private bool hasAddedPositionX = false;

    private LineRenderer lineRenderer;
    private float[] samples;
    private Vector3[] positions;
    private Vector3[] velocities;

    


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numPoints;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = lineMaterial;
        
        samples = new float[numPoints];

        positions = new Vector3[numPoints];
        velocities = new Vector3[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            float t = (float)i / (numPoints - 1);
            float spacing = lengthValue / (numPoints - 1);
            positions[i] = new Vector3(position_x + i * spacing - 1, position_y, position_z + i * 0.1f);
            velocities[i] = Vector3.zero;
        }
    }

    void Update()
    {
        AudioSource audioSource = soundObject.GetComponent<AudioSource>();
        audioSource.GetOutputData(samples, 1);

        float spacing = lengthValue / (numPoints - 1); // Calculate spacing based on numPoints

        for (int i = 0; i < numPoints; i++)
        {
            Vector3 point = new Vector3(position_x + i * spacing - 1, position_y + (samples[i] / maxAmplitude) * desiredAmplitude, position_z + i * 0.1f);
            point = Quaternion.Euler(0, rotationValue, 0) * point;
            lineRenderer.SetPosition(i, point);
        }

        for (int i = 0; i < numPoints; i++)
        {
            Vector3 targetPosition = new Vector3(position_x + i * spacing - 1, position_y + samples[i] / maxAmplitude, position_z + i * 0.1f);
            targetPosition = Quaternion.Euler(0, rotationValue, 0) * targetPosition;

            positions[i] = Vector3.SmoothDamp(positions[i], targetPosition, ref velocities[i], smoothValue * Time.deltaTime);
            lineRenderer.SetPosition(i, positions[i]);
            
        }

        if(!hasAddedPositionX){
            position_x += 80.0f;  // ?ù¥Í±∞Î≠îÍ∞??ê®
            hasAddedPositionX = true;
        }
    }
}
