using System;
using UnityEngine;
using VContainer;

public class FileUsecase : IFileUsecase
{
    public event EventHandler<ButtonEventArgs> OnButtonPressed;
    private readonly CubeFileHandler fileService;
    private readonly CubeTransformator transService;

    [Inject]
    public FileUsecase(CubeFileHandler fService, CubeTransformator tService)
    {
        fileService = fService;
        transService = tService;
    }

    public void SaveCube()
    {
        fileService.Save(transService.GetColor(),transService.GetSize(), transService.GetRotation());
    }

    public void LoadCube()
    {
        SaveCube saveCube=fileService.Load();
        transService.Resize(saveCube._size);
        transService.ReColor(new Color(saveCube._colorCords[0], saveCube._colorCords[1], saveCube._colorCords[2], saveCube._colorCords[3]));
        transService.Rotate(new Vector3(saveCube._rotationCords[0], saveCube._rotationCords[1], saveCube._rotationCords[2]));
        OnButtonPressed?.Invoke(this, new ButtonEventArgs(transService.GetSize(), transService.GetColor(), transService.GetRotation()));
    }

    public void onPressed(Action<float, Color, Vector3> onClicked)
    {
        OnButtonPressed += new EventHandler<ButtonEventArgs>(delegate (object sender, ButtonEventArgs event_arg)
        {
            onClicked(event_arg.size, event_arg.color, event_arg.rotation);
        });
    }
}
