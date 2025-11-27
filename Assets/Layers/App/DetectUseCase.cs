using UnityEngine;

public class DetectUseCase
{
    private TargetImageHandler targetImageHandler;

    public DetectUseCase(TargetImageHandler targetImageHandler)
    {
        this.targetImageHandler = targetImageHandler;
    }

    public void StartDetection()
    { 
        targetImageHandler.StartDetection();
    }

    public void StopDetection()
    {
        targetImageHandler.StopDetection();
    }

    public void AddImage(Texture2D texture)
    {
        targetImageHandler.AddImage(texture);
    }
}
