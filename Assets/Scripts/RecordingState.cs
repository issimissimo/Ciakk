using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingState : State
{
    [SerializeField] WebcamManager webcamManager;
    
    public override void Enter(StateMachine stateMachine)
    {
        base.Enter(stateMachine);
    }


    public override void Exit()
    {
        base.Exit();
    }
    
    
    
    
}
