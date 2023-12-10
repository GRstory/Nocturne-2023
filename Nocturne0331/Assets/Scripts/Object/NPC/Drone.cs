using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    //private GameObject redLight;
    //private GameObject blueLight;
    public GameObject redLight;
    public GameObject blueLight;
    public float blinkTime;
    private void Awake() {
        //redLight = transform.GetChild(2).GetComponent<GameObject>();
        //blueLight = transform.GetChild(3).GetComponent<GameObject>();
    }
    private void Update() {
        blinkTime += Time.deltaTime;
        if(blinkTime >= 2f){
            blinkTime = 0f;
        }
        if(blinkTime >= 1f){
            blueLight.SetActive(true);
            redLight.SetActive(false);
        }
        else{
            blueLight.SetActive(false);
            redLight.SetActive(true);
        }
    }
}
