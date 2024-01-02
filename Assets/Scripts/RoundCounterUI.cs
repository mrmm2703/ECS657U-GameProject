using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundCounterUI : MonoBehaviour
{
    private string[] texts;
    private Coroutine[] coroutines;
    public TMP_Text[] textsTMP;

    // Start is called before the first frame update
    void Start()
    {
        texts = new string[textsTMP.Length];
        coroutines = new Coroutine[textsTMP.Length];
    }

    public void ShowText(int textNumber, string textToShow, float duration = 2f)
    {
        if (textNumber < texts.Length)
        {
            Debug.Log("Showing text: " + textToShow);
            texts[textNumber] = textToShow;
            textsTMP[textNumber].SetText(textToShow);
            if (coroutines[textNumber] != null) StopCoroutine(coroutines[textNumber]);
            coroutines[textNumber] = StartCoroutine(HideText(textNumber, duration));
        } else
        {
            Debug.Log("Text index out of bound!");
        }
    }

    private IEnumerator HideText(int textNumber, float delay = 2f)
    {
        yield return new WaitForSeconds(delay);
        textsTMP[textNumber].SetText("");
    }
}
