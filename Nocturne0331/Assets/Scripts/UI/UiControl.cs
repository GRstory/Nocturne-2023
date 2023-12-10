using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControl : MonoBehaviour
{
    public GameObject pauseUI; //1
    public GameObject settingUI; //2
    public GameObject exitUI; //3
    public GameObject dialogUI; //4
    public GameObject failUI; //5
    public GameObject choiceUI; //6
    public GameObject achiUI; // 7
    public GameObject player;
    private Animator movementAnimator;
    private void Awake() {
        movementAnimator = player.GetComponent<Animator>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            PressESC();
        }
    }

    public void PressESC(){
        if(GameManager.Instance.GAME_UI == 0){ //일반상태일때 pauseUI ON
                pauseUI.SetActive(true);
                Time.timeScale = 0;
                GameManager.Instance.GAME_UI = 1;
            }
            else if(GameManager.Instance.GAME_UI == 1){ //일시정지상태일때 pauseUI OFF
                pauseUI.SetActive(false);
                Time.timeScale = 1;
                GameManager.Instance.GAME_UI = 0;
            }
            else if(GameManager.Instance.GAME_UI == 2){ //설정 상태
                settingUI.SetActive(false);
                Time.timeScale = 0;
                GameManager.Instance.GAME_UI = 1;
            }
            else if(GameManager.Instance.GAME_UI == 3){ //종료 상태
                exitUI.SetActive(false);
                Time.timeScale = 0;
                GameManager.Instance.GAME_UI = 1;
            }
            else if(GameManager.Instance.GAME_UI == 4){ //대화 상태
                dialogUI.SetActive(false);
                Time.timeScale = 1;
                movementAnimator.SetBool("freeze", false);
                GameManager.Instance.GAME_UI = 0;
            }
            else if(GameManager.Instance.GAME_UI == 7){ //도전과제-pause
                achiUI.SetActive(false);
                GameManager.Instance.GAME_UI = 1;
            }
            else if(GameManager.Instance.GAME_UI == 8){ //도전과제 on
                achiUI.SetActive(false);
                GameManager.Instance.GAME_UI = 0;
            }
            else if (GameManager.Instance.GAME_UI == 10){ //Cinematic 상태
                GameManager.Instance.GAME_UI = 11;
                Time.timeScale = 0;
                pauseUI.SetActive(true);
            }
            else if (GameManager.Instance.GAME_UI == 11){ //Cinematic 일시정지 상태
                GameManager.Instance.GAME_UI = 10;
                Time.timeScale = 1;
                pauseUI.SetActive(false);
            }
    }

    public void SettingUI_ON(){
        GameManager.Instance.GAME_UI = 2;
        Time.timeScale = 0;
        settingUI.SetActive(true);
    }

    public void SettingUI_OFF(){
        GameManager.Instance.GAME_UI = 0;
        Time.timeScale = 1;

        settingUI.GetComponent<SettingUI>().SaveSetting();
        settingUI.SetActive(false);
    }
    public void SettingUI_PAUSE(){
        GameManager.Instance.GAME_UI = 1;
        settingUI.GetComponent<SettingUI>().SaveSetting();
        settingUI.SetActive(false);
    }
    public void ExitUI_ON(){
        GameManager.Instance.GAME_UI = 3;
        Time.timeScale = 0;
        exitUI.SetActive(true);
    }

    public void ExitUI_OFF(){
        GameManager.Instance.GAME_UI = 0;
        Time.timeScale = 1;
        exitUI.SetActive(false);
    }

    public void ExitUI_PAUSE(){
        GameManager.Instance.GAME_UI = 1;
        exitUI.SetActive(false);
    }
    public void ExitUI_YES(){ //종료 버튼
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void FailUI_ON(){
        GameManager.Instance.GAME_UI = 5;
        Time.timeScale = 0;
        failUI.SetActive(true);
        GameManager.Instance.BGM_INDEX = 3;
    }
    public void FailUI_OFF(){
        GameManager.Instance.GAME_UI = 0;
        Time.timeScale = 1;

        SavePoint.Instance.GoSavePoint();
        failUI.SetActive(false);
        GameManager.Instance.HEALTH = 100;
        GameManager.Instance.TIME_DIE += 1;
        GameManager.Instance.BGM_INDEX = GameManager.Instance.BGM_INDEX_B;
    }
    public void FailUI_PAUSE(){
        GameManager.Instance.GAME_UI = 1;
        failUI.SetActive(false);
    }
    public void AchiUI_ON(){
        GameManager.Instance.GAME_UI = 7;
        achiUI.SetActive(true);
    }
    public void AchiUI_OFF(){
        GameManager.Instance.GAME_UI = 0;
        achiUI.SetActive(false);
    }
    public void AchiUI_PAUSE(){
        GameManager.Instance.GAME_UI = 1;
        achiUI.SetActive(false);
    }

}
