using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1_FallObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.transform.name);
        if(collision.transform.CompareTag("Player")){
            GameManager.Instance.HEALTH = 0;
        }
    }
}
