using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float offsetX = 5.0f; //카메라 위치 조정
    private float offsetY = 4.3f; //카메라 위치 조정
    private float offsetZ = 5.0f; //카메라 위치 조정
    public GameObject player;
    private Vector3 camPos;

    private Vector3 standardDegree = new Vector3(30f, 225f, 0f); //기본 세팅

    void Update()
    {
        camPos = Camera.main.transform.position;
        transform.position = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, player.transform.position.z + offsetZ);

        if(Input.GetKeyDown("q")){
            CamTurnLeft(1);
        }
        else if(Input.GetKeyDown("e")){
            CamTurnRight(1);
        }
        //if(offsetX == 5.0f & offsetZ == 5.0f) GameManager.Instance.camMode = 0;
        //if(offsetX == 5.0f & offsetZ == -5.0f) GameManager.Instance.camMode = 3;
        //if(offsetX == -5.0f & offsetZ == -5.0f) GameManager.Instance.camMode = 2;
        //if(offsetX == -5.0f & offsetZ ==  5.0f) GameManager.Instance.camMode = 1;
    }

    public void CamTurnLeft(int num){
        Debug.Log("CT_L");
        if(num <= 0) num = 1;
        
        for(int i = 0; i < num; i++){
            standardDegree.y += 90;
            transform.localEulerAngles = standardDegree;

            if(offsetX == 5.0f & offsetZ == 5.0f) offsetZ = -5.0f;
            else if(offsetX == 5.0f & offsetZ == -5.0f) offsetX = -5.0f;
            else if(offsetX == -5.0f & offsetZ == -5.0f) offsetZ = 5.0f;
            else if(offsetX == -5.0f & offsetZ ==  5.0f) offsetX = 5.0f;
        }
    }
    public void CamTurnRight(int num){
        Debug.Log("CT_R");
        if(num <= 0) num = 1;

        for (int i= 0; i < num; i++){
            standardDegree.y -= 90;
            transform.localEulerAngles = standardDegree;
            
            if(offsetX == 5.0f & offsetZ == 5.0f) offsetX = -5.0f;
            else if(offsetX == -5.0f & offsetZ == 5.0f) offsetZ = -5.0f;
            else if(offsetX == -5.0f & offsetZ == -5.0f) offsetX = 5.0f;
            else if(offsetX == 5.0f & offsetZ == -5.0f) offsetZ = 5.0f;
        }
    }
}
