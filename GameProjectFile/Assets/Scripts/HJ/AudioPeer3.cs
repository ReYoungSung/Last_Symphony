using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPeer3 : MonoBehaviour
{
    public GameObject sampleCubePrefab;
    GameObject[] sampleCube = new GameObject[64];
    public float maxScale;
    private AudioPeer audioPeer;
    private float startPosionY = 0;

    //빛 강도 조절
    public float minLightIntensity = 0f;
    public float maxLightIntensity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        startPosionY = transform.localPosition.y;
        audioPeer = GetComponent<AudioPeer>();
        for (int i=0; i<64; i++)
        {
            GameObject instanceSampleCube = (GameObject)Instantiate(sampleCubePrefab);  
            instanceSampleCube.transform.position = this.transform.position;  
            instanceSampleCube.transform.parent = this.transform;  
            instanceSampleCube.name = "SampleCube" + i;  
            
            //this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            //this.transform.localRotation = Quaternion.Euler(90f, -0.703125f * i, 0f);
            this.transform.position = new Vector3(i,  0, 0);

            instanceSampleCube.transform.position = Vector3.forward;
            sampleCube[i] = instanceSampleCube;
            

            // Light 컴포넌트 추가
            Light cubeLight = instanceSampleCube.AddComponent<Light>();
            cubeLight.type = LightType.Point;
            cubeLight.intensity = 0;

        }
        
        transform.localRotation = Quaternion.Euler(0f, -109f, 0f);
        transform.localPosition = new Vector3(-314.5f, -324.4f, 356.4f);
        transform.localScale = new Vector3(0.2f, 0.1f, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 64; i++)
        {
            if (sampleCube != null)
            {
                float scaleY = (audioPeer.samples[i] * maxScale) + 2; 
                Vector3 newScale = new Vector3(sampleCube[i].transform.localScale.x, scaleY, sampleCube[i].transform.localScale.z); 
                sampleCube[i].transform.localScale = newScale; 

                // Y 축 위치 조정
                float newY = startPosionY + (scaleY / 2); 
                Vector3 newPosition = new Vector3(sampleCube[i].transform.localPosition.x, newY, sampleCube[i].transform.localPosition.z); 
                sampleCube[i].transform.localPosition = newPosition; 

                // 빛 조정
                Light cubeLight = sampleCube[i].GetComponent<Light>(); 
                if (cubeLight != null &&scaleY>3) 
                {
                    //Debug.Log(i);
                    //Debug.Log(scaleY);
                    // 스케일 값에 따라 빛의 강도 설정
                    float intensity = Mathf.Lerp(minLightIntensity, maxLightIntensity, scaleY / maxScale*100); 
                    cubeLight.intensity = intensity;
                }
            }
        }
        
    }

}
