using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //상호작용은 Interaction 스크립트에서 제어...
    private float idle = 0f;
    private float run = 0f;
    private Animator movementAnimator;
    private void Awake() {
        movementAnimator = this.GetComponent<Animator>();
    }
    private void FixedUpdate() {
        idle += Time.deltaTime;

        GetJump();
        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){
            GameManager.Instance.TIME_IDLE += idle;
            idle = 0;
            movementAnimator.SetBool("movement", true);
            movementAnimator.SetFloat("idleTime", idle);

            if(Input.GetKey(KeyCode.LeftShift)){
                run += 0.1f;
                if(run < 5f) movementAnimator.SetInteger("walkMode", 3);
                else if(run >= 5f) movementAnimator.SetInteger("walkMode", 4);
            }
            else if(Input.GetKey(KeyCode.LeftControl)){
                run = 0f;
                movementAnimator.SetInteger("walkMode", 1);
            }
            else{
                run = 0f;
                movementAnimator.SetInteger("walkMode", 2);
            }
        }
        else{
            run = 0f;
            movementAnimator.SetBool("movement", false);
            movementAnimator.SetFloat("idleTime", idle);
            movementAnimator.SetInteger("walkMode", 0);
        }
    }

    private void GetJump(){
        if(Input.GetKey(KeyCode.Space)){
            movementAnimator.SetBool("isJumping", true);
        }
        else if(!Input.GetKey(KeyCode.Space)){
            movementAnimator.SetBool("isJumping", false);
        }
    }
}
