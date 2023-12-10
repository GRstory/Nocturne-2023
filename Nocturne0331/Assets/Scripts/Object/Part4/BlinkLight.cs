using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    private Light light;
    private float minTime = 0.2f;
    private float maxTime = 5.0f;
    private float nextTime = 0.2f;
    private void Awake() {
        light = transform.GetChild(2).transform.GetComponent<Light>();
    }

    private void Update() {
        if(Time.time >= nextTime){
            light.enabled = !light.enabled;

            nextTime = Time.time + Random.Range(minTime, maxTime);
        }
    }
}
