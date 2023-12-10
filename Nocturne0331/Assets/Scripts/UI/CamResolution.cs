using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamResolution : MonoBehaviour
{
    private void Awake() {
        Camera cam = GetComponent<Camera>();

        Rect rt = cam.rect;
        float scaleHeight = (Screen.width / Screen.height) / (16 / 9);
        float scaleWidth = 1f / scaleHeight;

        if(scaleHeight < 1){
            rt.height = scaleHeight;
            rt.y = (1f - scaleHeight) / 2f;
        }
        else{
            rt.width = scaleWidth;
            rt.x = (1f - scaleWidth) / 2f;
        }

        cam.rect = rt;
    }
}
