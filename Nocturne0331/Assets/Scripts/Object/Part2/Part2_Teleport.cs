using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part2_Teleport : MonoBehaviour
{
    public Transform target;
    public Transform Player;
    private void OnCollisionEnter(Collision other) {
        if(other.transform.CompareTag("Player"))
        {
            if(target != null)
            {
                Player.position = target.position;
            }
        }
    }
}
