using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingState : State
{
    [SerializeField] WebcamManager webcamManager;
    [SerializeField] int recordingDuration = 30;

    public override void Enter(StateMachine stateMachine)
    {
        base.Enter(stateMachine);

        webcamManager.StartRecording(recordingDuration, () =>
        {
            gameManager.SetState(gameManager.welcomeState, gameManager);
        });
    }


    public override void Exit()
    {
        base.Exit();
    }




}
