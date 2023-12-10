using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Blink : MonoBehaviour
{
    public float time;
    public float speed;
    void Update()
    {
        if(time < 0.3f){
            GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1 - time);
        }
        else{
            GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, time);
            if(time > 1f){
                time = 0;
            }
        }
        time += Time.deltaTime / speed;
    }
}
