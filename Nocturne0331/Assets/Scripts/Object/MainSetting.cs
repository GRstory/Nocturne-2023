using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSetting : MonoBehaviour
{
    public GameObject settingUI;
    public GameObject character;

    public void BtnSave(){
        settingUI.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Player"){
            settingUI.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision){
        if(collision.gameObject.name == "Player"){
            settingUI.SetActive(false);
        }
    }
}