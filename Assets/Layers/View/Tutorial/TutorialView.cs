using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class TutorialView : MonoBehaviour
{
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button screenShotButton;

    [SerializeField] private RawImage tutorialImage;


    [Inject]
    private TutorialPresenter presenter;

   

    
    void Start()
    {
        prevButton.onClick.AddListener(() =>
        {
            var tex = presenter.PrevStep();
            if (tex != null)
            {
                tutorialImage.texture = tex;
            }
        });
        nextButton.onClick.AddListener(() =>
        {
            var tex = presenter.NextStep();
            if (tex != null)
            {
                tutorialImage.texture = tex;
            }

        });
        loadButton.onClick.AddListener(() =>
        {
            tutorialImage.texture= presenter.LoadTutorial(Application.persistentDataPath + "/Saves/kavefozo.zip");
        });

        screenShotButton.onClick.AddListener(() =>
        {
            presenter.TakeScreenshot();
        });
    }


}
