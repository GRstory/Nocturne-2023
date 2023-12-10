using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part4_Button : MonoBehaviour
{
    public GameObject controller;
    public int num;
    public Material activeMat;
    public Material inactiveMat;
    public void Interaction(){
        controller.GetComponent<Part4_Password>().userword[num] = !controller.GetComponent<Part4_Password>().userword[num];
        if(controller.GetComponent<Part4_Password>().userword[num]){
            transform.GetComponent<Renderer>().material = activeMat;
        }
        else{
            transform.GetComponent<Renderer>().material = inactiveMat;
        }
    }
}
