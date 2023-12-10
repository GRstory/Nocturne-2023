using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using TMPro;

public class SettingUI : MonoBehaviour
{
    public int mode = 2;
    public GameObject title;
    public GameObject contents;
    private Animator contentsController;
    public bool isActive = false;
    public Toggle fullScreenMode; //전체화면 토글
    public Slider refreshSlider; //프레임레이트 슬라이더
    public TMP_Dropdown resoDropdown; //해상도 드롭다운
    private List<Resolution> reso = new List<Resolution>();
    private int resolutionNum = 0;
    public int refreshRate = 60;
    private FullScreenMode screenMode;
    public TextMeshProUGUI refreshRateText;
    private void Awake() {
        contentsController = contents.GetComponent<Animator>();
        
        InitReso();
    }

    private void OnEnable() {
        contentsController.SetInteger("mode", mode);

        title.GetComponent<LocalizeStringEvent>().StringReference.SetReference("Setting", "Set_Mode" + mode);
    }

    public void SetModeLower(){
        if(mode > 1){
            mode -= 1;
            contentsController.SetInteger("mode", mode);

            title.GetComponent<LocalizeStringEvent>().StringReference.SetReference("Setting", "Set_Mode" + mode);
        }
    }

    public void SetModeHigher(){
        if(mode < 3){
            mode += 1;
            contentsController.SetInteger("mode", mode);

            title.GetComponent<LocalizeStringEvent>().StringReference.SetReference("Setting", "Set_Mode" + mode);
        }
    }

    public void SetLanguage(int index){
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    public void InitReso(){
        reso.AddRange(Screen.resolutions);
        resoDropdown.options.Clear();

        foreach(Resolution item in reso){
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + "x" + item.height;
            resoDropdown.options.Add(option);

            if(item.width == Screen.width && item.height == Screen.height){
                resoDropdown.value = resolutionNum;
            }
            resolutionNum ++;
        }
        resoDropdown.RefreshShownValue();

        fullScreenMode.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void FullScreenButton(bool x){
        screenMode = x ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }
    public void SetResolutionNum(int x){
        resolutionNum = x;
    }
    public void SetRefreshRateText(){
        refreshRate = (int) refreshSlider.value;
        refreshRateText.text = refreshRate + "Hz";
        
    }
    public void SaveSetting(){
        try{
            Screen.SetResolution(reso[resolutionNum].width, reso[resolutionNum].height, screenMode, refreshRate);
        }
        catch{
            Screen.SetResolution(Screen.width, Screen.height, screenMode, refreshRate);
        }
        
    }
}
