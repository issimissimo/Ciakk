using UnityEngine;
using UI.Utils;

public abstract class State : MonoBehaviour
{
    protected GameManager gameManager;
    [SerializeField] protected CanvasController panel;

    private void Awake()
    {
        if (panel) panel.Hide();
    }
    
    public virtual void Enter(StateMachine stateMachine)
    {
        if (stateMachine is GameManager)
        {
            gameManager = stateMachine as GameManager;

            Debug.Log($"Enter -> {this.GetType().Name}");
        }
        else
        {
            Debug.LogError("StateMachine parameter is not valid!");
        } 

        if (panel) panel.Show(); 
    }

    public virtual void Exit()
    {
        if (panel) panel.Hide();
    }
}
