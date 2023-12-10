using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image image;
    private float fadeOutDuration = 3f;

    private float currentAlpha = 0f;

    private void Start(){
        image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);
    }

    private void Update(){
        currentAlpha += Time.deltaTime / fadeOutDuration;
        image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);
    }
}
