using VContainer;

public class FileUsecase: IFileUsecase
{
    private readonly ICubeInfrastructure _infrastructure;

    [Inject]
    public FileUsecase(ICubeInfrastructure infrastructure)
    {
        _infrastructure = infrastructure;
    }

    public void SaveCube()
    {
        _infrastructure.Save();
    }

    public void LoadCube()
    {
        _infrastructure.Load();
    }

}
