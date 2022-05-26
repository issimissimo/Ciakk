using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State currentState;
    
    public void SetState<T>(State state, T stateMachine) where T : StateMachine
    {
        if (currentState) currentState.Exit();

        currentState = state;

        currentState.Enter(stateMachine);
    }
}
