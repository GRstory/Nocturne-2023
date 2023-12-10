using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainTitle : MonoBehaviour
{
    private float time = 0f;
    public float buttonTime = 0f;
    public GameObject startText;
    public GameObject exitText;
    public GameObject startButton;
    public GameObject exitButton;
    public GameObject upperSet;
    public GameObject buttonSet;
    private TextMeshProUGUI text1;
    private TextMeshProUGUI text2;
    private Rigidbody rb;
    private Animator animator;
    private Animator upLogo;
    private Animator dwLogo;
    private Animator mdLogo;
    private Animator btSet;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
        text1 = startText.GetComponent<TextMeshProUGUI>();
        text2 = exitText.GetComponent<TextMeshProUGUI>();

        upLogo = upperSet.transform.GetChild(0).GetComponent<Animator>();
        dwLogo = upperSet.transform.GetChild(1).GetComponent<Animator>();
        mdLogo = upperSet.transform.GetChild(2).GetComponent<Animator>();
        btSet = buttonSet.GetComponent<Animator>();
    }
    private void Update(){
        time += Time.deltaTime;
        animator.SetFloat("time", time);
        if(time > 2.6){
            upLogo.SetBool("check", true);
            dwLogo.SetBool("check", true);
            btSet.SetBool("check", true);
        }
        if(time > 0.3f) mdLogo.SetBool("check", true);

        text1.color = new Color(buttonTime/2, buttonTime/2, buttonTime/2);
        text2.color = new Color(buttonTime/2, buttonTime/2, buttonTime/2);

        if(Input.GetKey(KeyCode.Return)){
            startText.SetActive(true);
            exitButton.SetActive(false);

            startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.8f, 0.8f, 0.8f);
            startButton.transform.GetChild(1).GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);
            buttonTime += Time.deltaTime;
            if(buttonTime >= 2) StartButton();
        }
        else if(Input.GetKey(KeyCode.Escape)){
            exitText.SetActive(true);
            startButton.SetActive(false);

            exitButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.8f, 0.8f, 0.8f);
            exitButton.transform.GetChild(1).GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);
            buttonTime += Time.deltaTime;
            if(buttonTime >= 2) ExitButton();
        }
        else if(!Input.GetKey(KeyCode.Return) & !Input.GetKeyDown(KeyCode.Escape)){
            startButton.SetActive(true);
            exitButton.SetActive(true);
            startText.SetActive(false);
            exitText.SetActive(false);

            startButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1.0f, 1.0f, 1.0f);
            exitButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1.0f, 1.0f, 1.0f);
            startButton.transform.GetChild(1).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
            exitButton.transform.GetChild(1).GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
            buttonTime = 0;
        }
        if(time <= 13){
            rb.MovePosition(transform.position + new Vector3(0, 0, 0.0022f));
        }
    }
    public void StartButton(){
        upLogo.SetBool("check", false);
        dwLogo.SetBool("check", false);
        btSet.SetBool("check", false);
        mdLogo.SetBool("check", false);
        
        StartCoroutine(UpdateEvent());
        UpdateEvent();
    }
    public void ExitButton(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    IEnumerator UpdateEvent(){

        yield return new WaitForSecondsRealtime(3.0f);
        
        SceneManager.LoadScene("Part1");
        GameManager.Instance.BGM_INDEX = 1;
        GameManager.Instance.BGM_INDEX_B = 1;
    }
}
