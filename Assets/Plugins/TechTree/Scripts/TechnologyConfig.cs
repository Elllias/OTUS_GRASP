using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace TechTree
{
    [CreateAssetMenu(
        fileName = "TechnologyConfig",
        menuName = "Technologies/New TechnologyConfig"
    )]
    public abstract class TechnologyConfig : ScriptableObject
    {
        [field: SerializeField]
        public string Id { get; private set; }

        [field: SerializeField]
        public int Price { get; private set; }
        
        [field: SerializeField]
        public int Level { get; set; }

        [SerializeField]
        public TechnologyDependency[] Dependencies;

        [SerializeField] 
        public int UpgradeCost;
        
        [SerializeField] 
        public int UpgradeCostDifference;

        [SerializeField] 
        public int MaxLevel;
        
        [PropertySpace]
        [Title("Meta")]
        [SerializeField]
        public string Title;
        
        [field: SerializeField]
        public string Description { get;  private set;}
        
        [field: SerializeField, PreviewField]
        public Sprite Icon { get;  private set;}

        public abstract Technology CreateTechnology(DiContainer container);
    }

    public abstract class TechnologyConfig<T> : TechnologyConfig where T : Technology
    {
        public override Technology CreateTechnology(DiContainer container)
        {
            return (Technology) container.Instantiate(typeof(T), new object[] {this});
        }
    }
    
    [Serializable]
    public class TechnologyDependency
    {
        [SerializeField] public int Level;
        [SerializeField] public TechnologyConfig Technology;
    }
}