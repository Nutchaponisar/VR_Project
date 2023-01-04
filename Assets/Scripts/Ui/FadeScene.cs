using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScene : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 1;
    public Color fadeColor;
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        
        if (fadeOnStart)
        {
            FadeIn();
        }
    }
    public void FadeIn()
    {
        Fade(1, 0);
    }
    public void FadeOut()
    {
        Time.timeScale = 1;
        Fade(0, 1);
    }
    public void Fade(float alpahIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alpahIn, alphaOut));
    }
    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        rend.enabled = true;
        float timer = 0;
        while(timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            rend.material.SetColor("_Color",newColor);

            timer += Time.fixedDeltaTime;
            yield return null;
        }
        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor("_Color", newColor2);
        rend.enabled = false;
    }
}
