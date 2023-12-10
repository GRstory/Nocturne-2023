using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Part4_level3 : MonoBehaviour
{
    public GameObject door;
    public GameObject openedDoor;
    public GameObject zipsa1;
    public GameObject zipsa2;
    public GameObject zipsa3;
    public GameObject zipsa4;
    public GameObject fadeOut;
    private void Start() {
        Invoke("DoorKnock", 3);
        Invoke("DoorOpen", 6);
        Invoke("Hugging", 9);
        Invoke("FadeOut", 12);
        Invoke("ChapterEnd", 15);
    }
    private void DoorKnock(){
        zipsa1.SetActive(false);
        zipsa2.SetActive(true);
    }
    private void DoorOpen(){
        door.SetActive(false);
        openedDoor.SetActive(true);
        zipsa2.SetActive(false);
        zipsa3.SetActive(true);
    }
    private void Hugging(){
        zipsa3.SetActive(false);
        zipsa4.SetActive(true);
    }

    private void FadeOut(){
        fadeOut.SetActive(true);
    }

    private void ChapterEnd(){
        SceneManager.LoadScene("PartEnd");
    }
}
