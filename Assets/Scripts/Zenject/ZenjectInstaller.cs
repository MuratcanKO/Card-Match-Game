using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ZenjectInstaller>().FromComponentInHierarchy().AsSingle();
    }
}
