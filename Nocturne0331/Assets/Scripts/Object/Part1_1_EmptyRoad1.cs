using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1_1_EmptyRoad1 : MonoBehaviour
{
    public Material skymat_Standard;
    public Material skymat_Warning;

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Player"){
            RenderSettings.skybox = skymat_Warning;
        }
    }
}
