using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using VContainer;

public class TutorialView : MonoBehaviour
{
    [SerializeField] private Button prevStepButton;
    [SerializeField] private Button nextStepButton;

    [SerializeField] private Button loadButton;
    [SerializeField] private Button screenShotButton;

    [SerializeField] private Button TextButton;
    [SerializeField] private TextMeshProUGUI tutorialText;

    [SerializeField] private Button imageButton;
    [SerializeField] private Button nextImageButton;
    [SerializeField] private Button prevImageButton;
    [SerializeField] private RawImage tutorialImage;

    [SerializeField] private Button videoButton;
    [SerializeField] private Button playVideoButton;
    [SerializeField] private Button pauseVideoButton;
    [SerializeField] private Button restartVideoButton;
    [SerializeField] private VideoPlayer videoPlayer;

    [SerializeField] private Button audioButton;
    [SerializeField] private Button playAudioButton;
    [SerializeField] private Button pauseAudioButton;
    [SerializeField] private Button restartAudioButton;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private XRReferenceImageLibrary serializedLibrary;
    [SerializeField] private ARTrackedImageManager imageTrackingManager;

    [Inject]
    private TutorialPresenter presenter;


    void Start()
    {
        prevStepButton.onClick.AddListener(() =>
        {
            presenter.PrevStep();

        });
        nextStepButton.onClick.AddListener(() =>
        {
            presenter.NextStep();

        });
        loadButton.onClick.AddListener(() =>
        {
            presenter.LoadTutorial(Application.persistentDataPath + "/Saves/kavefozo.zip");
        });

        screenShotButton.onClick.AddListener(() =>
        {
            presenter.TakeScreenshot();
        });

        TextButton.onClick.AddListener(() =>
        {
            tutorialText.text = presenter.GetText();
        });


        imageButton.onClick.AddListener(() =>
        {
            Texture2D tex = presenter.GetCurrentPic();
            if (tex != null)
            {
                tutorialImage.texture = tex;
            }
            tutorialImage.texture = tex;
        });
        nextImageButton.onClick.AddListener(() =>
        {
            Texture2D tex = presenter.GetNextPic();
            if (tex != null)
            {
                tutorialImage.texture = tex;
            }
            tutorialImage.texture = tex;
        });
        prevImageButton.onClick.AddListener(() =>
        {
            Texture2D tex = presenter.GetPrevPic();
            if (tex != null)
            {
                tutorialImage.texture = tex;
            }
            tutorialImage.texture = tex;
        });


        videoButton.onClick.AddListener(() => { videoPlayer.url = presenter.GetVideo();});
        playVideoButton.onClick.AddListener(() => { videoPlayer.Play(); });
        pauseVideoButton.onClick.AddListener(() => { videoPlayer.Pause(); });
        restartVideoButton.onClick.AddListener(() => { videoPlayer.time = 0; });


        audioButton.onClick.AddListener(async () => {  audioSource.clip= await presenter.GetAudio(); });
        playAudioButton.onClick.AddListener(() => { audioSource.Play(); });
        pauseAudioButton.onClick.AddListener(() => { audioSource.Pause(); });
        restartAudioButton.onClick.AddListener(() => { audioSource.time = 0; });

        presenter.InitUseCase(imageTrackingManager,serializedLibrary);
    }


}
