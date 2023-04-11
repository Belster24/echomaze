using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFadeOut : MonoBehaviour
{
public float fadeOutLength = 5f;
public float fadeStrength = 1f;
private float fade;
public bool fading;
CanvasGroup animateAlpha;
    private void Start()
    {
        fade = fadeOutLength;
        animateAlpha = GetComponent<CanvasGroup>();
        Invoke(nameof(StartFade), 5.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            Fade();
        }
    }
    void StartFade() =>  fading = true;
    void Fade()
    {
        if (fade>0)
        {
            fade = fadeStrength * Time.deltaTime;
            animateAlpha.alpha -= fade;
            
        }
        else
        {
            Destroy(this);
        }
    }
}
