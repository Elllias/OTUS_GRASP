using UnityEngine;

namespace Core.Tasks
{
    public class FinishTask : Task
    {
        protected override void OnRun()
        {
            Debug.LogWarning("FinishTask");
            Finish();
        }
    }
}