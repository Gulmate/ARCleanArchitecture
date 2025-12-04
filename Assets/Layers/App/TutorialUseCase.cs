using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TutorialUseCase
{
    private Ziphandler ziphandler = new Ziphandler();
    private string sessionName;

    private StepHandler stepHandler = new StepHandler();

    

    public void NextStep()
    {
        if (stepHandler.HasNextStep())
        {
            stepHandler.NextStep();
        }
    }


    public void PrevStep()
    {
        if (stepHandler.HasPrevStep())
        {
            stepHandler.PrevStep();
        }
    }

    /*public void loggerSetup()
    {
        sessionName = $"session{DateTime.Now.ToString().Replace(" ","").Replace(":","-")}";

    }*/

    public void LoadTutorial(string zipPath)
    {
        List<Step> steps = ziphandler.LoadStepsFromZip(zipPath);
        stepHandler.loadSteps(steps);
        /*Dictionary<string, string> logData = new Dictionary<string, string>
        {
            { "zipPath", zipPath }
        };
        logger.LogToJSON("Tutorial loaded from zip", logData);*/
        
    }

    public Step GetCurrentStep()
    {
        return stepHandler.getCurrentStep();
    }

    public bool isLastStep()
    {
        return stepHandler.isLastStep();
    }

    public bool isFirstStep()
    {
        return stepHandler.isFirstStep();
    }

    //Ide nem kell csak minta
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

        //logger.LogToJSON("Screenshot taken.",logData);
    }
}