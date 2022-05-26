using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


[RequireComponent(typeof(CanvasGroup))]
public class HideWhileTextIsEmpty : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    [SerializeField] Text text;


    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }


    IEnumerator Start()
    {
        yield return new WaitUntil(() => !string.IsNullOrEmpty(text.text));
        canvasGroup.alpha = 1;
    }


    void Update()
    {

    }
}
