using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Components;
using TMPro;

public class AchiUI : MonoBehaviour
{
    public int mode = 2;
    public GameObject achievementUI;
    public GameObject title;
    public GameObject contents;
    public GameObject exitBtn1; //일시정지로 돌아가기
    public GameObject exitBtn2; //게임으로 돌아가기
    private Animator contentsController;
    public List<GameObject> achievementText = new List<GameObject>() {};
    public List<GameObject> achievementTitle = new List<GameObject>() {};
    public List<GameObject> achievementImage = new List<GameObject>() {};
    public GameObject collectText;
    private TextMeshProUGUI collectList;

    private void Awake() {
        contentsController = contents.GetComponent<Animator>();
        collectList = collectText.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable() {
        mode = 2;
        title.GetComponent<LocalizeStringEvent>().StringReference.SetReference("LocalizeText", "UI_ACHI_mode"+mode);

        if(GameManager.Instance.GAME_UI == 7){ //일시정지 모드로 진입
            exitBtn1.SetActive(true);
            exitBtn2.SetActive(false);
        }
        if(GameManager.Instance.GAME_UI == 8){ //일반 진입
            exitBtn1.SetActive(false);
            exitBtn2.SetActive(true);
        }

        RefreshAchievement();
        CollectItems();
    }
    public void SetTitleLower(){
        if(mode > 1){
            mode -= 1;
            contentsController.SetInteger("mode", mode);

            title.GetComponent<LocalizeStringEvent>().StringReference.SetReference("LocalizeText", "UI_ACHI_mode"+mode);
        }
    }

    public void SetTitleHigher(){
        if(mode < 3){
            mode += 1;
            contentsController.SetInteger("mode", mode);
            
            title.GetComponent<LocalizeStringEvent>().StringReference.SetReference("LocalizeText", "UI_ACHI_mode"+mode);
        }
    }
    public void AchiUI_ON(){
        GameManager.Instance.GAME_UI = 8;
        achievementUI.SetActive(true);
        contentsController.SetInteger("mode", 2);
    }
    public void AchiUI_OFF(){
        GameManager.Instance.GAME_UI = 0;
        achievementUI.SetActive(false);
    }
    public void AchiUI_PAUSE(){
        GameManager.Instance.GAME_UI = 1;
        achievementUI.SetActive(false);
    }

    public void RefreshAchievement(){
        for(int i = 0; i < 12; i++){
            if(!GameManager.Instance.ACHIEVEMENT[i]){
                achievementText[i].GetComponent<LocalizeStringEvent>().StringReference.SetReference("Achievement", "achi_"+0);
                achievementTitle[i].GetComponent<LocalizeStringEvent>().StringReference.SetReference("Achievement", "achi_t"+0);
                achievementImage[i].GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f);
            }
            else{
                achievementText[i].GetComponent<LocalizeStringEvent>().StringReference.SetReference("Achievement", "achi_"+(i+1));
                achievementTitle[i].GetComponent<LocalizeStringEvent>().StringReference.SetReference("Achievement", "achi_t"+(i+1));
                achievementImage[i].GetComponent<Image>().color = new Color(1, 1, 1);
            }
        }
    }
    
    public void CollectItems(){
        int x = GameManager.Instance.ITEMLIST.Count;
        string t = "";

        if(x != 0){
            Destroy(collectText.GetComponent<LocalizeStringEvent>());
            for(int i = 0; i < x; i++){
                Debug.Log(i + "x");
                t += GameManager.Instance.ITEMLIST[i];
                t += "\n";
            }
            collectList.text = t;
        }
    }

}
