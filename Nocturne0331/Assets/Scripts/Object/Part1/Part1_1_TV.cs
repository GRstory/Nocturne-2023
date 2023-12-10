using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Part1_1_TV : MonoBehaviour
{
    public GameObject player;
    public Vector3 dest;
    public void Interaction(){
        player.transform.position = dest;
        GameManager.Instance.BGM_INDEX = 2;
        GameManager.Instance.BGM_INDEX_B = 2;
        GameManager.Instance.SAVE_POINT = 1;
    }
}
