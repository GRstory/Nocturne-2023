using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings;

public class StatUI : MonoBehaviour
{
    public List<TextMeshProUGUI> textList = new List<TextMeshProUGUI>(){};
    private void OnEnable() {
        RefreshData();
    }
    private void RefreshData(){
        if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0]){//영어
            textList[0].text = System.Math.Truncate(Time.realtimeSinceStartup/60).ToString() + '"'+ "  " + System.Math.Truncate(Time.realtimeSinceStartup%60).ToString() + "'";
            textList[1].text = "PART" + (GameManager.Instance.SAVE_PART).ToString();
            textList[2].text = System.Math.Truncate(GameManager.Instance.TIME_IDLE / 60).ToString() + '"'+ "  " + (GameManager.Instance.TIME_IDLE%60).ToString() + "'";
            textList[3].text = (GameManager.Instance.TIME_MEOW).ToString() + "TIMES";
            textList[4].text = (GameManager.Instance.TIME_SCRATCH).ToString() + "TIMES";
            textList[5].text = (Time.realtimeSinceStartup - GameManager.Instance.TIME_IDLE * 2).ToString() + "M";
            textList[6].text = (GameManager.Instance.TIME_DIE).ToString() + "TIMES";
        }
        if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1]){//한글
            textList[0].text = System.Math.Truncate(Time.realtimeSinceStartup/60).ToString() + '"'+ "  " + System.Math.Truncate(Time.realtimeSinceStartup%60).ToString() + "'";
            textList[1].text = "파트" + (GameManager.Instance.SAVE_PART).ToString();
            textList[2].text = System.Math.Truncate(GameManager.Instance.TIME_IDLE/60).ToString() + '"'+ "  " + (GameManager.Instance.TIME_IDLE%60).ToString() + "'";
            textList[3].text = (GameManager.Instance.TIME_MEOW).ToString() + "번";
            textList[4].text = (GameManager.Instance.TIME_SCRATCH).ToString() + "번";
            textList[5].text = (Time.realtimeSinceStartup - GameManager.Instance.TIME_IDLE * 2).ToString() + "미터";
            textList[6].text = (GameManager.Instance.TIME_DIE).ToString() + "번";
        }
    }
}
