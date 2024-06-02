using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<TimerController>().FromComponentInHierarchy().AsSingle();
    }
}
