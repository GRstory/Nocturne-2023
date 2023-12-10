using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Part1_Map2 : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;
    public GameObject scene4;
    public GameObject scene5;
    public GameObject scene6;
    public GameObject scene7;
    private void Start() {
        Invoke("Scene2", 6);
        Invoke("Scene3", 9);
        Invoke("Scene4", 12);
        Invoke("Scene5", 16);
        Invoke("Scene6", 19);
        Invoke("Scene7", 23);
        Invoke("BlackOut", 28);
    }
   
    private void Scene2(){
        scene1.SetActive(false);
        scene2.SetActive(true);
    }
    private void Scene3(){
        scene2.SetActive(false);
        scene3.SetActive(true);
    }
    private void Scene4(){
        scene3.SetActive(false);
        scene4.SetActive(true);
    }
    private void Scene5(){
        scene4.SetActive(false);
        scene5.SetActive(true); 
    }
    private void Scene6(){
        scene5.SetActive(false);
        scene6.SetActive(true);
    }
    private void Scene7(){
        scene6.SetActive(false);
        scene7.SetActive(true);
    }
    

    private void BlackOut(){
        fadeOut.SetActive(true);
        Invoke("Part2", 3);
    }
    private void Part2(){
        GameManager.Instance.BGM_INDEX = 6;
        GameManager.Instance.BGM_INDEX_B = 6;
        GameManager.Instance.SAVE_PART = 2;
        GameManager.Instance.CINEMATIC_UI = false;
        GameManager.Instance.Q_CAM_INDEX = 0;
        SceneManager.LoadScene("Part2");
    }
}
