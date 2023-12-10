using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part4_Start : MonoBehaviour
{
    public GameObject player;
    public GameObject dest;
    public GameObject camSet;
    public void Interaction(){
        player.transform.position = dest.transform.position;
        GameManager.Instance.SAVE_POINT = 7;
        GameManager.Instance.BGM_INDEX = 8;
        GameManager.Instance.BGM_INDEX_B = 8;

        camSet.GetComponent<CameraController>().EnterOutside();
        player.GetComponent<PlayerMove>().enabled = false;
        player.GetComponent<PlayerMoveP3>().enabled = true;

        player.transform.rotation = Quaternion.LookRotation(Vector3.right);
    }
}
