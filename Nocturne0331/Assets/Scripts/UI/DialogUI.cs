using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUI : MonoBehaviour
{
    public GameObject dialogUI;
    public GameObject player;
    private Animator movementAnimator;
    private void Awake() {
        movementAnimator = player.GetComponent<Animator>();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) & GameManager.Instance.GAME_UI == 4){
            DialogUI_Next();
        }
    }

    public void DialogUI_OFF(){
        GameManager.Instance.GAME_UI = 0;
        Time.timeScale = 1;
        movementAnimator.SetBool("freeze", false);
        dialogUI.SetActive(false);
        player.GetComponent<Interaction>().dialogIndex = 0;
    }

    public void DialogUI_Next(){
        player.GetComponent<Interaction>().dialogIndex++;
        player.GetComponent<Interaction>().DialogUpdate();
    }
}
