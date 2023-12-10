using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1_Building : MonoBehaviour
{
    public GameObject camController;
    public GameObject map2;
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.CompareTag("Player")){
            camController.GetComponent<CameraController>().EnterCCTVZone();
            GameManager.Instance.CINEMATIC_UI = true;
            map2.SetActive(true);
        }
    }
}
