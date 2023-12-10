using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicUI : MonoBehaviour
{
    public GameObject upper;
    public GameObject lower;
    private Animator upperAnimator;
    private Animator lowerAnimator;
    
    private void Awake() {
        upperAnimator = upper.GetComponent<Animator>();
        lowerAnimator = lower.GetComponent<Animator>();

        upperAnimator.SetBool("isON", false);
        lowerAnimator.SetBool("isON", false);
    }

    private void Update() {
        if(GameManager.Instance.CINEMATIC_UI & GameManager.Instance.GAME_UI == 0){
            GameManager.Instance.GAME_UI = 10;
            
            upperAnimator.SetBool("isON", true);
            lowerAnimator.SetBool("isON", true);
        }
        else if(!GameManager.Instance.CINEMATIC_UI & GameManager.Instance.GAME_UI == 10){
            GameManager.Instance.GAME_UI = 0;

            upperAnimator.SetBool("isON", false);
            lowerAnimator.SetBool("isON", false);
        }
        
        
    }
}
