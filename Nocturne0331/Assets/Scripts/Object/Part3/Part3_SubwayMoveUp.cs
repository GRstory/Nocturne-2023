using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part3_SubwayMoveUp : MonoBehaviour
{
    public GameObject collisionObject;
    private float time;
    private Vector3 startPos = new Vector3(85, 0, -4.75f);
    private Vector3 endPos = new Vector3(-105, 0, -4.75f);
    private void Update() {
        time += Time.deltaTime;

        if(time >= 10){
            transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * 80);

            if(transform.position == endPos){
                time = 0;
                transform.position = startPos;
            }
        }

    }
}
