using System;
using System.Collections.Generic;

namespace Core
{
    public abstract class Pipeline
    {
        public event Action Finished;

        private readonly List<Task> _tasks = new();
        
        private int _currentTaskIndex;
        
        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public void ClearTasks()
        {
            _tasks.Clear();
        }

        public void Run()
        {
            _currentTaskIndex = 0;
            RunNextTask();
        }

        private void RunNextTask()
        {
            if (_currentTaskIndex >= _tasks.Count)
            {
                Finished?.Invoke();
                return;
            }
            
            _tasks[_currentTaskIndex].Run(OnTaskFinished);
        }

        private void OnTaskFinished()
        {
            _currentTaskIndex += 1;
            RunNextTask();
        }
    }
}