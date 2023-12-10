using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CVcam1 : MonoBehaviour
{
    private CinemachineTransposer cam;
    private void Awake() {
        cam = this.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>();
        cam.m_FollowOffset = new Vector3(5f, 4.4f, 5f);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            Debug.Log("Q");
            CamTurnLeft();
        }
        else if(Input.GetKeyDown(KeyCode.E)){
            CamTurnRight();
        }
    }

    private void CamTurnLeft(){
        if(cam.m_FollowOffset == new Vector3(5f, 4.4f, 5f)) cam.m_FollowOffset = new Vector3(5f, 4.4f, -5f);
        else if(cam.m_FollowOffset == new Vector3(5f, 4.4f, -5f)) cam.m_FollowOffset = new Vector3(-5f, 4.4f, -5f);
        else if(cam.m_FollowOffset == new Vector3(-5f, 4.4f, -5f)) cam.m_FollowOffset = new Vector3(-5f, 4.4f, 5f);
        else if(cam.m_FollowOffset == new Vector3(-5f, 4.4f, 5f)) cam.m_FollowOffset = new Vector3(5f, 4.4f, 5f);
    }
    private void CamTurnRight(){
        if(cam.m_FollowOffset == new Vector3(5f, 4.4f, 5f)) cam.m_FollowOffset = new Vector3(-5f, 4.4f, 5f);
        else if(cam.m_FollowOffset == new Vector3(-5f, 4.4f, 5f)) cam.m_FollowOffset = new Vector3(-5f, 4.4f, -5f);
        else if(cam.m_FollowOffset == new Vector3(5f, 4.4f, -5f)) cam.m_FollowOffset = new Vector3(5f, 4.4f, 5f);
        else if(cam.m_FollowOffset == new Vector3(-5f, 4.4f, -5f)) cam.m_FollowOffset = new Vector3(5f, 4.4f, -5f);
    }
}
