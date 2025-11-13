using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TutorialUseCase
{
    private Ziphandler ziphandler = new Ziphandler();
    //TODO: Change to not Unity type
    private List<Texture2D> tutorialImages = new List<Texture2D>();
    private MyLogger logger = new MyLogger();

    private int currentStep = 0;

    public Texture2D NextStep()
    {
        if (currentStep < tutorialImages.Count - 1)
        {
            currentStep++;
            logger.LogToJSON("Next button clicked successfully");
            return tutorialImages[currentStep];
        }
        else
        {
            logger.LogToJSON("Next button clicked failed - no more steps");
            return null;
        }
    }

    public Texture2D PrevStep()
    {
        if (currentStep > 0)
        {
            currentStep--;
            logger.LogToJSON("Previous button clicked successfully");
            return tutorialImages[currentStep];
        }
        else
        {
            logger.LogToJSON("Previous button clicked failed - no previous steps");
            return null;
        }
    }

    public Texture2D LoadTutorial(string zipPath)
    {
        logger.setZipPath(zipPath);
        tutorialImages = ziphandler.loadZipPics(zipPath);
        currentStep = 0;
        logger.LogToJSON("Tutorial images loaded from zip", zipPath);
        return tutorialImages.Count > 0 ? tutorialImages[0] : null;
    }

    public void TakeScreenshot(string screenshotPath)
    {
        ziphandler.saveScreenshotToZip(
            Path.Combine(Application.dataPath, "Saves/kavefozo.zip"),
            File.ReadAllBytes(screenshotPath),
            "Logs/screenshot_placeholder.png"
        );

        logger.LogToJSON("Screenshot taken", Application.dataPath +"/Saves/kavefozo.zip"+ "/Logs/screenshot_placeholder.png");
    }
}