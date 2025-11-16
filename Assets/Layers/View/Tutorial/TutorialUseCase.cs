using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PicData
{
    public byte[] data;
}

public class TutorialUseCase
{
    private Ziphandler ziphandler = new Ziphandler();
    private List<PicData> tutorialImages = new List<PicData>();
    private MyLogger logger = new MyLogger();
    private string sessionName;

    private int currentStep = 0;

    public byte[] NextStep()
    {
        if (currentStep < tutorialImages.Count - 1)
        {
            currentStep++;
            logger.LogToJSON("Next button clicked successfully");
            return tutorialImages[currentStep].data;
        }
        else
        {
            logger.LogToJSON("Next button clicked failed - no more steps");
            return null;
        }
    }

    public byte[] PrevStep()
    {
        if (currentStep > 0)
        {
            currentStep--;
            logger.LogToJSON("Previous button clicked successfully");
            return tutorialImages[currentStep].data;
        }
        else
        {
            logger.LogToJSON("Previous button clicked failed - no previous steps");
            return null;
        }
    }

    public void loggerSetup()
    {
        sessionName = $"session{DateTime.Now.ToString().Replace(" ","").Replace(":","-")}";
        logger.setZipPath(Path.Combine(Application.persistentDataPath, $"Logs/{sessionName}.zip"));
    }

    public byte[] LoadTutorial(string zipPath)
    {
        tutorialImages = ziphandler.loadZipPics(zipPath);
        currentStep = 0;
        Dictionary<string, string> logData = new Dictionary<string, string>
        {
            { "zipPath", zipPath }
        };
        logger.LogToJSON("Tutorial images loaded from zip", logData);
        return tutorialImages.Count > 0 ? tutorialImages[0].data : null;
    }

    public void TakeScreenshot(string screenshotPath)
    {
        DateTime now = DateTime.Now;
        string newScreenshotPath = Path.Combine(Application.persistentDataPath,$"/Logs/{sessionName}.zip/Logs/screenshot_{now.ToString().Replace(" ", "").Replace(":", "-")}.png");
        Debug.Log(newScreenshotPath);
        ziphandler.saveScreenshotToZip(
            Path.Combine(Application.persistentDataPath, $"Logs/{sessionName}.zip"),
            File.ReadAllBytes(screenshotPath),
            $"Logs/screenshot_{now.ToString().Replace(" ", "").Replace(":", "-")}.png"
        );
        Dictionary<string, string> logData = new Dictionary<string, string>
        {
            { "screenshotPath", newScreenshotPath }
        };

        logger.LogToJSON("Screenshot taken.",logData);
    }
}