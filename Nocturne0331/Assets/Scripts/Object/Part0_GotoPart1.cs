using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Part0_GotoPart1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Player"){
            SceneManager.LoadScene("Part1");
        }
    }
}
