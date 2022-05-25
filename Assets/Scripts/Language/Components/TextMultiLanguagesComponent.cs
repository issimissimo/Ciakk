using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextMultiLanguagesComponent : MonoBehaviour
{

    /// To show in Inspector
    [Serializable]
    public struct MultiText
    {
        public Languages language;
        [TextArea] public string text;
    }
    public MultiText[] multiText;



    /// Private
    private Text originalText;
    Dictionary<Languages, string> langDict = new Dictionary<Languages, string>();


    void Awake()
    {
        originalText = GetComponent<Text>();

        /// Put all the lang/text in a Dictionary
        foreach (MultiText mt in multiText)
        {
            langDict[mt.language] = mt.text;
        }
    }

    void OnEnable()
    {
        /// Switch on enable
        if (LanguageManager.instance)
            ChangeTextOnLanguage(LanguageManager.instance.language);
    }


    void Start()
    {
        /// Register
        LanguageManager.instance.onLanguageChanged += ChangeTextOnLanguage;
    }


    void ChangeTextOnLanguage(Languages lang)
    {
        /// Set new text
        string newText = langDict[lang];
        originalText.text = newText;

        /// Check if in the Parent there's a "ContentFitterRefresh" component,
        /// so that we have to refresh the content size fitter
        ContentFitterRefresh refresher = gameObject.GetComponentInParent<ContentFitterRefresh>();
        if (refresher != null) refresher.RefreshContentFitters();
    }
}
