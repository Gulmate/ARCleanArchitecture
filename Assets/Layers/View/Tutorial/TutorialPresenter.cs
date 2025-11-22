using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class TutorialPresenter : MonoBehaviour
{
    private TutorialUseCase tutorialUseCase = new TutorialUseCase();

    private List<Texture2D> images = new List<Texture2D>();
    private int currentImageIndex = 0;

    private string videoPath;
    private string audioPath;
    private string text;

    public void NextStep()
    {
        tutorialUseCase.NextStep();
        loadImages();
    }

    public void Start()
    {
        tutorialUseCase.loggerSetup();
    }

    public void PrevStep()
    {
        tutorialUseCase.PrevStep();
        loadImages();
    }

    public void loadImages()
    {
        List<PicData> stepImageDatas = tutorialUseCase.GetCurrentStep().Images;
        foreach (PicData stepImage in stepImageDatas)
        {
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(stepImage.data);
        }
    }

    public Step LoadTutorial(string zipPath)
    {
        tutorialUseCase.LoadTutorial(zipPath);
        return tutorialUseCase.GetCurrentStep();
    }

    public Texture2D GetCurrentPic()
    {
        return images[currentImageIndex];
    }

    public Texture2D GetNextPic()
    {
        currentImageIndex++;
        return images[currentImageIndex];
    }

    public Texture2D GetPrevPic()
    {
        currentImageIndex--;
        return images[currentImageIndex];
    }

    public string GetVideo()
    { 
        return videoPath; 
    }

    //TODO le vinni infrastrukturaba
    public async Task<AudioClip> GetAudio()
    {
        string url = Path.Combine("file://", audioPath);

        using (var audioRequest = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG))
        {
            var operation = audioRequest.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();

            if (audioRequest.result == UnityWebRequest.Result.Success)
            {
                return DownloadHandlerAudioClip.GetContent(audioRequest);
            }
            else
            {
                Debug.LogError("Audio load failed: " + audioRequest.error);
                return null;
            }
        }
    }

    public string GetText()
    {
        return text;
    }

    public void TakeScreenshot()
    {
        string screenshotPath = Application.persistentDataPath + "/screenshot_placeholder.png";
        ScreenCapture.CaptureScreenshot("Assets/screenshot_placeholder.png");
        StartCoroutine(SaveScreenshotWhenReady(screenshotPath));
    }

    private IEnumerator SaveScreenshotWhenReady(string screenshotPath)
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log(screenshotPath);
        while (!File.Exists(screenshotPath))
            yield return null;

        tutorialUseCase.TakeScreenshot(screenshotPath);
        File.Delete(screenshotPath);
    }
}
