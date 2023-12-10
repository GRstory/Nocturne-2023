using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    public GameObject loadingUI;
    private float time = 0;
    private Animator logoA;
    private Animator logoB;
    private GameObject logoC;
    private Animator upper;
    private Animator downer;
    private void Awake() {
        upper = transform.GetChild(0).GetComponent<Animator>();
        downer = transform.GetChild(1).GetComponent<Animator>();
        logoA = transform.GetChild(2).GetComponent<Animator>();
        logoB = transform.GetChild(3).GetComponent<Animator>();
        logoC = transform.GetChild(4).GetComponent<GameObject>();
    }
    private void Update() {
        time += Time.deltaTime;
        if(time > 7.0f & time < 7.1f){

            logoA.SetTrigger("check");
            logoB.SetTrigger("check");
        }
        else if(time > 8.0f & time < 8.1f){
            upper.SetTrigger("check");
            downer.SetTrigger("check");
            //logoC.SetActive(false);

        }
        else if(time > 10.0f){
            loadingUI.SetActive(false);
        }
    }
}
