using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<TimerController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerPrefsManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ScoreManager>().FromComponentInHierarchy().AsSingle();
    }
}
