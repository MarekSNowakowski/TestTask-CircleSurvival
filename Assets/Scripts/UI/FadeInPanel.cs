using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeInPanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    [SerializeField]
    private float fadeTime;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        while(canvasGroup.alpha < 1)
        {
            if(fadeTime!=0)
            {
                canvasGroup.alpha += 1 / fadeTime * Time.unscaledDeltaTime;
            }
            yield return null;
        }
        canvasGroup.interactable = true;
    }
}
