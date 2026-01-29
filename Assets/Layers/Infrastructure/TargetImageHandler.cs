using NUnit.Framework;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TargetImageHandler : ITargetImageHandler
{

    private ARTrackedImageManager imageManager;
    private XRReferenceImageLibrary library;

    private MarkerData markerData;
    private bool detectRuning = false;

    public event Action<MarkerData> MarkerAdded;

    public TargetImageHandler(ARTrackedImageManager trackedImageManager, XRReferenceImageLibrary mutableLibrary)
    {
        imageManager = trackedImageManager;
        library = mutableLibrary;

        if (library != null)
        {
            imageManager.referenceLibrary = imageManager.CreateRuntimeLibrary(library);
        }
        else
        {
            imageManager.referenceLibrary = imageManager.CreateRuntimeLibrary();
        }
    }

    public void AddImage(byte[] pictureData)
    {
        Texture2D imageToAdd = new Texture2D(2, 2);

        /*using (var stream = File.Open(Path.Combine(Application.persistentDataPath, "qrtest.png"), FileMode.Open))
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                imageToAdd.LoadImage(memoryStream.ToArray());
            }
        }*/
        imageToAdd.LoadImage(pictureData);
        Debug.Log("Adding image to library");

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
        Debug.Log("Starting image detection");
        imageManager.trackablesChanged.AddListener(OnChanged);
        detectRuning = true;
        Debug.Log(imageManager.referenceLibrary.count);
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

    private bool markerPlaced = false;

    private void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        if (markerPlaced)
        {
            return;
        }

        foreach (var image in eventArgs.added)
        {
            TryEmit(image);
        }
            

        foreach (var image in eventArgs.updated)
        {
            TryEmit(image);
        }
    }

    private void TryEmit(ARTrackedImage image)
    {
        if (markerPlaced)
        {
            return;
        }

        if (image.trackingState != TrackingState.Tracking)
        {
            return;
        }

        markerPlaced = true;
        

        markerData = new MarkerData
        {
            Name = image.referenceImage.name,
            XCord = image.transform.position.x,
            YCord = image.transform.position.y,
            ZCord = image.transform.position.z
        };

        MarkerAdded?.Invoke(markerData);
        //StopDetection();
        //imageManager.enabled = false;
    }
}
