using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Part0_GameOn : MonoBehaviour
{
    private bool isActive = false;
    public float time;
    public float _fadeTime = 1f;
    public GameObject pressText;
    void Update()
    {
        if(Input.GetButtonDown("Submit")){
            isActive = true;
        }
        if(isActive){
            pressText.SetActive(false);
            if(time < _fadeTime){
            GetComponent<Image>().color = new Color(1, 1, 1, 1f - time/_fadeTime);
        }
        else{
            time = 0;
            this.gameObject.SetActive(false);
        }
            time += Time.deltaTime;
        }
    }
}
