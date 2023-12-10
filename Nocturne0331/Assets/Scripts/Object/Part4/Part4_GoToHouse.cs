using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part4_GoToHouse : MonoBehaviour
{
    public GameObject level3;
    public GameObject level4;
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.CompareTag("Player")){
            GameManager.Instance.CINEMATIC_UI = true;
            if(GameManager.Instance.TIME_DIE <= 8){
                level3.SetActive(true);
                GameManager.Instance.CINEMATIC_UI = true;
            }
            else{
                level4.SetActive(true);
                GameManager.Instance.CINEMATIC_UI = true;
            }
        }
    }
}
