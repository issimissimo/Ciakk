using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Utils
{
    [RequireComponent(typeof(CanvasController))]
    public class HideWhileTextIsEmpty : MonoBehaviour
    {
        private CanvasController canvasController;
        [SerializeField] Text text;


        void Awake()
        {
            canvasController = GetComponent<CanvasController>();
            canvasController.Hide();
        }


        IEnumerator Start()
        {
            yield return new WaitUntil(() => !string.IsNullOrEmpty(text.text));
            canvasController.Show();
        }


        void Update()
        {

        }
    }

}
