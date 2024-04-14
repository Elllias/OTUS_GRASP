using System.Threading.Tasks;
using Asyncoroutine;
using Game.GameEngine.GameResources;
using Game.Gameplay.Player;
using GameSystem;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    public class GameDataLoader
    {
        public async Task LoadData(GameContext context)
        {
            //Тяжелая операция...
            await new WaitForSeconds(2.0f);
            
            
            context.GetService<MoneyStorage>().SetupMoney(100);
            context.GetService<ResourceStorage>().Setup(new[]
            {
                new ResourceData(ResourceType.WOOD, 10),
                new ResourceData(ResourceType.STONE, 20),
                new ResourceData(ResourceType.LUMBER, 50)
            });
        }
    }
}