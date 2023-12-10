using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1_Plank : MonoBehaviour
{
    public GameObject camController;
    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.transform.name);
        if(collision.transform.CompareTag("Player")){
            camController.GetComponent<CameraController>().EnterInside();
        }
    }
}
