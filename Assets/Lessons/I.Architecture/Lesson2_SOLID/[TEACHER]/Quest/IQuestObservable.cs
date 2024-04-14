using System;
using Lessons.I.Architecture.Lesson2_SOLID._TEACHER_;

public interface IQuestObservable {
    event Action<Quest> OnCompleted;
}