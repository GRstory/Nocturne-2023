using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatToilet : MonoBehaviour
{
    public GameObject player;
    public Animator movementAnimator;
    private Vector3 targetPosition;
    public bool active = false;
    private void Start(){
        targetPosition = transform.position + new Vector3(0, 0.0f, 0);
        movementAnimator = player.GetComponent<Animator>();
    }
    public void Interaction(){
        active = true;
    }
    private void Update() {
        if(active){
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, Time.deltaTime * 1.0f);

            if(Vector3.Distance(player.transform.position, targetPosition) <= 0.25f){
                active = false;
                movementAnimator.SetTrigger("sleep");

                Invoke("NextStage", 3);
            }
        }
    }

    private void NextStage(){
        GameManager.Instance.SAVE_PART += 1;
        SceneManager.LoadScene("Part4");
        GameManager.Instance.SAVE_POINT = 6;
        GameManager.Instance.BGM_INDEX = 8;
        GameManager.Instance.BGM_INDEX_B = 8;
        GameManager.Instance.CINEMATIC_UI = false;
    }
}
