namespace Declarative
{
    internal static class MonoContextInstaller
    {
        internal static void InstallElements(object section, MonoContext monoContext)
        {
            var sectionType = section.GetType();
            var fields = ReflectionUtils.RetrieveFields(sectionType);

            for (int i = 0, count = fields.Count; i < count; i++)
            {
                var field = fields[i];
                var fieldValue = field.GetValue(section);
                
                if (fieldValue is IMonoElement listener)
                {
                    monoContext.AddListener(listener);
                }
            }
        }
    }
}