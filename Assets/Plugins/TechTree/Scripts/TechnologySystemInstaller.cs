using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TechTree
{
    [CreateAssetMenu(
        fileName = "TechnologySystemInstaller",
        menuName = "Zenject/Installers/New TechnologySystemInstaller"
    )]
    public sealed class TechnologySystemInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private TechnologyCatalog catalog;
        
        public override void InstallBindings()
        {
            this.Container.BindInterfacesAndSelfTo<TechonologyManager>().AsSingle();
            this.Container.Bind<Technology>().FromMethodMultiple(this.CreateTechnogies).AsCached();
        }

        private IEnumerable<Technology> CreateTechnogies(InjectContext arg)
        {
            DiContainer diContainer = arg.Container;
            IReadOnlyList<TechnologyConfig> configs = catalog.GetAllTechnologies();
            for (int i = 0, count = configs.Count; i < count; i++)
            {
                TechnologyConfig config = configs[i];
                yield return config.CreateTechnology(diContainer);
            }
        }
    }
}