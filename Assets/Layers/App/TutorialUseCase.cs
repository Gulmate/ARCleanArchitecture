using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TutorialUseCase
{
    private Ziphandler ziphandler = new Ziphandler();
    private DocumentationLogger logger = new DocumentationLogger();
    private string sessionName;

    private StepHandler stepHandler = new StepHandler();

    

    public void NextStep()
    {
        if (stepHandler.HasNextStep())
        {
            logger.LogToJSON("Next button clicked successfully");
        }
        else
        {
            logger.LogToJSON("Next button clicked failed - no more steps");
        }
    }

    public void PrevStep()
    {
        if (stepHandler.HasPrevStep())
        {
            logger.LogToJSON("Previous button clicked successfully");
        }
        else
        {
            logger.LogToJSON("Previous button clicked failed - no previous steps");
        }
    }

    public void loggerSetup()
    {
        sessionName = $"session{DateTime.Now.ToString().Replace(" ","").Replace(":","-")}";
        logger.setZipPath(Path.Combine(Application.persistentDataPath, $"Logs/{sessionName}.zip"));
    }

    public void LoadTutorial(string zipPath)
    {
        stepHandler.loadSteps(ziphandler.LoadStepsFromZip(zipPath));
        Dictionary<string, string> logData = new Dictionary<string, string>
        {
            { "zipPath", zipPath }
        };
        logger.LogToJSON("Tutorial loaded from zip", logData);
        
    }

    public Step GetCurrentStep()
    {
        return stepHandler.getCurrentStep();
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