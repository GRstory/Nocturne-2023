using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject bCam;
    public GameObject cCam;
    public List<GameObject> qCam = new List<GameObject>();

    private GameObject mainCamera;
    private float jumpForce = 3f;
    private Rigidbody rb;
    private bool isjumping;
    private Vector3 moveDirection; // 이동 방향 벡터

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(GameManager.Instance.TEMP_CAM_MODE == 0){
            mainCamera = qCam[GameManager.Instance.Q_CAM_INDEX];
        }
        else if(GameManager.Instance.TEMP_CAM_MODE == 1){
            mainCamera = bCam;
        }
        else mainCamera = cCam;
        Move();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isjumping = false;
        }
    }

    private void Move(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = (vertical * cameraForward + horizontal * mainCamera.transform.right) * Time.deltaTime;

        moveDirection = movement.normalized; // 정규화

        if(moveDirection != Vector3.zero){
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }

    private void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) & !isjumping)
        {
            Debug.Log("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //위쪽으로 힘을 준다.
            isjumping = true;
        }
    }
}
