using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings;

public class InteractionableObject : MonoBehaviour
{
    [Header("0: 오브젝트, 1: NPC, 2: 아이템")]
    [SerializeField] public int type; //0: 오브젝트, 1: NPC, 2: 아이템
    [Header("1: NPC ID")]
    [SerializeField] public int id;
    [Header("0: 컴포넌트 이름, 1: NPC ID")]
    [SerializeField] private string myName = "initName";
    public GameObject player;
    public GameObject dialogUI;
    private TextMeshProUGUI dialogUI_Name;
    private TextMeshProUGUI dialogUI_Dialog;
    
    private void Awake() {
        if(type == 1){
            dialogUI_Name = dialogUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            dialogUI_Dialog = dialogUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        }
        
    }

    public void Interact(GameObject go, int index){ //상호작용 활성화
        if(type == 0) InteractObject();
        if(type == 1) InteractNpc(id, index);
        if(type == 2) InteractItem(go);
    }

    private void InteractObject(){
        Type type = Type.GetType(myName);
        Component temp = GetComponent(type);
        MethodInfo interactMethod = type.GetMethod("Interaction");
        interactMethod.Invoke(temp, null);
        
        //Debug.Log(myName + "과 상호작용 시도");
    }
    private void InteractNpc(int id, int index){
        GameManager.Instance.GAME_UI = 4;
        dialogUI.SetActive(true);
        Time.timeScale = 0;
        dialogUI_Name.text = myName;
        if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1]) dialogUI_Dialog.text = player.GetComponent<TalkManager>().GetTalk(id, index);
        else dialogUI_Dialog.text = player.GetComponent<TalkManager>().GetTalk(id + 1000, index);
        
    }
    private void InteractItem(GameObject go){
        GameManager.Instance.ITEMLIST.Add(myName); //먹은 아이템 추가
        Destroy(go); // 아이템 오브젝트를 삭제
    }


}
