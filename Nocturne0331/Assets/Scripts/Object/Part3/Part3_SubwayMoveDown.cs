using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part3_SubwayMoveDown : MonoBehaviour
{
    public GameObject collisionObject;
    private float time;
    private Vector3 startPos = new Vector3(-85, 0, -10.25f);
    private Vector3 endPos = new Vector3(10, 0, -10.25f);
    private float initSpeed = 2f;
    private float decrese = 2f;
    private float currentSpeed;
    private void Start() {
        transform.position = startPos;

        currentSpeed = initSpeed;
    }
    private void Update() {
        time += Time.deltaTime;

        if(time >= 2){
            transform.position = Vector3.Lerp(startPos, endPos, currentSpeed * Time.deltaTime); // 보간된 위치로 이동

            currentSpeed -= decrese * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0f);


        }
    }
}
