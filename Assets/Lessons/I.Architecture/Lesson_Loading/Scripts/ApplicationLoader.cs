using Game.UI;
using Services;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    //1. Загрузка AppsFlyer & Facebook
    //2. Инициализация встроенных покупок
    //3. Авторизация в Gaming Services
    //4. Загрузка сцены игры
    //5. Загрузка попапов из Addressables
    //6. Загрузка данных игрока
    //7. Запуск игры
    public sealed class ApplicationLoader : MonoBehaviour
    {
        [SerializeField]
        private LoadingTask[] loadingTasks;
        
        public async void Start()
        {
            foreach (LoadingTask task in this.loadingTasks)
            {
                ServiceInjector.Inject(task);
                LoadingTask.Result result = await task.Do();
                
                if (!result.success)
                {
                    LoadingScreen.ReportError(result.error); //Popup 
                    break;
                }
            }
        }
    }
}