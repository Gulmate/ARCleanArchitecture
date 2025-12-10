using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TargetImageHandler
{

    private ARTrackedImageManager imageManager;
    private XRReferenceImageLibrary library;

    private MarkerData markerData;
    private bool detectRuning = false;


    public TargetImageHandler(ARTrackedImageManager trackedImageManager, XRReferenceImageLibrary mutableLibrary)
    {
        imageManager = trackedImageManager;
        library = mutableLibrary;
        imageManager.CreateRuntimeLibrary(library);
    }

    public void AddImage(Texture2D imageToAdd)
    {
        

        if (!(ARSession.state == ARSessionState.SessionInitializing || ARSession.state == ARSessionState.SessionTracking))
            return;

        var library = imageManager.referenceLibrary;
        if (library is MutableRuntimeReferenceImageLibrary mutableLibrary)
        {
            mutableLibrary.ScheduleAddImageWithValidationJob(
                imageToAdd,
                "my new image",
                0.5f /* 50 cm */);
            imageManager.referenceLibrary = mutableLibrary;

        }
    }

    public void StartDetection()
    {
        if (detectRuning) return;
        imageManager.trackablesChanged.AddListener(OnChanged);
        detectRuning = true;
    }

    public void StopDetection()
    {
        if (!detectRuning) return;
        imageManager.trackablesChanged.RemoveListener(OnChanged);
        detectRuning = false;
    }

    public MarkerData GetMarkerData()
    {
        return markerData;
    }

    private void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            markerData = new MarkerData
            {
                Name = newImage.referenceImage.name,
                XCord = newImage.transform.position.x,
                YCord = newImage.transform.position.y,
                ZCord = newImage.transform.position.z
            };
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            // Ha kell változást követni
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // Ha kell törlést követni
        }
    }
}
