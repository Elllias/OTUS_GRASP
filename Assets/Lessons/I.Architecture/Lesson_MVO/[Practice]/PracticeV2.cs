using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture.MVO
{
    public interface IUser
    {
        event Action<string> OnNameChanged;
        event Action<Sprite> OPhotoChanged; 

        string Name { get; }
        Sprite Photo { get; }
    }

    public interface IFriendList
    {
        event Action<IUser> OnAdded;
        event Action<IUser> OnRemoved;
        
        IEnumerable<IUser> GetUsers();
    }
}