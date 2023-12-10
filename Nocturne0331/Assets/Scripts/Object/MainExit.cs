using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainExit : MonoBehaviour
{
    public GameObject exitUI;
    public GameObject character;

    public void Btn01(){ //종료 버튼
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    public void Btn02(){ //종료 취소 버튼
        exitUI.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Player"){
            exitUI.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision){
        if(collision.gameObject.name == "Player"){
            exitUI.SetActive(false);
        }
    }
}
