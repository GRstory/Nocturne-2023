using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    //CameraController v3
    public Camera mainCamera;
    public CinemachineVirtualCamera bCam; //백뷰
    public CinemachineVirtualCamera cCam; //cctv뷰
    public List<CinemachineVirtualCamera> qCam = new List<CinemachineVirtualCamera>(); //쿼터뷰
    private int qCamIndex = 0; //활성화될 쿼터뷰 카메라 번호
    private int tempMode; //카메라 모드, 0:쿼터뷰, 1:백뷰, 2:cctv뷰
    private int tempModeBackup;
    private float latency;

    
    private void Update() {
        if(tempMode == 0) latency += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Q)) TurnQuarterCamQ();
        else if(Input.GetKeyDown(KeyCode.E)) TurnQuarterCamE();
        if(Input.GetKeyDown(KeyCode.J)) EnterOutside();
        if(Input.GetKeyDown(KeyCode.K)) EnterInside();
    }

    public void TurnQuarterCamQ(){
        if(tempMode == 0 & latency >= 1){
            qCamIndex--;
            if(qCamIndex == -1) qCamIndex = 3;

            for(int i = 0; i < 4; i++){
                qCam[i].Priority = 10; //쿼터뷰 카메라 4개 우선순위 10
            }
            qCam[qCamIndex].Priority = 20;
            GameManager.Instance.Q_CAM_INDEX = qCamIndex;

            latency = 0;
        }
    }
    public void TurnQuarterCamE(){
        if(tempMode == 0 & latency >= 1){
            qCamIndex++;
            qCamIndex = qCamIndex % 4;

            for(int i = 0; i < 4; i++){
                qCam[i].Priority = 10; //쿼터뷰 카메라 4개 우선순위 10
            }
            qCam[qCamIndex].Priority = 20;
            GameManager.Instance.Q_CAM_INDEX = qCamIndex;

            latency = 0;
        }
    }
    public void EnterOutside(){
        tempMode = 1;
        mainCamera.orthographic = false;
        bCam.Priority = 30; //백뷰 카메라 우선순위 30
        GameManager.Instance.TEMP_CAM_MODE = 1;
        Debug.Log("Enter Outside");
    }
    public void EnterInside(){
        tempMode = 0;
        mainCamera.orthographic = true;
        bCam.Priority = 0; //백뷰 카메라 우선순위 0
        GameManager.Instance.TEMP_CAM_MODE = 0;
    }
    public void EnterCCTVZone(){
        mainCamera.orthographic = false;
        tempModeBackup = tempMode;
        tempMode = 2;
        cCam.Priority = 40; //cctv뷰 카메라 우선순위 40
        GameManager.Instance.TEMP_CAM_MODE = 2;
    }
    public void ExitCCTVZone(){
        mainCamera.orthographic = true;
        tempMode = tempModeBackup;
        cCam.Priority = 0; //cctv뷰 카메라 우선순위 0
        GameManager.Instance.TEMP_CAM_MODE = tempModeBackup;
    }
}
