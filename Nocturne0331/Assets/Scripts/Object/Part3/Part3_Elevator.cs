using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part3_Elevator : MonoBehaviour
{
    public GameObject player;
    public GameObject camSet;
    public GameObject dest;
    public void Interaction(){
        player.transform.position = dest.transform.position;
        GameManager.Instance.BGM_INDEX = 7;
        GameManager.Instance.BGM_INDEX_B = 7;
        GameManager.Instance.SAVE_POINT = 5;

        camSet.GetComponent<CameraController>().EnterOutside();
    }
}
