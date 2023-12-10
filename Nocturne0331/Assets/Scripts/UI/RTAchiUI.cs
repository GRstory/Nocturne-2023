using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Components;

public class RTAchiUI : MonoBehaviour
{
    public List<Sprite> icon = new List<Sprite>(){};
    public GameObject achiUI;
    private LocalizeStringEvent title;
    private Animator animator;
    private Image image;
    private bool check = false;
    public List<bool> save = new List<bool>() {false, false, false, false, false, false, false, false, false, false, false, false};

    private void Awake() {
        title = this.transform.GetChild(4).gameObject.GetComponent<LocalizeStringEvent>();
        image = this.transform.GetChild(2).gameObject.GetComponent<Image>();
        animator = this.GetComponent<Animator>();
        
    }

    private void FixedUpdate() {
        CheckData();
    }

    private void CheckData(){
        for(int i = 0; i < 12; i++){ //어디가 달라졌는지 찾기
            if(GameManager.Instance.ACHIEVEMENT[i] != save[i]){ //달라졌으면 작업
                title.StringReference.SetReference("Achievement", "achi_t"+(i+1));
                image.sprite = icon[i];
                save[i] = GameManager.Instance.ACHIEVEMENT[i];
                animator.SetBool("check", true);
                check = true;
                StartCoroutine(UpdateEvent());
                UpdateEvent();
            }
        }

        if(check & Input.GetKey(KeyCode.X)){
            GameManager.Instance.GAME_UI = 8;
            achiUI.SetActive(true);
        }
    }

    IEnumerator UpdateEvent(){

        yield return new WaitForSecondsRealtime(3.0f);
        
        animator.SetBool("check", false);
        check = false;
    }
}
