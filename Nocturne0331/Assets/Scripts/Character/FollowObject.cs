using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject player;
    private void LateUpdate(){
        this.transform.position = player.transform.position;
    }
}
