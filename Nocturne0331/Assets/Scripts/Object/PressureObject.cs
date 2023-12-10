using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureObject : MonoBehaviour
{
    public GameObject character; //캐릭터 오브젝트
    public bool active = false; //활성화 여부
    public bool actived = false; //활성화 여부 (한번이라도)
    public int activeTime = 0; //활성화 번수

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Player"){
            if(!actived){
                Debug.Log("최초 입장");
                actived = true;
            }
            else{
                Debug.Log("재입장");
            }

            active = true;
            activeTime += 1;
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

