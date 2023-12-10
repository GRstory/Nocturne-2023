using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartEnd_EndingCredit : MonoBehaviour
{
    public float speed = 50f;
    public float duration = 30f;
    public float timer = 0f;
    public GameObject endText;
    private void Start() {
        Invoke("EndText", 27);
    }
    void Update()
    {
        if(timer <= duration){
            timer += Time.deltaTime;
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else{
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
    private void EndText(){
        endText.SetActive(true);
    }
}
