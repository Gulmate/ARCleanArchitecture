using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TargetImageHandler : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;

    [SerializeField]
    XRReferenceImageLibrary m_Library;

    public void Start()
    {
        m_TrackedImageManager.CreateRuntimeLibrary(m_Library);
    }

    public void AddImage()
    {

        
        Texture2D imageToAdd = new Texture2D(2, 2);

        using (var stream = File.Open(Path.Combine(Application.streamingAssetsPath, "qrtest.png"), FileMode.Open))
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                imageToAdd.LoadImage(memoryStream.ToArray());
            }

        }

        if (!(ARSession.state == ARSessionState.SessionInitializing || ARSession.state == ARSessionState.SessionTracking))
            return;

        var library = m_TrackedImageManager.referenceLibrary;
        if (library is MutableRuntimeReferenceImageLibrary mutableLibrary)
        {
            mutableLibrary.ScheduleAddImageWithValidationJob(
                imageToAdd,
                "my new image",
                0.5f /* 50 cm */);
            m_TrackedImageManager.referenceLibrary = mutableLibrary;
            
        }
    }

    void OnEnable() => m_TrackedImageManager.trackablesChanged.AddListener(OnChanged);

    void OnDisable() => m_TrackedImageManager.trackablesChanged.RemoveListener(OnChanged);

    void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            Debug.Log("XDD");
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = gameObject.transform.position;
            cube.name = "Spawned cube";
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            // Handle updated event
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // Handle removed event
        }
    }
}
