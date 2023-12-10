using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part3_Subway : MonoBehaviour
{
    public GameObject player;
    public GameObject camSet;
    public GameObject dest;
    public void Interaction(){
        player.transform.position = dest.transform.position;
        GameManager.Instance.BGM_INDEX = 7;
        GameManager.Instance.BGM_INDEX_B = 7;
        GameManager.Instance.CINEMATIC_UI = true;

        camSet.GetComponent<CameraController>().EnterInside();
    }
}
