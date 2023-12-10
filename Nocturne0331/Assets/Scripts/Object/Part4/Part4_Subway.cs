using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part4_Subway : MonoBehaviour
{
    public GameObject player;
    public GameObject dest;
    public GameObject camSet;
    public void Interaction(){
        player.transform.position = dest.transform.position;
        GameManager.Instance.SAVE_POINT = 6;
        GameManager.Instance.BGM_INDEX = 7;
        GameManager.Instance.BGM_INDEX_B = 7;

        camSet.GetComponent<CameraController>().EnterInside();
        player.GetComponent<PlayerMove>().enabled = true;
        player.GetComponent<PlayerMoveP3>().enabled = false;
    }
}
