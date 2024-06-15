using System.Collections.Generic;
using System.Linq;
using Core.Controllers;
using UI;
using UnityEngine;

namespace Core.Data
{
    public class HeroContainer : MonoBehaviour
    {
        [SerializeField] private List<Hero> _heroes;
        
        public Hero GetHero(HeroView view)
        {
            var hero = _heroes.FirstOrDefault(v => v.View == view);

            if (hero == null)
            {
                Debug.LogError($"Hero {view} not found");
                return null;
            }
            
            hero.Construct();
            
            return hero;
        }
    }
}