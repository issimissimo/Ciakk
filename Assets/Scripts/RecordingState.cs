using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecordingState : State
{
    [SerializeField] WebcamManager webcamManager;
    [SerializeField] int recordingDuration = 30;
    [SerializeField] string fileName = "record";

    public override void Enter(StateMachine stateMachine)
    {
        base.Enter(stateMachine);

        webcamManager.StartRecording(recordingDuration, (filePath) =>
        {
            /// On end change name and folder of the video
            string folder = Application.streamingAssetsPath;
            string newPath = Path.Combine(folder, fileName + ".mp4");

            if (File.Exists(newPath)) File.Delete(newPath);

            File.Move(filePath, newPath);

            /// Return to home
            gameManager.SetState(gameManager.welcomeState, gameManager);
        });
    }


    public override void Exit()
    {
        base.Exit();
    }
}
