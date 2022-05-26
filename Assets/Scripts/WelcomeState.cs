using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeState : State
{
    [SerializeField] Button startButton;

    void Awake()
    {
        startButton.onClick.AddListener(() =>
        {
            gameManager.SetState(gameManager.recordingState, gameManager);
        });
    }

    public override void Enter(StateMachine stateMachine)
    {
        base.Enter(stateMachine);
    }


    public override void Exit()
    {
        base.Exit();
    }


}
