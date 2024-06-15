using UnityEngine;

namespace Core.Tasks
{
    public class StartTask : Task
    {
        protected override void OnRun()
        {
            Debug.LogWarning("StartTask");
            
            Finish();
        }
    }
}