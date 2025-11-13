using System.Collections;
using System.IO;
using UnityEngine;

public class TutorialPresenter : MonoBehaviour
{
    //TODO: Here should be the load to t2D
    private TutorialUseCase tutorialUseCase = new TutorialUseCase();

    public Texture2D NextStep()
    {
        return tutorialUseCase.NextStep();
    }

    public Texture2D PrevStep()
    {
        return tutorialUseCase.PrevStep();
    }

    public Texture2D LoadTutorial(string zipPath)
    {
        return tutorialUseCase.LoadTutorial(zipPath);
    }

    public void TakeScreenshot()
    {
        string screenshotPath = Application.dataPath + "/screenshot_placeholder.png";
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
