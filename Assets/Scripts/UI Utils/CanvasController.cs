using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Utils
{
    [RequireComponent(typeof(CanvasGroup))]
    
    public class CanvasController : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        
        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        
        public void Hide(){
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        public void Show(){
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }

}
