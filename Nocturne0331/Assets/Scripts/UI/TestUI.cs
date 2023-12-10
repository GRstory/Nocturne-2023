using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TestUI : MonoBehaviour
{
    public Image imageW;
    public Image imageA;
    public Image imageS;
    public Image imageD;
    public Image imageSHIFT;
    public Image imageESC;
    public Image imageQ;
    public Image imageE;
    public Image imageF;
    public Image imageG;
    public TextMeshProUGUI today;

    private void Update() {
        today.text = System.DateTime.Now.ToString("yy/MM/dd-HH:mm:ss");
        if(Input.GetKey(KeyCode.W)){
            imageW.color = Color.yellow;
        }
        else imageW.color = Color.black;

        if(Input.GetKey(KeyCode.A)){
            imageA.color = Color.yellow;
        }
        else imageA.color = Color.black;
        if(Input.GetKey(KeyCode.S)){
            imageS.color = Color.yellow;
        }
        else imageS.color = Color.black;
        if(Input.GetKey(KeyCode.D)){
            imageD.color = Color.yellow;
        }
        else imageD.color = Color.black;
        if(Input.GetKey(KeyCode.Escape)){
            imageESC.color = Color.yellow;
        }
        else imageESC.color = Color.black;
        if(Input.GetKey(KeyCode.LeftShift)){
            imageSHIFT.color = Color.yellow;
        }
        else imageSHIFT.color = Color.black;
        if(Input.GetKey(KeyCode.Q)){
            imageQ.color = Color.yellow;
        }
        else imageQ.color = Color.black;
        if(Input.GetKey(KeyCode.E)){
            imageE.color = Color.yellow;
        }
        else imageE.color = Color.black;
        if(Input.GetKey(KeyCode.F)){
            imageF.color = Color.yellow;
        }
        else imageF.color = Color.black;
        if(Input.GetKey(KeyCode.G)){
            imageG.color = Color.yellow;
        }
        else imageG.color = Color.black;
    }

    public void cineMode(){
        GameManager.Instance.CINEMATIC_UI = ! GameManager.Instance.CINEMATIC_UI;
    }
    public void Part2(){
        SceneManager.LoadScene("Part2");
        GameManager.Instance.BGM_INDEX = 1;
        GameManager.Instance.BGM_INDEX_B = 1;
    }

    public void Part3(){
        SceneManager.LoadScene("Part3");
        GameManager.Instance.BGM_INDEX = 1;
        GameManager.Instance.BGM_INDEX_B = 1;
    }

    public void Part4(){
        SceneManager.LoadScene("Part4");
        GameManager.Instance.BGM_INDEX = 1;
        GameManager.Instance.BGM_INDEX_B = 1;
    }
}
