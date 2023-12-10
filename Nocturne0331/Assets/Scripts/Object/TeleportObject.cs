using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeleportObject : MonoBehaviour
{
    public GameObject character; //캐릭터 오브젝트
    public bool active = false; //활성화 여부
    private float timeStart;
    private float timeCurrent;
    public float timeMax = 2f; //최대 시간
    public Vector3 teleportWay;

    void Update()
    {
        if(active){
            TimeRecord();
        }
    }

    private void TimeReset(){
        timeStart = Time.time;
        timeCurrent = 0;
    }

    private void TimeRecord(){
        
        timeCurrent = Time.time-timeStart;

        if(timeCurrent < timeMax){
            timeCurrent = Time.time - timeStart;
        }
        else{
            Debug.Log("타임아웃"); //시간 다됐을때 여기 코드 추가
            //character.transform.position = target.transform.position;
            character.GetComponent<NavMeshAgent>().Warp(teleportWay);
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Player"){
            TimeReset();
            Debug.Log("입장, x초후 이동");
            
            active = true;
            timeCurrent = Time.time-timeStart;
            gameObject.transform.position += new Vector3(0, -0.02f, 0);
        }
    }

    private void OnCollisionExit(Collision collision){
        if(collision.gameObject.name == "Player"){
            Debug.Log("퇴장");
            active = false;
            gameObject.transform.position += new Vector3(0, +0.02f, 0);
        }
    }
}
