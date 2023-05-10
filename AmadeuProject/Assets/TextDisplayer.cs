using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDisplayer : MonoBehaviour
{
    private bool isDisplaying;

    [SerializeField]
    private TextMeshProUGUI uiText;

    [SerializeField]
    private float letterInterval = 0.1f;

    private void Start()
    {
        StartCoroutine(DisplayTextCoroutine("the quick brown fox jumps over the lazy dog..."));
    }

    public void DisplayText (string text)
    {
        if (!isDisplaying) 
        {
            StartCoroutine(DisplayTextCoroutine(text));
        }
    }

    private IEnumerator DisplayTextCoroutine (string text)
    {
        isDisplaying = true;
        uiText.text = "";

        yield return new WaitForSeconds(2.0f);

        for (int i = 0; i < text.Length; i++)
        {
            uiText.text += text[i];
            yield return new WaitForSeconds(letterInterval);
        }

        //yield return null;

        isDisplaying = false;
    }
}
