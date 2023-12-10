using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1_1_Window : MonoBehaviour
{
    [SerializeField]private GameObject dest;
    private bool isActive = false;
    public GameObject player;
    private void Update() {
        if(isActive) transform.position = Vector3.MoveTowards(transform.position, dest.transform.position, 0.01f);
    }
    public void Interaction(){
        isActive = true;
        GameManager.Instance.ACHIEVEMENT[0] = true;
        player.GetComponent<CameraController>().EnterOutside();
    }
}
