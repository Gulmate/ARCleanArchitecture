using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TutorialPresenter : MonoBehaviour
{
    private TutorialUseCase tutorialUseCase = new TutorialUseCase();
    private DetectUseCase detectUseCase;

    private List<Texture2D> images = new List<Texture2D>();
    private int currentImageIndex = 0;

    private string audioPath;

    public void NextStep()
    {
        tutorialUseCase.NextStep();
        loadImages();
    }

    public void Start()
    {
        //tutorialUseCase.loggerSetup();
    }

    public void PrevStep()
    {
        tutorialUseCase.PrevStep();
        loadImages();
    }

    public void loadImages()
    {
        List<PicData> stepImageDatas = tutorialUseCase.GetCurrentStep().Images;
        List<Texture2D> loadedImages = new List<Texture2D>();
        currentImageIndex = 0;
        foreach (PicData stepImage in stepImageDatas)
        {
            
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(stepImage.data);
            loadedImages.Add(texture);
        }
        images = loadedImages;
    }

    public Step LoadTutorial(string zipPath)
    {
        tutorialUseCase.LoadTutorial(zipPath);
        loadImages();
        return tutorialUseCase.GetCurrentStep();
    }

    public Texture2D GetCurrentPic()
    {
        if(images.Count==0)
            return null;
        return images[currentImageIndex];
    }

    public Texture2D GetNextPic()
    {
        if(images.Count<=currentImageIndex)
            return null;
        currentImageIndex++;
        return images[currentImageIndex];
    }

    public Texture2D GetPrevPic()
    {
        if(currentImageIndex<=0)
            return null;
        currentImageIndex--;
        return images[currentImageIndex];
    }

    public int GetCurrentStepNumber()
    {
        return tutorialUseCase.GetCurrentStep().StepNumber;
    }

    public string GetVideo()
    {
        return tutorialUseCase.GetCurrentStep().Video;
    }

    public bool IsFirstStep()
    {
        return tutorialUseCase.isFirstStep();
    }

    public bool IsLastStep()
    {
        return tutorialUseCase.isLastStep();
    }

    public async Task<AudioClip> GetAudio()
    {
        audioPath=GetAudioPath();
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

    public string GetAudioPath()
    {
        return tutorialUseCase.GetCurrentStep().Audio;
    }

    public void AddImageToDetect()
    {
        Texture2D imageToAdd = new Texture2D(2, 2);

        /*using (var stream = File.Open(Path.Combine(Application.streamingAssetsPath, "qrtest.png"), FileMode.Open))
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                imageToAdd.LoadImage(memoryStream.ToArray());
            }
        }*/
        using (var stream = File.Open(Path.Combine(Application.persistentDataPath, "qrtest.png"), FileMode.Open))
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                imageToAdd.LoadImage(memoryStream.ToArray());
            }
        }

        detectUseCase.AddImage(imageToAdd);
    }


    public string GetText()
    {
        return tutorialUseCase.GetCurrentStep().Text;
    }

    public bool HasNextImage()
    {
        return currentImageIndex<images.Count-1;
    }

    public bool HasPrevImage()
    {
        return currentImageIndex>0;
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

    public void InitUseCase(ARTrackedImageManager imageTrackingManager, XRReferenceImageLibrary serializedLibrary)
    {
        detectUseCase = new DetectUseCase(new TargetImageHandler(imageTrackingManager, serializedLibrary));
    }
}
