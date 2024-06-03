using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public GameObject cardPrefab;
    public override void InstallBindings()
    {
        Container.Bind<TimerController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerPrefsManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ScoreManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameUIManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<LevelManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PairMatchController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CellSizeFlexable>().FromComponentInHierarchy().AsSingle();

        Container.BindFactory<Card, CardFactory>().FromComponentInNewPrefab(cardPrefab);
    }
}
