using System.Collections.Generic;

namespace Elementary
{
    public class ConditionComposite : ICondition
    {
        protected List<ICondition> conditions;

        public ConditionComposite()
        {
            this.conditions = new List<ICondition>(1);
        }

        public ConditionComposite(params ICondition[] conditions)
        {
            this.conditions = new List<ICondition>(conditions);
        }

        public static ConditionComposite operator +(ConditionComposite composite, ICondition condition)
        {
            if (composite == null)
            {
                composite = new ConditionComposite();
            }
            
            composite.conditions.Add(condition);
            return composite;
        }

        public static ConditionComposite operator +(ConditionComposite composite, IEnumerable<ICondition> condition)
        {
            if (composite == null)
            {
                composite = new ConditionComposite();
            }
            
            composite.conditions.AddRange(condition);
            return composite;
        }
        
        public static ConditionComposite operator -(ConditionComposite composite, ICondition condition)
        {
            if (composite == null)
            {
                return null;
            }

            composite.conditions.Remove(condition);
            return composite;
        }

        public bool IsTrue()
        {
            for (int i = 0, count = this.conditions.Count; i < count; i++)
            {
                var condition = this.conditions[i];
                if (!condition.IsTrue())
                {
                    return false;
                }
            }

            return true;
        }
    }
    
    public class ConditionComposite<T> : ICondition<T>
    {
        protected List<ICondition<T>> conditions;

        public ConditionComposite()
        {
            this.conditions = new List<ICondition<T>>(1);
        }

        public ConditionComposite(params ICondition<T>[] conditions)
        {
            this.conditions = new List<ICondition<T>>(conditions);
        }
        
        public static ConditionComposite<T> operator +(ConditionComposite<T> composite, ICondition<T> condition)
        {
            if (composite == null)
            {
                composite = new ConditionComposite<T>();
            }
            
            composite.conditions.Add(condition);
            return composite;
        }

        public static ConditionComposite<T> operator +(ConditionComposite<T> composite, IEnumerable<ICondition<T>> condition)
        {
            if (composite == null)
            {
                composite = new ConditionComposite<T>();
            }
            
            composite.conditions.AddRange(condition);
            return composite;
        }
        
        public static ConditionComposite<T> operator -(ConditionComposite<T> composite, ICondition<T> condition)
        {
            if (composite == null)
            {
                return null;
            }

            composite.conditions.Remove(condition);
            return composite;
        }

        public bool IsTrue(T args)
        {
            for (int i = 0, count = this.conditions.Count; i < count; i++)
            {
                var condition = this.conditions[i];
                if (!condition.IsTrue(args))
                {
                    return false;
                }
            }

            return true;
        }
    }
}