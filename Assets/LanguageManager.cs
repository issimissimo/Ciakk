using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Languages
{
    EN,
    FR,
}

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager instance;
    private Languages _language;
    public Languages language
    {
        get { return _language; }
        set
        {
            _language = value;
            CallOnLanguageChanged();
        }
    }
    [SerializeField] Languages startupLanguage;
    public event Action<Languages> onLanguageChanged;

    void Awake()
    {
        if (instance != null) Destroy(instance);
        instance = this;
    }

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        language = startupLanguage;
    }

    void CallOnLanguageChanged()
    {
        if (onLanguageChanged != null) onLanguageChanged.Invoke(language);
    }

}
