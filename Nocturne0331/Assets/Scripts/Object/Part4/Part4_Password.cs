using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

public class Part4_Password : MonoBehaviour
{
    public List<bool> password = new List<bool>();
    public List<bool> userword = new List<bool>();
    public GameObject lcd;
    public GameObject closedDoorL;
    public GameObject closedDoorR;
    public GameObject openedDoorL;
    public GameObject openedDoorR;
    public Light streetLight;
    private bool flag = false;
    private void Update() {
        if(!flag && ComparePassword()){
            lcd.GetComponent<LocalizeStringEvent>().StringReference.SetReference("Part4", "Part4_1_Correct");

            closedDoorL.SetActive(false);
            closedDoorR.SetActive(false);
            openedDoorL.SetActive(true);
            openedDoorR.SetActive(true);
            streetLight.color = new Color(0.25f, 0.66f, 1.0f);
        }
    }

    private bool ComparePassword(){
        if(flag) {
            return false;
        }
        else{
            for(int i=0; i <10; i++){
                if(password[i] != userword[i]){
                    return false;
                }
            }
            flag = true;
            return true;
        }
        
    }
}
