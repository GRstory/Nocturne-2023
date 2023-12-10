using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Part3_CCTV : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public GameObject camSet;

    private void OnCollisionEnter(Collision other) {
        camSet.GetComponent<CameraController>().cCam = cam;

        camSet.GetComponent<CameraController>().EnterCCTVZone();
    }
}
