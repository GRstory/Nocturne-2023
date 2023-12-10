using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Part4_Level4 : MonoBehaviour
{
    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;
    public GameObject scene4;
    public GameObject scene5;
    public GameObject scene6;
    public GameObject scene7;
    public GameObject grassObjects;
    public GameObject fadeOut;
    private void Start() {
        Invoke("Scene2", 2);
        Invoke("Scene3", 4);
        Invoke("Scene4", 6);
        Invoke("Scene5", 8);
        Invoke("Scene6", 10);
        Invoke("Scene7", 12);
        Invoke("FadeOut", 15);
        Invoke("ChapterEnd", 18);

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
        grassObjects.SetActive(true);
    }
    private void Scene6(){
        scene5.SetActive(false);
        scene6.SetActive(true);
    }
    private void Scene7(){
        scene6.SetActive(false);
        scene7.SetActive(true);
    }
    private void FadeOut(){
        fadeOut.SetActive(true);
    }
    private void ChapterEnd(){
        SceneManager.LoadScene("PartEnd");
    }
}
