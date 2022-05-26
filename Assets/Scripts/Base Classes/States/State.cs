using UnityEngine;
public abstract class State : MonoBehaviour
{
    protected GameManager gameManager;
    [SerializeField] protected GameObject panel;

    private void Awake()
    {
        if (panel) panel.SetActive(false);
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

        if (panel) panel.SetActive(true); 
    }

    public virtual void Exit()
    {
        if (panel) panel.SetActive(false);
    }
}
