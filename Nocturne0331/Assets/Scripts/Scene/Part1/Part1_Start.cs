using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Part1_Start : MonoBehaviour
{
    private float time;
    public Image background;
    public TextMeshProUGUI title;
    public GameObject titleObject;
    public GameObject backgroundObject;
    void Update()
    {
        Invoke("StartPart1", 3f);
    }

    private void StartPart1(){
        if(time < 3.0f){
            title.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1f - time/3.0f);
            background.GetComponent<Image>().color = new Color(1, 1, 1, 1f - time/3.0f);
        }
        else{
            time = 0;
            titleObject.SetActive(false);
            backgroundObject.SetActive(false);
        }
        time += Time.deltaTime;
    }
}
