using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private float maxJumpTime = 0.3f;
    [SerializeField] private float minJumpTime = 0.1f;
    [SerializeField] private float jumpTime;
    [SerializeField] private bool isJumping;
    [SerializeField] private int jumpsAllowed = 1;
    private int currentJumps;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentJumps < jumpsAllowed)
            {
                Jump();
                currentJumps++;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isJumping)
            {
                if (jumpTime < minJumpTime)
                {
                    float ratio = jumpTime / minJumpTime;
                    rb.velocity = new Vector3(rb.velocity.x, jumpForce * ratio, rb.velocity.z);
                }

                isJumping = false;
            }
        }

        if (isJumping)
        {
            jumpTime += Time.deltaTime;
            if (jumpTime >= maxJumpTime)
            {
                isJumping = false;
            }
            else
            {
                float ratio = jumpTime / maxJumpTime;
                rb.velocity = new Vector3(rb.velocity.x, jumpForce * (1 - Mathf.Pow(ratio - 1, 2)), rb.velocity.z);
            }
        }
        else
        {
            if (IsGrounded())
            {
                currentJumps = 0;
            }
        }
    }

    private bool IsGrounded()
    {
        float groundDistance = 0.2f;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundDistance))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Jump()
    {
        isJumping = true;
        jumpTime = 0f;
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }
}