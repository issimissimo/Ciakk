using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StateMachine
{
    public WelcomeState welcomeState;
    public RecordingState recordingState;
    
    
    
    void Start()
    {
        SetState(welcomeState, this);
    }

    
}
