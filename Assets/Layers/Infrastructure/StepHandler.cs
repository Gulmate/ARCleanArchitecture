using System;
using System.Collections.Generic;
using UnityEngine;


public class StepHandler
{
    private List<Step> steps = new List<Step>();
    private int currentStep = 0;

    public void NextStep()
    {
        currentStep++;
    }

    public bool HasNextStep()
    {
        return currentStep < steps.Count - 1;
    }

    public void PrevStep()
    {
        currentStep--;
    }

    public bool HasPrevStep()
    {
        return currentStep > 0;
    }

    public void loadSteps(List<Step> newSteps)
    {
        steps = newSteps;
        currentStep = 0;
        Debug.Log("Loaded " + steps.Count + " steps.");
    }

    public Step getCurrentStep()
    {
        return steps[currentStep];
    }

    public bool isLastStep()
    {
        return currentStep == steps.Count - 1;
    }

    public bool isFirstStep()
    {
        return currentStep == 0;
    }
}
