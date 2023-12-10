using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using TMPro;


public class Interaction : MonoBehaviour
{
    private GameObject closeObject;
    private GameObject closeObjectBackup;
    public int dialogIndex = 0;

    private float interactionDistance = 1.0f;

    //public Material defaltMat;
    //public Material highlightMat;
    public TextMeshProUGUI dialogUI_Dialog;
    public GameObject player;
    private Animator movementAnimator;
    public GameObject interactionUI;
    public TextMeshProUGUI notice;
    //public GameObject[] objects;
    private void Awake() {
        movementAnimator = player.GetComponent<Animator>();
    }
    
    private void Update() {
        FindObject();
        if(closeObject != null){
            interactionUI.SetActive(true);
            /*
            try{
                UpdateUI(closeObject.GetComponent<InteractionableObject>().type, closeObject.name);
            }
            catch{
                Debug.Log(closeObject);
                Debug.Log(closeObject.GetComponent<InteractionableObject>().type);
                Debug.Log(closeObject.name);
            }*/
            
            UpdateUI(closeObject.GetComponent<InteractionableObject>().type, closeObject.name);
            if(Input.GetKeyDown(KeyCode.F) & GameManager.Instance.GAME_UI == 0){
                Debug.Log("F");
                closeObject.GetComponent<InteractionableObject>().Interact(closeObject, dialogIndex);
                movementAnimator.SetBool("interaction", true);
            }
            else {
            movementAnimator.SetBool("interaction", false);
            }
        }
        else {
            movementAnimator.SetBool("interaction", false);
            interactionUI.SetActive(false);
        }
        
    }

    public void DialogUpdate(){
        if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1]) {
            dialogUI_Dialog.text = player.GetComponent<TalkManager>().GetTalk(closeObject.GetComponent<InteractionableObject>().id, dialogIndex);
        }
        else{
            dialogUI_Dialog.text = player.GetComponent<TalkManager>().GetTalk(closeObject.GetComponent<InteractionableObject>().id + 1000, dialogIndex);
        }
         
    }

    private void FindObject(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Interact"); //Interact 태그 찾기

        float closestDistance = Mathf.Infinity; //거리 초기화

        if(closeObject != closeObjectBackup){
            //closeObjectBackup.GetComponent<MeshRenderer>().material = defaltMat; //가장 가깝지 않아지면 기본 머터리얼로 변경
        }

        foreach (GameObject obj in objects){
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            
            //obj.GetComponent<MeshRenderer>().material = defaltMat;

            if (distance < closestDistance && distance < interactionDistance){
                closeObject = obj;
                closeObjectBackup = closeObject;
                closestDistance = distance;
                //closeObject.GetComponent<MeshRenderer>().material = highlightMat; //가까워지면 하이라이트 머터리얼로 변경
                //Debug.Log(closeObject.name + "오브젝트와 상호작용 가능합니다.");
            }
        }

        if (closestDistance > interactionDistance)
        {
            closeObject = null;
            //if(closeObjectBackup != null) closeObjectBackup.GetComponent<MeshRenderer>().material = defaltMat; //멀어지면 원래 머터리얼로 복구
        }
    }

    public void UpdateUI(int type, string name){
        if(type == 0){
            if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0]){
                notice.text = "PRESS [F] TO INTERACTION with " + "<#F2C46D>" + name + "</color>";
            }
            else{
                notice.text = "[F] 키를 눌러 " + "<#F2C46D>" + name + "</color>"+ " 와 상호작용";
            }
        }
        else if(type == 1){
            if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0]){
                notice.text = "PRESS [F] TO TALK WITH " + "<#F2C46D>" + name + "</color>";
            }
            else{
                notice.text = "[F] 키를 눌러 " + "<#F2C46D>" + name + "</color>" + " 와 대화";
            }
        }
        else if(type == 2){
            if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0]){
                notice.text = "PRESS [F] TO GET " + "<#F2C46D>" + name + "</color>";
            }
            else{
                notice.text = "[F] 키를 눌러 " + "<#F2C46D>" + name + "</color>" + " 획득";
            }
        }
    }
}