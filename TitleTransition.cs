using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleTransition : MonoBehaviour
{

    public Canvas titleScreen;
    public Canvas mainMenu;
    bool buttonPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !buttonPressed)
        {
            buttonPressed = true;
            StartCoroutine(DoFade());
            StartCoroutine(FadeIn());
        }  
    }

    IEnumerator DoFade()
    {
        
        CanvasGroup canvasGroup = titleScreen.GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        titleScreen.gameObject.SetActive(false);
        yield return null;
    }

    IEnumerator FadeIn()
    {
        CanvasGroup canvasGroup = mainMenu.GetComponent<CanvasGroup>();
        canvasGroup.interactable = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / 2;
            yield return null;
        }
        yield return null;
    }

}
