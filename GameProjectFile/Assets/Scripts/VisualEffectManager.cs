using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffectManager : MonoBehaviour
{
    public GameObject effect;

    public void activeEffect(){
        effect.gameObject.SetActive(true);
    }
}
