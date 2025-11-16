using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class TutorialPresenter : MonoBehaviour
{
    private TutorialUseCase tutorialUseCase = new TutorialUseCase();

    public Texture2D NextStep()
    {
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(tutorialUseCase.NextStep());
        return texture;
    }

    public void Start()
    {
        tutorialUseCase.loggerSetup();
    }

    public Texture2D PrevStep()
    {
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(tutorialUseCase.PrevStep());
        return texture;
    }

    public Texture2D LoadTutorial(string zipPath)
    {
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(tutorialUseCase.LoadTutorial(zipPath));
        return texture;
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
