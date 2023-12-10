using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float idleTime = 0; //체력 감시 시간
    private float healTime = 0; //치유 쿨타임
    private int healthBackup = 100;
    private UiControl uiController;
    private void Awake() {
        uiController = transform.GetComponent<UiControl>();
    }
    private void Update() {
        if(GameManager.Instance.HEALTH <= 0){
            uiController.FailUI_ON();
        }

        if(healthBackup <= GameManager.Instance.HEALTH){
            idleTime += Time.deltaTime;

            if(idleTime >= 10f){ //10초이상 체력이 깎이지 않으면
                if(healTime >= 1.0f){ //1초마다 5씩 회복
                    GameManager.Instance.HEALTH += 5;
                    healTime = 0f;
                }
                else{
                    healTime += Time.deltaTime;
                }
            }
        }
        else{
            idleTime = 0f;
        }
        if(GameManager.Instance.HEALTH >= 100) GameManager.Instance.HEALTH = 100;
        healthBackup = GameManager.Instance.HEALTH;
    }
}
