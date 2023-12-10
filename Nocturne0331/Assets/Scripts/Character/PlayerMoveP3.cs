using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMoveP3 : MonoBehaviour
{
    public GameObject fo;
    public CinemachineVirtualCamera cam;
    private CinemachineTransposer ct;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //ct = cam.GetComponent<CinemachineTransposer>();
    }

    private void FixedUpdate()
    {
        Move();
        fo.transform.position = transform.position + new Vector3(0, 1.5f, 0); //FollowObject의 위치 업데이트
    }

    private void Move(){
        if(GameManager.Instance.GAME_UI == 0){
            float moveX = Input.GetAxisRaw("Horizontal");

            if(moveX > 0){
                //Debug.Log("Move To Right");
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                //ct.m_FollowOffset.x = 5;
            }
            else if (moveX < 0){
                //Debug.Log("Move To Left");
                transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                //ct.m_FollowOffset.x = -5;
            }
        }
    }
}
