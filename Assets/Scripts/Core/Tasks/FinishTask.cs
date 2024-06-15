using Core.Controllers;
using Core.Pipelines;
using UnityEngine;

namespace Core.Tasks
{
    public class FinishTask : Task
    {
        protected override void OnRun()
        {
            Finish();
        }
    }
}