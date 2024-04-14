using System.Collections.Generic;

namespace Elementary
{
    public class ActionComposite : IAction
    {
        protected List<IAction> actions;
        
        public ActionComposite()
        {
            this.actions = new List<IAction>(1);
        }

        public ActionComposite(params IAction[] actions)
        {
            this.actions = new List<IAction>(actions);
        }

        public static ActionComposite operator +(ActionComposite actionComposite, IAction action)
        {
            if (actionComposite == null)
            {
                actionComposite = new ActionComposite();
            }

            actionComposite.actions.Add(action);
            return actionComposite;
        }
        
        public static ActionComposite operator +(ActionComposite actionComposite, IEnumerable<IAction> action)
        {
            if (actionComposite == null)
            {
                actionComposite = new ActionComposite();
            }

            actionComposite.actions.AddRange(action);
            return actionComposite;
        }

        public static ActionComposite operator -(ActionComposite actionComposite, IAction action)
        {
            if (actionComposite == null)
            {
                return null;
            }

            actionComposite.actions.Remove(action);
            return actionComposite;
        }
        
        public void Do()
        {
            foreach (var action in this.actions)
            {
                action.Do();
            }
        }
    }
    
    public class ActionComposite<T> : IAction<T>
    {
        protected List<IAction<T>> actions;
        
        public ActionComposite()
        {
            this.actions = new List<IAction<T>>(1);
        }

        public ActionComposite(params IAction<T>[] actions)
        {
            this.actions = new List<IAction<T>>(actions);
        }

        public static ActionComposite<T> operator +(ActionComposite<T> actionComposite, IAction<T> action)
        {
            if (actionComposite == null)
            {
                actionComposite = new ActionComposite<T>();
            }

            actionComposite.actions.Add(action);
            return actionComposite;
        }
        
        public static ActionComposite<T> operator +(ActionComposite<T> actionComposite, IEnumerable<IAction<T>> action)
        {
            if (actionComposite == null)
            {
                actionComposite = new ActionComposite<T>();
            }

            actionComposite.actions.AddRange(action);
            return actionComposite;
        }

        public static ActionComposite<T> operator -(ActionComposite<T> actionComposite, IAction<T> action)
        {
            if (actionComposite == null)
            {
                return null;
            }
            
            actionComposite.actions.Remove(action);
            return actionComposite;
        }

        public void Do(T args)
        {
            foreach (var listener in this.actions)
            {
                listener.Do(args);
            }
        }
    }
}