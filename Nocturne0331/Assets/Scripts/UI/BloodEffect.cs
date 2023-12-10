using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodEffect : MonoBehaviour
{
    private Image blood;
    public float alpha;
    private void Awake() {
        blood = transform.GetComponent<Image>();
        float temp = 50/100;
        Debug.Log(temp);
    }
    private void Update() {
        if(GameManager.Instance.HEALTH <= 50){
            alpha = (100 - GameManager.Instance.HEALTH-50) * 0.02f;
            blood.color = new Color(0.3f, 0.3f, 0.3f, alpha);
        }
        else{
            blood.color = new Color(0.2f, 0.2f, 0.2f, 0.0f);
        }
    }
}
