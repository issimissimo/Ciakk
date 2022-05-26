using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using NatSuite.Recorders;
using NatSuite.Recorders.Clocks;
using System.Threading.Tasks;


public class WebcamManager : MonoBehaviour
{

    [Header(@"UI")]
    public RawImage rawImage;
    public AspectRatioFitter aspectFitter;

    private WebCamTexture webCamTexture;
    private MP4Recorder recorder;
    private IClock clock;
    private bool recording;
    private Color32[] pixelBuffer;


    private Action onFinishedCallback;
    private float initTime;




    public async void StartRecording(int duration, Action callback)
    {
        Debug.Log("Start recording for " + duration + " seconds...");
        onFinishedCallback = callback;
        webCamTexture.Play();
        rawImage.enabled = true;

        // Start recording
        clock = new RealtimeClock();
        recorder = new MP4Recorder(webCamTexture.width, webCamTexture.height, 30, videoBitRate: 6_000_000);
        pixelBuffer = webCamTexture.GetPixels32();
        recording = true;

        await Task.Delay(duration * 1000);

        Debug.Log("Stop recording");
        StopRecording();
    }

    public async void StopRecording()
    {
        // Stop recording
        recording = false;

        webCamTexture.Stop();

        var path = await recorder.FinishWriting();
        // Playback recording
        Debug.Log($"Saved recording to: {path}");

        string[] splitArray = path.Split(char.Parse("/"));

        //System.IO.File.Move
        Debug.Log(Path.GetFileName(path));
        Debug.Log(Path.GetDirectoryName(path));
        string folder = Path.GetDirectoryName(path);
        string newPath = Path.Combine(folder, "ciao.mp4");
        // System.IO.File.Move(path, string.Concat(folder, "ciao.mp4"));
        Debug.Log(newPath);
        System.IO.File.Move(path, newPath);


        onFinishedCallback.Invoke();
    }





    IEnumerator Start()
    {
        Application.targetFrameRate = 60;
        
        rawImage.enabled = false;

        // Request camera permission
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
            yield break;
        
        
        // Start the WebCamTexture
        webCamTexture = new WebCamTexture(1280, 720, 30);

        // Display webcam
        yield return new WaitUntil(() => webCamTexture.width != 16 && webCamTexture.height != 16); // Workaround for weird bug on macOS
        rawImage.texture = webCamTexture;
        aspectFitter.aspectRatio = (float)webCamTexture.width / webCamTexture.height;
    }



    void Update()
    {
        // Record frames from the webcam
        if (recording && webCamTexture.didUpdateThisFrame)
        {
            webCamTexture.GetPixels32(pixelBuffer);
            recorder.CommitFrame(pixelBuffer, clock.timestamp);
        }
    }
}
