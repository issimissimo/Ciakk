using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeToEn(){
        LanguageManager.instance.language = Languages.EN;
    }

    public void changeToFr(){
        LanguageManager.instance.language = Languages.FR;
    }
}
